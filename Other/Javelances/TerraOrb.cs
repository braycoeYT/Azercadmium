using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Other.Javelances
{
	public class TerraOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Terra Orb");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 4;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}