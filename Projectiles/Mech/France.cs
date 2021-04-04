using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Mech
{
	public class France : ModProjectile
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("France");
        }

		public override void SetDefaults() 
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 7;
			projectile.ranged = true;
			projectile.timeLeft = 9999;
			projectile.ignoreWater = true;
			aiType = 1;
		}

		public void OnHit()
        {
			int amount = Main.rand.Next(5) + 1;
			for (int i = 0; i < amount; i++)
            {
				int p = Projectile.NewProjectile(projectile.Center.X + Main.rand.NextFloat(-24, 24), projectile.Center.Y - 800, Main.rand.NextFloat(-8f, 8f), 24f, ProjectileID.HallowStar, (int)(projectile.damage * 0.8f), projectile.knockBack / 2, Main.myPlayer);
				Main.projectile[p].penetrate = 1;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) 
		{
			OnHit();
		}

		public override void OnHitPlayer(Player target, int damage, bool crit) 
		{
			OnHit();
		}

		public override void PostAI() 
		{
			for (int i = 0; i < 1; i++) 
			{
				int d = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57);
				Main.dust[d].velocity.X *= 0.01f;
				Main.dust[d].velocity.Y *= 0.01f;
				Main.dust[d].scale *= 1f + Main.rand.NextFloat(-0.6f, 0.3f);
			}
		}

		public override void Kill(int timeLeft) 
		{
			Main.PlaySound(SoundID.Dig, projectile.position);
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}