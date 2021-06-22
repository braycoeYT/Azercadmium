using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Sky
{
	public class AmuletStar : ModProjectile
	{
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Starfury);
			projectile.penetrate = 3;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}