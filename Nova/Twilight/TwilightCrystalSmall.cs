using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Nova.Twilight
{
	public class TwilightCrystalSmall : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Small Twilight Crystal");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 15;
			projectile.height = 15;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 9999;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, mod.DustType("TwilightDust"));
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}