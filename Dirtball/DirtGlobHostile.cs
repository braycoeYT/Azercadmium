using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtGlobHostile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Glob");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
					projectile.frame = 0;
			}
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
	}   
}