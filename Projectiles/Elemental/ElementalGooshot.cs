using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Elemental
{
	public class ElementalGooshot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Gooshot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.ShadowFlame, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.OnFire, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.CursedInferno, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.ShadowFlame, 60 * Main.rand.Next(5, 11), false);
			if (Main.rand.NextFloat() < .5f)
				target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .1f) Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Elemental.ElementalGooshot>());
		}
	}   
}