using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Jungle
{
	public class Snarevine : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Snarevine");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 6;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(BuffID.Poisoned, Main.rand.Next(4, 7) * 60, false);
			AzercadmiumPlayer zp = Main.player[projectile.owner].GetModPlayer<AzercadmiumPlayer>();
			if (zp.bloodJavelance && Main.rand.NextFloat() < .06f && target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(2) == 0)
		    target.AddBuff(BuffID.Poisoned, Main.rand.Next(4, 7) * 60, false);
			AzercadmiumPlayer zp = Main.player[projectile.owner].GetModPlayer<AzercadmiumPlayer>();
			if (zp.bloodJavelance && Main.rand.NextFloat() < .06f) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 193);
				dust.noGravity = false;
				dust.scale = 0.8f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}