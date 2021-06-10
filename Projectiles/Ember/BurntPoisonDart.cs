using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Ember
{
	public class BurntPoisonDart : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Burnt Poison Dart");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 18;
			projectile.height = 18;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
			else
				target.AddBuff(BuffID.Poisoned, Main.rand.Next(20, 51) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			if (Main.rand.Next(2) == 0)
				target.AddBuff(BuffID.OnFire, Main.rand.Next(10, 21) * 60, false);
			else
				target.AddBuff(BuffID.Poisoned, Main.rand.Next(20, 51) * 60, false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			if (Main.rand.NextFloat() < .2f) Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Ember.BurntPoisonDart>());
		}
	}   
}