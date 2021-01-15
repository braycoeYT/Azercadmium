using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Desert
{
	public class DesertSigil : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Sigil");
        }
		public override void SetDefaults() {
			projectile.width = 28;
			projectile.height = 28;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}