using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
	public class KinoiteCleaverBlade : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ghastly Cleaver");
			Main.projFrames[projectile.type] = 7;
        }
		public override void SetDefaults() {
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			aiType = ProjectileID.Bullet;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 4) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
					projectile.frame = 0;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}