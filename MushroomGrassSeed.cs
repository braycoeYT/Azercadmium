using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.GlowingMushroom
{
	public class MushroomGrassSeed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mushroom Grass Seed");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			if (Main.rand.NextFloat() < .2f && target.life > 2) {
				if (target.type != NPCID.TargetDummy) target.life -= 2;
				CombatText.NewText(target.getRect(), Color.DarkGreen, 2);
				if (target.life < 1)
					target.life = 1;
			}
		}
		public override void ModifyHitPvp(Player target, ref int damage, ref bool crit) {
			if (Main.rand.NextFloat() < .2f && target.statLife > 2) {
				target.statLife -= 2;
				CombatText.NewText(target.getRect(), Color.DarkGreen, 2);
				if (target.statLife < 1)
					target.statLife = 1;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextFloat() < .5f) target.AddBuff(mod.BuffType("Shroomed"), Main.rand.Next(1, 5) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.NextFloat() < .5f) target.AddBuff(mod.BuffType("Shroomed"), Main.rand.Next(1, 5) * 60, false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ItemID.MushroomGrassSeeds);
		}
	}   
}