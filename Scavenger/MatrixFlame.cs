using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Scavenger
{
	public class MatrixFlame : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Flame");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 60;
			projectile.height = 60;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 3600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void AI() {
			Lighting.AddLight(projectile.Center, Color.DarkRed.ToVector3() * 0.75f);
		}
		public override void PostAI() {
			for (int i = 0; i < 5; i++) {
				int dustType = mod.DustType("MatrixScavengerDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}