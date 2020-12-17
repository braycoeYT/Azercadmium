using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Scavenger
{
	public class SpacetimeCore : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spacetime Core");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(575);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.width = 36;
			projectile.height = 36;
			projectile.timeLeft = 180;
			aiType = 575;
		}
		public override void AI() {
			projectile.rotation += 0.16f;
		}
		public override void PostAI() {
			for (int i = 0; i < 2; i++) {
				int dustType = mod.DustType("MatrixScavengerDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(projectile.position, new Vector2(0, 5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, 5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, 0), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(5, -5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(0, -5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, -5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, 0), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.position, new Vector2(-5, 5), ProjectileID.DeathLaser, 19, 0, Main.myPlayer);
		}
	}   
}