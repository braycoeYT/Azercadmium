using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Tin
{
	public class TinYoyo : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 3.25f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 138f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 9.25f;
		}
		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
	}
}