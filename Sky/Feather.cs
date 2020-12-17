using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Sky
{
	public class Feather : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Feather");
        }
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
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