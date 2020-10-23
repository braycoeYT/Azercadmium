using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Desert
{
	public class Cactirang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cactirang");
        }
		public override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = 7;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
	}   
}