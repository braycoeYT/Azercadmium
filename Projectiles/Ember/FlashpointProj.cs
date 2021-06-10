using Azercadmium.Aaa;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Ember
{
	public class FlashpointProj : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ember Spark");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(15);
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 90 == 30) {
				projectile.RotateTowards(Main.MouseWorld, 20f);
				projectile.velocity = new Microsoft.Xna.Framework.Vector2(-20, 0).RotatedBy(projectile.rotation);
			}
		}
	}   
}