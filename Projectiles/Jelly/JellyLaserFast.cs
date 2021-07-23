using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyLaserFast : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Blast");
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(83);
			projectile.aiStyle = 1;
			aiType = ProjectileID.GreenLaser;
			projectile.timeLeft += 240;
		}
		bool bool1;
		public override void AI() {
			if (!bool1) {
				projectile.position += projectile.velocity*250f;
				bool1 = true;
			}
			projectile.velocity *= 1.006f;
		}
	}
}