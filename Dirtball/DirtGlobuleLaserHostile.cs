using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtGlobuleLaserHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Globule");
        }
		public override void SetDefaults() {
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			aiType = 1;
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int Timer;
		float lowestDistance;
		Player target;
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.position, new Vector2(0, 5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, 5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, 0), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, -5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(0, -5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, -5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, 0), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, 5), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0, Main.myPlayer);
			lowestDistance = 999999;
			int playerCount;
			for (playerCount = 0; playerCount < 255; playerCount++) {
				if (Main.player[playerCount].active) {
					if (Vector2.Distance(projectile.Center, Main.player[playerCount].Center) < lowestDistance) {
						lowestDistance = Vector2.Distance(projectile.Center, Main.player[playerCount].Center + new Vector2(0, 6));
						target = Main.player[playerCount];
					}
				}
			}
			Projectile.NewProjectile(projectile.position, Vector2.Normalize((target.position - new Vector2(0, 0)) - projectile.Center) * 5, mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
			if (AzercadmiumWorld.devastation) {
				Vector2 vector3 = Vector2.Normalize((target.position - new Vector2(0, 0)) - projectile.Center) * 5;
				Projectile.NewProjectile(projectile.position, vector3.RotatedBy(0.27f), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(projectile.position, vector3.RotatedBy(-0.27f), mod.ProjectileType("DirtGlobHostile"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
			}
		}
	}   
}