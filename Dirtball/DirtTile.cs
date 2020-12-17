using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtTile : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Falling Dirt Ball");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.friendly = false;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
		public override void AI() {
			projectile.rotation += 0.05f;
		}
	}   
}