using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Slime
{
	public class GelShot : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gel Shot");
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Bullet;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(1, 4) * 60, false);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Slimed, Main.rand.Next(1, 4) * 60, false);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}