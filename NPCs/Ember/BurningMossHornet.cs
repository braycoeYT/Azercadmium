using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Helpers;
using Azercadmium.Aaa;
using Azercadmium.Items.Ember;

namespace Azercadmium.NPCs.Ember
{
    public class BurningMossHornet : ModNPC
    {
        public override void SetStaticDefaults() {
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Hornet];
            DisplayName.SetDefault("Cinder Hornet");
        }
        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.Hornet);
            npc.width = 40;
            npc.height = 60;
            aiType = NPCID.Hornet;
            animationType = NPCID.Hornet;
            npc.lifeMax = 150;
            npc.damage = 35;
            npc.defense = 12;
            npc.knockBackResist = 0.45f;
            npc.value = Item.buyPrice(silver: 10);
            npc.noTileCollide = true;
            //banner = npc.type;
            //bannerItem = ModContent.ItemType<BurningMossHornetBanner>();
        }

        public override void DrawEffects(ref Color drawColor)
        {
            int d = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire);
            Main.dust[d].noLight = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 offset = new Vector2((float)(Math.Sin(Main.GameUpdateCount * 0.125f) + 1f) * 1.125f, 0f).RotatedBy(MathHelper.PiOver2 * i);
                offset.Y = 2;
                spriteBatch.WorldDraw(Azercadmium.extraTexture[7], npc.Center + offset, npc.frame, ColorHelper.EmberGladesColor2 * 0.88f, npc.rotation, new Vector2(40, 30), npc.scale, DrawingHelper.DirectionToSpriteEffects(-npc.spriteDirection));
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            if (Azercadmium.DownedAllMechBosses)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.75f);
                npc.damage = (int)(npc.damage * 1.6f);
                npc.defense = (int)(npc.defense * 1.5f);
                npc.knockBackResist *= 0.66f;
            }
            else if (NPC.downedMechBossAny)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.3f);
                npc.damage = (int)(npc.damage * 1.1f);
                npc.defense = (int)(npc.defense * 1.1f);
                npc.knockBackResist *= 0.7f;
            }
            else if (Main.hardMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.25f);
                npc.knockBackResist *= 0.8f;
            }
            else
            {
                npc.lifeMax = (int)(npc.lifeMax * 0.75f);
                npc.damage = (int)(npc.damage * 0.7f);
                npc.defense = (int)(npc.defense * 0.6f);
                npc.knockBackResist *= 0.9f;
            }
        }

        public override void AI()
        {
            if (npc.HasValidTarget)
            {
                Player target = Main.player[npc.target];
                if (!target.dead && target.active)
                {
                    Vector2 difference = target.Center - npc.Center;
                    float lengthFromTarget = Math.Abs(difference.Length());
                    float rotationToTarget = difference.ToRotation();
                    if (lengthFromTarget < 100 && npc.ai[2] <= 0)
                    {
                        npc.ai[2] = 180;
                        for (int i = 0; i < 8; i++)
                        {
                            Projectile.NewProjectile(npc.Center, new Vector2(12 + npc.velocity.Length(), 0).RotatedBy(MathHelper.PiOver4 * i), ProjectileID.GreekFire1, NPCHelper.ChangeProjectileDamageDependingOnDifficulty(npc.damage), 2f);
                            npc.velocity = npc.velocity.RotatedBy(rotationToTarget + MathHelper.Pi) * 1.011f;
                        }
                    }
                    else if (lengthFromTarget > 666 || Collision.SolidCollision(npc.position, npc.width, npc.height))
                    {
                        Vector2 newVelocity = new Vector2(MathHelper.Clamp(lengthFromTarget * 0.0015f, 2f, 16f), 0).RotatedBy(rotationToTarget);
                        float lerpAmount = MathHelper.Clamp(lengthFromTarget * 0.0015f, 0.0005f, 0.1f);
                        npc.velocity.X = MathHelper.Lerp(npc.velocity.X, newVelocity.X, lerpAmount);
                        npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, newVelocity.Y, lerpAmount);
                        if (npc.ai[2] <= 0)
                        {
                            npc.ai[2] = 240;
                            for (int i = 0; i < 5; i++)
                            {
                                int p = Projectile.NewProjectile(npc.Center, new Vector2(5 + npc.velocity.Length(), 0).RotatedBy(rotationToTarget - MathHelper.PiOver2 + MathHelper.PiOver4 * i), ProjectileID.Stinger, npc.damage, 2f);
                                Main.projectile[p].tileCollide = false;
                                Main.projectile[p].damage = (int)(npc.damage * 0.75f);
                                Main.projectile[p].scale = 1.5f;
                            }
                        }
                    }
                    npc.ai[2]--;
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit) {
            if (Main.rand.Next(2) == 0)
                target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 9));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return spawnInfo.player.GetModPlayer<TAZPlayer>().ZoneEmberGlades ? 0.2f : 0f;
        }
        public override void NPCLoot() {
            if (Main.rand.NextFloat() < 0.66f)
                Item.NewItem(npc.getRect(), ModContent.ItemType<BurntStinger>());
            if (Main.rand.NextFloat() < 0.66f)
                Item.NewItem(npc.getRect(), ModContent.ItemType<ScorchSap>());
        }
    }
}