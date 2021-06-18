using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Slime
{
	public class SlimeArrow : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slime Arrow");
        }
		public override void SetDefaults() {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.damage = 7;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			aiType = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Slimed, 300, false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			//if (Main.rand.NextFloat() < .25f) Item.NewItem(projectile.getRect(), ModContent.ItemType<Items.Slime.SlimeArrow>());
		}
	}   
}