using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyLaserWarning : ModProjectile
	{
		public override void SetDefaults() {
			projectile.CloneDefaults(83);
			projectile.alpha = 127;
			projectile.hostile = false;
			projectile.timeLeft = 60;
		}
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(projectile.position - (projectile.velocity*-projectile.timeLeft), projectile.velocity, ModContent.ProjectileType<JellyLaser>(), projectile.damage, projectile.knockBack, Main.myPlayer);
		}
	}
}