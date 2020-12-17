using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Dirtball
{
	public class DirtScythe : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirt Scythe");
			Main.projFrames[projectile.type] = 8;
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(44);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 44;
		}
		public override void AI() {
			if (++projectile.frameCounter >= 8) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 8) {
					projectile.frame = 0;
				}
			}
		}
	}   
}