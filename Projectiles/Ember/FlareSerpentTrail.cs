using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Ember
{
	public class FlareSerpentTrail : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flame Trail");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 90;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 6) * 60);
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 127;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}