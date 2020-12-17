using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Scavenger
{
	public class SpacetimeForagerTarget : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spacetime Forager");
			Main.projFrames[projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 40;
			projectile.height = 50;
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
			if (++projectile.frameCounter >= 6) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
					projectile.frame = 0;
			}
		}
	}   
}