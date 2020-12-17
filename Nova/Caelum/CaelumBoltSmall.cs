using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Nova.Caelum
{
	public class CaelumBoltSmall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Small Caelum Bolt");
        }
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
		}
		public override void AI() {
			int dustType = mod.DustType("CaelumDust");
			int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 4; i++) {
				int dustType = mod.DustType("CaelumDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}