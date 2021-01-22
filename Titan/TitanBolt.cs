using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Titan
{
	public class TitanBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Bolt");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 9999;
			projectile.tileCollide = true;
		}
		int Timer;
		public override void PostAI() {
			Timer++;
			if (Timer % 3 == 0)
			for (int i = 0; i < 1; i++) {
				int dustType = 146;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.75f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}