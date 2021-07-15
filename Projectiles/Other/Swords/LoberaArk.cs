using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

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
			if (Timer % 5 == 0)
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X + Main.rand.Next(-160, 161), Main.player[projectile.owner].position.Y - 400), projectile.DirectionTo(Main.MouseWorld + new Vector2(0, 400)) * 20f, ModContent.ProjectileType<LoberaTropicalOrb>(), (int)(projectile.damage * 0.6f), projectile.knockBack / 4, Main.myPlayer);
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