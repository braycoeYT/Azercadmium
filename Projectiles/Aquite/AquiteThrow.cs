using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Aquite
{
	public class AquiteThrow : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 256f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17f;
		}
		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
	}
}