using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Solar
{
	public class GiantSolarFragment : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Giant Solar Fragment");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.penetrate = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Daybreak, 240);
		}
		int Timer;
		public override void AI() {
			Timer++;
			for (int i = 0; i < 5; i++) {
				int dustType = DustID.SolarFlare;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (Timer == 10) {
				projectile.width = 48;
				projectile.height = 48;
			}
			if (Timer == 20) {
				projectile.width = 56;
				projectile.height = 56;
			}
			if (Timer == 30) {
				projectile.width = 64;
				projectile.height = 64;
			}
		}
		float projectileRotation = Main.rand.NextFloat(0, 91);
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			float lowestDistance = 999999;
			int playerCount;
			Player target = Main.player[1];
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].active) {
					if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
						lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center + new Vector2(0, 6));
						 target = Main.player[playerCount];
					}
				}
			}
			Vector2 vector3 = Vector2.Normalize((target.position - new Vector2(0, 0)) - projectile.Center) * 10;
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * projectileRotation)), mod.ProjectileType("SolarFragmentProjectile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (projectileRotation + 90))), mod.ProjectileType("SolarFragmentProjectile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (projectileRotation + 180))), mod.ProjectileType("SolarFragmentProjectile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (projectileRotation + 270))), mod.ProjectileType("SolarFragmentProjectile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		}
	}   
}