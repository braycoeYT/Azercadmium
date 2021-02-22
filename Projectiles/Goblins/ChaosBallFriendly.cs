using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Goblins
{
	public class ChaosBallFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chaos Ball");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.timeLeft = 1200;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
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
			Vector2 vector3 = Vector2.Normalize(target.position - new Vector2(0, 0) - projectile.Center) * 10;
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * projectileRotation)), mod.ProjectileType("ChaosBallShardFriendly"), (int)(projectile.damage * 0.75f), (int)(projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (projectileRotation + 120))), mod.ProjectileType("ChaosBallShardFriendly"), (int)(projectile.damage * 0.75f), (int)(projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position, vector3.RotatedBy((float)((double)(Math.PI / 180) * (projectileRotation + 240))), mod.ProjectileType("ChaosBallShardFriendly"), (int)(projectile.damage * 0.75f), (int)(projectile.knockBack * 0.75f), Main.myPlayer, 0f, 0f);
		}
	}   
}