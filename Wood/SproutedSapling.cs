using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Wood
{
	public class SproutedSapling : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sprouted Sapling");
			Main.projFrames[projectile.type] = 6;
        }
		int frameRand = Main.rand.Next(0, 6);
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 36;
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