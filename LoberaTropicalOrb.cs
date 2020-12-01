using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Other.Swords
{
	public class LoberaTropicalOrb : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tropical Orb");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("LoberaDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.boss == false)
		    target.AddBuff(mod.BuffType("LoberaSoulslash"), 60 * Main.rand.Next(1, 4), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("LoberaSoulslash"), 60 * Main.rand.Next(1, 4), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 4; i++) {
				int dustType = mod.DustType("LoberaDust");
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1.25f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}