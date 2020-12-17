using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Corruption
{
	public class ShadowdanceOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Shadowdance Orb");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 2;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.damage = 25;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}