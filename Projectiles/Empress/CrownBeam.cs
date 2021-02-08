using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Empress
{
	public class CrownBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crown Beam");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 30;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 270;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void PostAI() {
			if (Main.rand.Next(3) == 0)
			for (int i = 0; i < 1; i++) {
				int dustType = 57;
				int dustIndex = Dust.NewDust(projectile.position + new Microsoft.Xna.Framework.Vector2(14, 0), projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}