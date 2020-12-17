using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Empress
{
	public class EmpressSpikePassive : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Spike");
        }
		public override void SetDefaults() {
			aiType = ProjectileID.Bullet;
			projectile.width = 21;
			projectile.height = 21;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.penetrate = 5;
		}
	}   
}