using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Wood
{
	public class SproutedSeedFall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprouted Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.penetrate = -1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 10, 0, 0, mod.ProjectileType("SproutedSapling"), 12, 0, Main.myPlayer);
		}
	}   
}