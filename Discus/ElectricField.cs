using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Discus
{
	public class ElectricField : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electric Cube");
        }
		public override void SetDefaults() {
			projectile.width = 160;
			projectile.height = 160;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 100;
			projectile.ignoreWater = true;
			projectile.light = 0.5f;
			projectile.damage = 14;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		bool sound = true;
		public override void AI() {
			if (sound) {
				Main.PlaySound(SoundID.Item12);
				sound = false;
			}
			projectile.position.X = Main.player[projectile.owner].position.X - 80;
			projectile.position.Y = Main.player[projectile.owner].position.Y - 80;
			for (int i = 0; i < 4; i++)
			{
				int dustType = 226;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.Electrified, 75, false);
		}
	}   
}