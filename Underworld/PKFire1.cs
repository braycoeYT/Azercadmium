using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Underworld
{
	public class PKFire1 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Volcanic Flame");
        }
		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 15;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6), false);
		}
		public override void AI() {
			for (int i = 0; i < 4; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 12, mod.ProjectileType("PKFire2"), projectile.damage, projectile.knockBack, Main.myPlayer);
			for (int i = 0; i < 4; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}