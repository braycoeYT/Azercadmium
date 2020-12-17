using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Christmas
{
	public class Pinecone : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pinecone");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 24;
			projectile.height = 24;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), mod.ItemType("Pinecone"));
		}
	}   
}