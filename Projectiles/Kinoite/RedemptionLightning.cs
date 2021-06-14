using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
	public class RedemptionLightning : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lightning");
        }
		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.magic = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ModContent.DustType<Dusts.Kinoite.KinoiteDust>());
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center, new Vector2(0, 0), ModContent.ProjectileType<KinoiteBoltExplosion>(), (int)(projectile.damage * 0.8f), 0, Main.myPlayer);
		}
	}   
}