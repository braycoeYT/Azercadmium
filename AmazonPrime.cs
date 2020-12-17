using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mech
{
	public class AmazonPrime : ModProjectile
	{
		public override void SetStaticDefaults() {
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			//130-400 Vanilla, 16 is one tile
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 288f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 11.2f;
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
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 120 == 0)
				Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2(0, 1), mod.ProjectileType("AmazonPackageFall"), projectile.damage, 0, Main.myPlayer);
		}
	}
}