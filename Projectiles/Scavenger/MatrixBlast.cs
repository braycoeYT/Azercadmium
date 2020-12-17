using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Scavenger
{
	public class MatrixBlast : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Blast");
			Main.projFrames[projectile.type] = 7;
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.DeathLaser);
			projectile.height = 30;
			projectile.width = 30;
			projectile.hostile = true;
			projectile.friendly = false;
			aiType = ProjectileID.Bullet;
			projectile.aiStyle = 1;
			projectile.timeLeft = 3000;
			projectile.tileCollide = false;
		}
		int Timer;
		public override void AI() {
			Timer++;
			Lighting.AddLight(projectile.Center, Color.DarkRed.ToVector3() * 0.25f);
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
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