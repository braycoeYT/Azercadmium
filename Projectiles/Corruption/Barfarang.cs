using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Corruption
{
	public class Barfarang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Barfarang");
        }
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
		}
	}   
}