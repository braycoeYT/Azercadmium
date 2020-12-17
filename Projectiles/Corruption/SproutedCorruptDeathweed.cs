using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Corruption
{
	public class SproutedCorruptDeathweed : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprouted Corrupt Deathweed");
			Main.projFrames[projectile.type] = 2;
        }
		int frameRand = Main.rand.Next(0, 2);
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.rotation = 0;
			projectile.frameCounter = frameRand;
			projectile.frame = frameRand;
		}
	}   
}