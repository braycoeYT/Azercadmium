using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Ember
{
	public class CracklingBatProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crackling Fire Trail");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 120;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 3 == 0)
			projectile.velocity.Y += 1;
			if (projectile.velocity.Y > 16)
				projectile.velocity.Y = 16;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.velocity *= -0.88f;
			return false;
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}