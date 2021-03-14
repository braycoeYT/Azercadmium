using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Crimson
{
	public class CrimtaneJavelin : ModProjectile
	{
		public override void SetDefaults() { //remember AzercadmiumProjectile
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 4;
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