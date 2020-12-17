using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Corruption
{
	public class CorruptSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Corrupt Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.penetrate = 5;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ItemID.CorruptSeeds);
		}
	}   
}