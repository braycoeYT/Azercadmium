using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Cave
{
	public class Batball : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Batball");
			Main.projFrames[projectile.type] = 2;
        }
		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
					projectile.frame = 0;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
		    target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(4, 9), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Confused, 60 * Main.rand.Next(4, 9), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}