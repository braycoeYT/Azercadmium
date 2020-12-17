using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Nova.Twilight
{
	public class Twilight1 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Twilight I");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.penetrate = 9999;
			projectile.timeLeft = 9999;
		}
		int Timer;
		public override void AI() {
			Timer++;
			projectile.timeLeft = 9999;
			if (Timer % 120 == 60) {
				//Main.PlaySound(SoundID.Item12);
				Projectile.NewProjectile(projectile.Center, (projectile.DirectionTo(Main.MouseWorld)) * 10, mod.ProjectileType("TwilightCrystalSmall"), (int)(projectile.damage * 0.75f), 0, Main.myPlayer);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("TwilightDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}