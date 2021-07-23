using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Jelly
{
	public class SharpenedFang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sharpened Fang");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Stake);
			projectile.scale = 1.6f;
			aiType = ProjectileID.Stake;
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Bleeding, 60*Main.rand.Next(8, 17));
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Bleeding, 60*Main.rand.Next(8, 17));
		}
		public override void Kill(int timeLeft) {
			for (int i = 0; i < 6; i++)
			Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)(projectile.velocity.X*Main.rand.NextFloat(-0.8f, -1.2f)), (float)(projectile.velocity.Y*Main.rand.NextFloat(-0.8f, -1.2f)));
		}
	}   
}