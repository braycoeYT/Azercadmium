using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyBeamBody : ModProjectile
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
					projectile.position.X += 48;
					projectile.position.Y += 16;
				}
				if (projectile.ai[1] == 2) {
					projectile.rotation += MathHelper.ToRadians(90);
					projectile.position.X += 16;
					projectile.position.Y += 48;
				}
				if (projectile.ai[1] == 3) {
					projectile.position.X -= 16;
					projectile.position.Y += 16;
				}

				projectile.ai[0] -= 1;
				if (projectile.ai[0] > 0)
					Projectile.NewProjectile(projectile.position, new Vector2(), ModContent.ProjectileType<JellyBeamBody>(), projectile.damage, projectile.knockBack, Main.myPlayer, projectile.ai[0], projectile.ai[1]);
				else
					Projectile.NewProjectile(projectile.position, new Vector2(), ModContent.ProjectileType<JellyBeamHead>(), projectile.damage, projectile.knockBack, Main.myPlayer, projectile.ai[0], projectile.ai[1]);
				spawn = true;
			}
		}
	}
}