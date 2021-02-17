using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Underworld
{
	public class MoltenSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Molten Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .8f)
		    target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 11) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .8f)
				target.AddBuff(BuffID.OnFire, Main.rand.Next(4, 11) * 60, false);
		}
	}   
}