using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Underworld
{
	public class HungeringJavelin2 : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hungry");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
				int healNum = Main.rand.Next(1, 4);
				p.statLife += healNum;
				p.HealEffect(healNum, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			Player p = Main.player[projectile.owner];
			int healNum = Main.rand.Next(1, 4);
			p.statLife += healNum;
			p.HealEffect(healNum, true);
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 5);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 4; i++) {
				int dustType = 5;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}