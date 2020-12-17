using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mech
{
	public class AmazonPackage : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Package");
        }
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 28;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			//projectile.position.Y -= 12;
		}
	}   
}