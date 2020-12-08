using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Pumpkin
{
	public class PumpkinSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pumpkin Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 16;
			projectile.height = 16;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ItemID.PumpkinSeed);
		}
	}   
}