using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Scavenger
{
	public class MatrixBlastTrailPath : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Blast Trail");
        }
		public override void SetDefaults() {
			projectile.height = 1200;
			projectile.width = 1200;
			projectile.aiStyle = -1;
			projectile.timeLeft = 150;
			projectile.tileCollide = false;
		}
	}   
}