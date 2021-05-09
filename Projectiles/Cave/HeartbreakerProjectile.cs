using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Cave
{
	public class HeartbreakerProjectile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Life Crystal");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults() {
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 9999;
			projectile.penetrate = 5;
			projectile.ignoreWater = true;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
					projectile.frame = 0;
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 12);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void Kill(int timeLeft) {
			Main.PlaySound(SoundID.Shatter);
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 12);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}