using Terraria.ID;
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
			projectile.CloneDefaults(ProjectileID.HarpyFeather);
			projectile.hostile = false;
			projectile.friendly = true;
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 5; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 116);
				dust.noGravity = false;
				dust.scale = 1f;
			}
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}