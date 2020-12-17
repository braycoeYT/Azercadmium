using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Slime
{
	public class PinkySeedshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pinky Seedshot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 12;
			projectile.height = 12;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .75f)
				target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 5) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .75f)
				target.AddBuff(BuffID.Slimed, Main.rand.Next(2, 5) * 60, false);
		}
	}   
}