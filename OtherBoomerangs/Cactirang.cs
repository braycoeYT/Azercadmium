using Terraria.ModLoader;

namespace Azercadmium.Projectiles.OtherBoomerangs
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
			projectile.timeLeft = 999;
			projectile.ignoreWater = true;
		}
		public override void AI() {
			projectile.timeLeft = 999;
		}
	}   
}