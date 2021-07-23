using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyBeamCenter : ModProjectile
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
				for (int i = 0; i < 4; i++) {
					Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2(), ModContent.ProjectileType<JellyBeamBody>(), projectile.damage, 0f, Main.myPlayer, projectile.ai[0], i);
				}
				spawn = true;
			}
		}
	}
}