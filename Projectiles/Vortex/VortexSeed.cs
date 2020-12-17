using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Vortex
{
	public class VortexSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Vortex Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Bullet;
			projectile.aiStyle = ProjectileID.Bullet;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}