using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Scavenger
{
	public class SpaceRemnantShardBlast : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Space Remnant Shard Blast");
        }
		public override void SetDefaults()
		{
			projectile.width = 0;
			projectile.height = 0;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (Timer % 30 == 1) {
				Main.PlaySound(SoundID.Item14.WithVolume(.25f));
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileID.DD2ExplosiveTrapT1Explosion, projectile.damage, 2f, Main.myPlayer);
			}
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}