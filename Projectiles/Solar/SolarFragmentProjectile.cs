using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Solar
{
	public class SolarFragmentProjectile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Solar Fragment");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.penetrate = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Daybreak, 180);
		}
		int Timer;
		public override void AI() {
			Timer++;
			for (int i = 0; i < 2; i++) {
				int dustType = DustID.SolarFlare;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2(0, 0), ProjectileID.SolarWhipSwordExplosion, projectile.damage, 0f, Main.myPlayer, 0f, 0f);
		}
	}   
}