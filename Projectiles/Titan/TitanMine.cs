using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Titan
{
	public class TitanMine : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Mine");
			Main.projFrames[projectile.type] = 2;
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
		public override void AI() {
			if (projectile.timeLeft % 2 == 0 && projectile.timeLeft <= 60) projectile.frame = 1;
			else projectile.frame = 0;
		}
		/*public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(projectile.position, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<TitanMineExplosion>(), 50, 0f, Main.myPlayer);
		}
	}   
}