using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Empress
{
	public class EmpressTear : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Tear");
        }
		public override void SetDefaults() {
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			aiType = -1;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Main.rand.Next(100) == 0) {
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressTear"), projectile.damage - 15, projectile.knockBack, Main.myPlayer);
				projectile.timeLeft = 0;
			}
			projectile.rotation += 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.Confused, 240, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(3) == 0)
				target.AddBuff(BuffID.Confused, 240, false);
		}
	}   
}