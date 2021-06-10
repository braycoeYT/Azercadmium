using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Ember
{
	public class CharredChakram : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Charred Chakram");
        }
		public override void SetDefaults() {
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(4) == 0) {
				if (Main.rand.Next(2) == 0)
					target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 11) * 60, false);
				else
					target.AddBuff(BuffID.Poisoned, Main.rand.Next(6, 13) * 60, false);
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(4) == 0) {
				if (Main.rand.Next(2) == 0)
					target.AddBuff(BuffID.OnFire, Main.rand.Next(5, 11) * 60, false);
				else
					target.AddBuff(BuffID.Poisoned, Main.rand.Next(6, 13) * 60, false);
			}
		}
	}   
}