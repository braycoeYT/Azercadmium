using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Titan
{
	public class TitanMineExplosion : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan Mine Explosion");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 50;
			projectile.height = 50;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 120;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void AI() {
			for (int i = 0; i < 10; i++) {
				int dustType = 56;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}