using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyBeamX : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Beam");
		}
		public override void SetDefaults() {
			projectile.width = 1600;
			projectile.height = 64;
			projectile.alpha = 127;
			projectile.hostile = false;
			projectile.friendly = false;
			projectile.timeLeft = 120;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer > 79) {
				projectile.hostile = true;
				projectile.damage = 20;
				if (Main.expertMode) projectile.damage = 35;
				projectile.alpha = 0;
			}
		}
	}
}