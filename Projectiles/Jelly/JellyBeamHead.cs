using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyBeamHead : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jelly Beam");
		}
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 120;
		}
		bool spawn;
		public override void AI() {
			if (!spawn) {
				if (projectile.ai[1] == 0) {
					projectile.rotation += MathHelper.ToRadians(90);
					projectile.position.X += 16;
					projectile.position.Y -= 16;
				}
				if (projectile.ai[1] == 1) {
					projectile.rotation += MathHelper.ToRadians(180);
					projectile.position.X += 48;
					projectile.position.Y += 16;
				}
				if (projectile.ai[1] == 2) {
					projectile.rotation += MathHelper.ToRadians(270);
					projectile.position.X += 16;
					projectile.position.Y += 48;
				}
				if (projectile.ai[1] == 3) {
					projectile.position.X -= 16;
					projectile.position.Y += 16;
				}
				spawn = true;
			}
		}
	}
}