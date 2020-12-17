using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Devastation
{
	public class GiantSlimeSpike : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Giant Slime Spike");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.penetrate = 999;
			projectile.scale = 0.01f;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
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
		Player target;
		public override void AI() {
			
			Timer++;
			if (Timer > 149) { //99 scale complete
				//projectile.aiStyle = 1;
				projectile.scale = 0.8f;
				projectile.height = (int)(75 * projectile.scale);
				projectile.width = (int)(75 * projectile.scale);
				aiType = ProjectileID.Bullet;
				projectile.velocity = 5f * new Vector2((float)Math.Cos(projectile.rotation), (float)Math.Sin(projectile.rotation));
			}
			else {
				if (projectile.scale < 0.8f)
				projectile.scale += 0.01f;
				projectile.height = (int)(75 * projectile.scale);
				projectile.width = (int)(75 * projectile.scale);
				lowestDistance = 999999;
				int playerCount;
				for (playerCount = 0; playerCount < 255; playerCount++) {
					if (Main.player[playerCount].active) {
						if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
							lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center);
							target = Main.player[playerCount];
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