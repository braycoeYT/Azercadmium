using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jungle
{
	public class VinelacedBaseball : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Vinelaced Baseball");
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
		    target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(4, 11), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Poisoned, 60 * Main.rand.Next(4, 11), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}