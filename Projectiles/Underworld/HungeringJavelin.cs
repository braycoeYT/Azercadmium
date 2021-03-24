using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Underworld
{
	public class HungeringJavelin : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hungering Javelin");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			//if (Main.rand.NextFloat() < .1f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("HungeringJavelin2"), projectile.damage / 2, 3, Main.myPlayer);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			//if (Main.rand.NextFloat() < .1f)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1, projectile.velocity.Y * -1, mod.ProjectileType("HungeringJavelin2"), projectile.damage / 2, 3, Main.myPlayer);
		}
		public override void PostAI() {
			for (int i = 0; i < 4; i++) {
				int dustType = 5;
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