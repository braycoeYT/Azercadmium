using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Wood
{
	public class WoodenSplinter : ModProjectile
	{
		public override void SetDefaults() { //remember AzercadmiumProjectile
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}