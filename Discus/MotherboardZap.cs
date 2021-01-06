using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Discus
{
	public class MotherboardZap : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Motherboard Zap");
        }
		public override void SetDefaults() {
			aiType = -1;
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 25;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Electrified, 30);
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 3 == 0)
			for (int i = 0; i < 1; i++) {
				int dustType = DustID.Electric;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}