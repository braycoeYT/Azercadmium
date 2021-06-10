using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Ember
{
	public class FieryFlare : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fiery Flare");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Flare);
		}
		bool hasSpawned;
		public override bool OnTileCollide(Vector2 oldVelocity) {
			if (!hasSpawned) {
				hasSpawned = true;
				Projectile.NewProjectile(projectile.position - new Vector2(0, 20), new Vector2(0, 0), ModContent.ProjectileType<FieryFlareWall>(), projectile.damage, 0f, Main.myPlayer);
			}
			return true;
		}
	}   
}