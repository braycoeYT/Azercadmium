using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Aaa;
using Azercadmium.Buffs.Debuffs;

namespace Azercadmium.Projectiles
{
    public class TAZPGlobal : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override bool CloneNewInstances => true;

        private bool initalized;

        public bool charred;

        public int target;

        public override bool PreAI(Projectile projectile)
        {
            if (!initalized)
            {
                initalized = true;
                if (projectile.friendly && !projectile.hostile && projectile.owner != 255)
                {
                    if (projectile.damage > 0)
                    {
                        Player owner = Main.player[projectile.owner];
                        TAZPlayer tAZPlayer = owner.ModPlayer();
                        if (tAZPlayer.charredProj)
                        {
                            charred = true;
                            projectile.netUpdate = true;
                        }
                    }
                }
            }
            return true;
        }

        public override void PostAI(Projectile projectile)
        {
            if (charred)
            {
                if (Main.rand.NextBool(8))
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.SolarFlare);
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.owner != 255)
            {
                Player owner = Main.player[projectile.owner];
                if (projectile.ranged)
                {
                    if (crit)
                    {
                        if (owner.ModPlayer().spiceMedallion > 0)
                        {
                            int p = Projectile.NewProjectile(owner.MountedCenter, Vector2.Normalize(Main.MouseWorld - owner.MountedCenter) * projectile.velocity.Length(), ProjectileID.TerraBeam, projectile.damage, projectile.knockBack, projectile.owner);
                            Main.projectile[p].melee = false;
                        }
                    }
                }
                if (projectile.magic)
                {
                    if (Main.rand.NextBool())
                    {
                        if (owner.ModPlayer().spiceMedallion > 0)
                        {
                            int p = Projectile.NewProjectile(target.Center, Vector2.Zero, ProjectileID.Grenade, projectile.damage, projectile.knockBack, projectile.owner);
                            Main.projectile[p].ranged = false;
                            Main.projectile[p].timeLeft = 2;
                        }
                    }
                }
            }
            if (charred)
            {
                target.AddBuff(ModContent.BuffType<Charred>(), 200);
            }
        }

        public void Send(BinaryWriter w)
        {
            w.Write(target);
            w.Write(charred);
            w.Write(initalized);
        }

        public void Receive(BinaryReader r)
        {
            target = r.ReadByte();
            charred = r.ReadBoolean();
            initalized = r.ReadBoolean();
        }

        public void TargetNearestNPC(Projectile projectile, float range, bool seeThroughWalls = false)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC t = Main.npc[i];
                if (t.active && t.lifeMax > 5 && !t.friendly && !t.townNPC && !t.dontTakeDamage && (range < 0 || Vector2.Distance(t.Center, projectile.Center) <= range) && (seeThroughWalls || Collision.CanHitLine(projectile.position, projectile.width, projectile.height, t.position, t.width, t.height)))
                {
                    target = t.whoAmI;
                }
            }
        }

        public void TargetNearestPlayer(Projectile projectile, float range, bool seeThroughWalls = false)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player t = Main.player[i];
                if (t.active && !t.dead && (range < 0 || Vector2.Distance(t.MountedCenter, projectile.Center) < range) && (seeThroughWalls || Collision.CanHitLine(projectile.position, projectile.width, projectile.height, t.position, t.width, t.height)))
                {
                    target = t.whoAmI;
                }
            }
        }
    }
}