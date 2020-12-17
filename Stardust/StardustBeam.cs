using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Stardust
{
	public class StardustBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stardust Beam");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Bullet);
			aiType = ProjectileID.Bullet;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 645, projectile.damage, projectile.knockBack, Main.myPlayer);
		}
	}   
}