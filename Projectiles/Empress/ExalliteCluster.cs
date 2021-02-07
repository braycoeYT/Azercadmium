using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Empress
{
	public class ExalliteCluster : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Exallite Cluster");
        }
		public override void SetDefaults() {
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
			projectile.melee = true;
		}
		public override void PostAI() {
			projectile.rotation = 0f;
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 80);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void Kill(int timeLeft) {
			if (timeLeft > 0) {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 16, 0, 0, mod.ProjectileType("ExalliteClusterStick"), projectile.damage, projectile.knockBack, Main.myPlayer);
			}
		}
	}   
}