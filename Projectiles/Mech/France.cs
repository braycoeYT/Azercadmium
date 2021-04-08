using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mech
{
	public class France : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("France");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 7;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 24, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 20, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 16, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f / 2, 12, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f / 2, 8, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 24, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 20, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f, 16, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f / 2, 12, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
			if (Main.rand.NextFloat() < .2f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 800, Main.rand.Next(-1000, 1001) * 0.001f / 2, 8, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 57;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}