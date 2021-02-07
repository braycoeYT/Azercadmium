using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Empress
{
	public class CarrotPassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Carrot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 16;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Midas, Main.rand.Next(6, 12) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Midas, Main.rand.Next(6, 12) * 60, false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}