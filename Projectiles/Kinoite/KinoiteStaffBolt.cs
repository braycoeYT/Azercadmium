using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
	public class KinoiteStaffBolt : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kinoite Bolt");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 30;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.light = 0.2f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 2;
			aiType = ProjectileID.Bullet;
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 2) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
					projectile.frame = 0;
			}
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
		}
	}   
}