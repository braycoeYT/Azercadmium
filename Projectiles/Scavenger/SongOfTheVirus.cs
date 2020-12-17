using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Scavenger
{
	public class SongOfTheVirus : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Song of the Virus");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(575);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.width = 64;
			projectile.height = 64;
			projectile.timeLeft = 180;
			aiType = 575;
		}
		/*public override void AI()
		{
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
		}*/
	}   
}