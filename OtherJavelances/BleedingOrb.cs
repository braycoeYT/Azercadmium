using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.OtherJavelances
{
	public class BleedingOrb : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood of the Slaughtered");
        }
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 4;
			projectile.ranged = true;
			projectile.timeLeft = 3000;
			projectile.ignoreWater = true;
			projectile.alpha = 100;
			aiType = 1;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 12);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}