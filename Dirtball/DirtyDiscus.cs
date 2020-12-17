using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtyDiscus : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirty Discus");
        }
		public override void SetDefaults() {
			projectile.width = 25;
			projectile.height = 25;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 8;
			projectile.melee = true;
			projectile.timeLeft = 360;
			projectile.ignoreWater = false;
		}
	}   
}