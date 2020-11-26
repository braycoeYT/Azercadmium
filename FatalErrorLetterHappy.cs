using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Azercadmium.Projectiles.CVirus
{
	public class FatalErrorLetterHappy : ModProjectile
	{
		public int[] allowedTypes = {1, 2, 3, 4, 5, 6, 9, 12, 14, 15, 19, 20, 21, 23, 24, 27, 33, 34, 36, 38, 41, 45, 48, 52, 54, 55, 76, 77, 78, 80, 85, 88, 89, 90, 91, 92, 93, 95, 103, 104, 106, 113, 117, 118, 119, 120, 131, 134, 135, 156};
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fatal Error");
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = Main.rand.Next(-1, 600);
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = Main.rand.Next(-1, 16);
		}
		public override void AI()
		{
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.X += 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.X -= 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.Y += 1;
			if (Main.rand.NextFloat() < .5f)
			projectile.velocity.Y -= 1;
			if (Main.rand.NextFloat() < .001f)
			projectile.timeLeft += 60;
			if (Main.rand.NextFloat() < .02f)
			projectile.tileCollide = !projectile.tileCollide;
			if (Main.rand.NextFloat() < .02f)
			projectile.ignoreWater = !projectile.ignoreWater;
			if (Main.rand.NextFloat() < .02f)
			{
			    int rand = Main.rand.Next(allowedTypes.Length);
			    projectile.aiStyle = allowedTypes[rand];
			}
		}
		public override void Kill(int timeLeft)
		{
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetter1"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetter3"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterA"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterB"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterHappy"), projectile.damage, projectile.knockBack, Main.myPlayer);
			if (Main.rand.NextFloat() < .02f)
				Projectile.NewProjectile(projectile.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("FatalErrorLetterZ"), projectile.damage, projectile.knockBack, Main.myPlayer);
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		}
	}   
}