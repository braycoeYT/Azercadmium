using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Crimson
{
	public class CrimsonSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crimson Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.penetrate = 4;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ItemID.CrimsonSeeds);
		}
	}   
}