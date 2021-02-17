using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Other.Blowpipes
{
	public class Starshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Starshot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.FallingStar);
			aiType = ProjectileID.FallingStar;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}