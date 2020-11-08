using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Solar
{
	public class GloriousSun : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Glorious Sun");
			//3-16 Vanilla, -1 = Infinite
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;
			//130-400 Vanilla
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 375f;
			//9-17.5 Vanilla, for future reference
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
		}
		public override void SetDefaults() {
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 20 == 0)
			Projectile.NewProjectile(projectile.position.X + Main.rand.Next(-150, 151), projectile.position.Y + Main.rand.Next(-150, 151), 0, 0, ProjectileID.SolarWhipSwordExplosion, projectile.damage, 0, Main.myPlayer);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 262);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}
}