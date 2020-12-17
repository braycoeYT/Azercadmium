using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Empress
{
	public class Yolk : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Yolk");
        }
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.ranged = true;
			projectile.timeLeft = 20;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(5) == 0)
			target.AddBuff(BuffID.Poisoned, 150, false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.Next(5) == 0)
			target.AddBuff(BuffID.Poisoned, 150, false);
		}
	}   
}