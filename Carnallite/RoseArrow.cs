using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Carnallite
{
	public class RoseArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rose Arrow");
        }
		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void AI() {
			int dustType = mod.DustType("CarnalliteDust");
			int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 0.35f + Main.rand.Next(-30, 31) * 0.01f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(4) == 0)
			target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(1, 4), false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(4) == 0)
			target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(1, 4), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}