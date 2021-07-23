using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyBit : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Bit");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.width = 14;
			projectile.height = 14;
		}
		public override void AI() {
			int frameSpeed = 3;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed) {
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type]) {
					projectile.frame = 0;
				}
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}