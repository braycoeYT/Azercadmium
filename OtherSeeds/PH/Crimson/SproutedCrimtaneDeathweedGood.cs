using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.OtherSeeds.PH.Crimson
{
	public class SproutedCrimtaneDeathweedGood : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Crimtane Deathweed");
			Main.projFrames[projectile.type] = 2;
        }
		public override void SetDefaults()
		{
			aiType = ProjectileID.Bullet;
			projectile.width = 16;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}
		int Timer;
		int frameRand = Main.rand.Next(0, 2);
		public override void AI()
		{
			projectile.rotation = 0;
			Timer++;
			projectile.frameCounter = frameRand;
			projectile.frame = frameRand;
			if (Timer % 30 == 0)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 10, Main.rand.Next(-3, 4), Main.rand.Next(-7, -4), mod.ProjectileType("CrimtaneShard"), Main.rand.Next(5, 11), 0, Main.myPlayer);
		}
		public override void PostAI()
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 125);
			dust.noGravity = true;
			dust.scale = 0.5f;
		}
		public override void Kill(int timeLeft)
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 125);
			dust.noGravity = true;
			dust.scale = 2f;
		}
	}   
}