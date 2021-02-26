using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Crimson
{
	public class Tenderizer : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tenderizer");
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