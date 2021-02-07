using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Empress
{
	public class EmpressGlob : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Glob");
			Main.projFrames[projectile.type] = 5;
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 360;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5)
					projectile.frame = 0;
			}
			for (int i = 0; i < 1; i++) {
				int dustType = 183;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}