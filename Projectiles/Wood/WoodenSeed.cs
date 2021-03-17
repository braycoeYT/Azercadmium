using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Wood
{
	public class WoodenSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wooden Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Wood.WoodenSeed>());
		}
	}   
}