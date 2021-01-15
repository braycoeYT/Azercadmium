using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Scavenger
{
	public class MatrixBlastFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Blast");
			Main.projFrames[projectile.type] = 7;
        }
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer < 8) projectile.alpha = 255;
			else projectile.alpha = 0;
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 7)
					projectile.frame = 0;
			}
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = mod.DustType("MatrixScavengerDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}