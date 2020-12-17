using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Azercadmium.Projectiles.Underworld
{
	public class PKFireWall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Volcanic Flame");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 20;
			projectile.height = 60;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.rotation = 0;
			//projectile.usesLocalNPCImmunity = true;
			//projectile.localNPCHitCooldown = 10;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.OnFire, Main.rand.Next(2, 5), false);
		}
		public override void AI() {
			for (int i = 0; i < 4; i++) {
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