using System;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
	public class KinoiteCleaverShard : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kinoite Shard");
        }
		public override void SetDefaults() {
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 180;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
			projectile.rotation = (float)(Math.PI * Main.rand.Next(0, 360)/360);
			projectile.tileCollide = false;
		}
		public override void AI() {
			projectile.rotation += (float)(Math.PI / 2 * 1/45);
		}
		public override void Kill(int timeLeft) {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}