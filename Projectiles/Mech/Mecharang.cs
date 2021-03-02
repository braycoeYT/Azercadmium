using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Mech
{
	public class Mecharang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mecharang");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.penetrate = 999;
			projectile.timeLeft = 630;
			projectile.ignoreWater = true;
		}
		int Timer;
		public override void AI() {
			Timer++;
			Vector2 velocity2 = projectile.velocity;
			velocity2 *= 2;
			if (Timer % 180 == 1 || Timer % 180 == 31 || Timer % 180 == 61) {
				Main.PlaySound(SoundID.Item12);
				Projectile.NewProjectile(projectile.Center, velocity2, ProjectileID.GreenLaser, projectile.damage, projectile.knockBack / 3, Main.myPlayer);
			}
		}
	}   
}