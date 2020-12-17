using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Other.Swords
{
	public class LoberaArk : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lobera");
			Main.projFrames[projectile.type] = 28;
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Arkhalis);
			aiType = ProjectileID.Arkhalis;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 60 == 10)
				Projectile.NewProjectile(projectile.Center, projectile.DirectionTo(Main.MouseWorld) * 10, mod.ProjectileType("LoberaTropicalOrb"), projectile.damage, 1.5f, Main.myPlayer);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.boss == false)
		    target.AddBuff(mod.BuffType("LoberaSoulslash"), 60 * Main.rand.Next(2, 8), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("LoberaSoulslash"), 60 * Main.rand.Next(2, 8), false);
		}
	}   
}