using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Projectiles.Goblins
{
	public class ChaosBallShardFriendly : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chaos Ball Shard");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			projectile.penetrate = 3;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 27;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}