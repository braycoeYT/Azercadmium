using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtboiTears : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtboi Tears");
        }
		public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			//aiType = ProjectileID.Bullet;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}