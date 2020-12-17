using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Crimson
{
	public class UnethicalArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Unethical Arrow");
        }
		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.ranged = true;
			projectile.damage = 14;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .25f) Item.NewItem(projectile.getRect(), mod.ItemType("UnethicalArrow"));
		}
	}   
}