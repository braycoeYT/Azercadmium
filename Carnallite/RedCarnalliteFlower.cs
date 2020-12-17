using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Carnallite
{
	public class RedCarnalliteFlower : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Red Carnallite Flower");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			projectile.aiStyle = 0;
			aiType = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.width = 20;
			projectile.height = 20;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("RedCarnalliteDust"));
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
		    target.AddBuff(BuffID.Venom, 60 * Main.rand.Next(1, 4), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Venom, 60 * Main.rand.Next(1, 4), false);
		}
		public override void AI() {
			projectile.rotation += 0.1f;
		}
		public override void Kill(int timeLeft) {
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("RedCarnalliteDust"));
			dust.noGravity = true;
			dust.scale = 1.6f;
		}
	}   
}