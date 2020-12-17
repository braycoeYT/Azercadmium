using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Corruption
{
	public class SproutedCorruptSeedshotGood : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprouted Corrupt Seedshot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 14;
			projectile.height = 14;
		}
		public override void Kill(int timeLeft) {
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 14);
			dust.noGravity = true;
			dust.scale = 2f;
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("SproutedCorruptSeedshotGoodFall"), 15, 0, Main.myPlayer);
		}
		public override void PostAI() {
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 14);
			dust.noGravity = true;
			dust.scale = 1f;
		}
	}   
}