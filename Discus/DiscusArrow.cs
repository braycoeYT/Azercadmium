using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Discus
{
	public class DiscusArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Discus Arrow");
        }
		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.damage = 10;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}