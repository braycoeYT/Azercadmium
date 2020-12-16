using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Scavenger
{
	public class MatrixScavengerTarget : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Scavenger");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 80;
			projectile.height = 70;
			projectile.aiStyle = 0;
			projectile.hostile = false;
			projectile.friendly = false;
			if (Main.expertMode)
				projectile.timeLeft = 45;
			else
				projectile.timeLeft = 60;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0f;
			projectile.damage = 0;
			projectile.alpha = 100;
		}
		public override void AI() {
			Lighting.AddLight(projectile.Center, Color.DarkGoldenrod.ToVector3() * 0.5f);
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 3)
					projectile.frame = 0;
			}
		}
	}   
}