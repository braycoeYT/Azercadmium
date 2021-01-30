using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Snow
{
	public class IceDippedJavelance : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ice Dipped Javelance");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			AzercadmiumPlayer zp = Main.player[projectile.owner].GetModPlayer<AzercadmiumPlayer>();
			if (zp.bloodVial && Main.rand.NextFloat() < .05f && target.type != NPCID.TargetDummy) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			AzercadmiumPlayer zp = Main.player[projectile.owner].GetModPlayer<AzercadmiumPlayer>();
			if (zp.bloodVial && Main.rand.NextFloat() < .05f) {
				Player p = Main.player[projectile.owner];
				p.statLife += 1;
				p.HealEffect(1, true);
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}