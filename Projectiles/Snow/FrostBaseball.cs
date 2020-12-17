using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Snow
{
	public class FrostBaseball : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Frost Baseball");
        }
		public override void SetDefaults() {
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
		    target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 5), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 5), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}