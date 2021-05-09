using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Lihzahrd
{
	public class LihzahrdBeam : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lihzahrd Beam");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.timeLeft = 9999;
		}
		public override void AI() {
			for (int i = 0; i < 2; i++) {
				int dustType = 169;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}