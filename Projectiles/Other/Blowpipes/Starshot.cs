using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.Other.Blowpipes
{
	public class Starshot : ModProjectile
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Starshot");
        }

		public override void SetDefaults() 
		{
			projectile.CloneDefaults(ProjectileID.FallingStar);
			projectile.width = 4;
			projectile.height = 4;
			aiType = ProjectileID.FallingStar;
		}

		public override void Kill(int timeLeft) 
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Vector2 center = projectile.Center;
			for (int i = 0; i < 6; i++)
            {
                Gore.NewGore(center, projectile.velocity * -0.2f, Main.rand.Next(16, 18));
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 58);
			}
		}
	}   
}