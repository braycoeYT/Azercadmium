using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Devastation
{
	public class GiantSlimeSpikeFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Giant Slime Spike");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.penetrate = 999;
			projectile.scale = 0.01f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 40;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			damage += target.defense / 2;
		}
		public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
			damage += target.statDefense / 2;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(2, 5) * 60);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("SlimyOoze"), Main.rand.Next(2, 5) * 60);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.t_Slime);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		int Timer;
		float lowestDistance;
		float angle = 0.5f * (float)Math.PI;
		NPC target;
		public override void AI() {
			
			Timer++;
			if (Timer > 149) { //99 scale complete
				//projectile.aiStyle = 1;
				projectile.damage = 25;
				projectile.scale = 0.8f;
				projectile.height = (int)(75 * projectile.scale);
				projectile.width = (int)(75 * projectile.scale);
				aiType = ProjectileID.Bullet;
				projectile.velocity = 5f * new Vector2((float)Math.Cos(projectile.rotation), (float)Math.Sin(projectile.rotation));
			}
			else {
				projectile.damage = 1;
				if (projectile.scale < 0.8f)
				projectile.scale += 0.01f;
				projectile.height = (int)(75 * projectile.scale);
				projectile.width = (int)(75 * projectile.scale);
				lowestDistance = 999999;
				int npcCount;
				for (npcCount = 0; npcCount < Main.maxNPCs; npcCount++) {
					if (Main.npc[npcCount].active) {
						if (Vector2.Distance(projectile.Center, Main.npc[npcCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(projectile.Center, Main.npc[npcCount].Center);
							target = Main.npc[npcCount];
						}
					}
				}
				Vector2 look = target.Center - projectile.Center;
				if (look.X != 0f) {
					angle = (float)Math.Atan(look.Y / look.X);
				}
				else if (look.Y < 0f) {
					angle += (float)Math.PI;
				}
				if (look.X < 0f) {
					angle += (float)Math.PI;
				}
				projectile.rotation = angle;
			}
		}
	}   
}