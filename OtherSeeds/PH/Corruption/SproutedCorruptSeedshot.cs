using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Projectiles.OtherSeeds.PH.Corruption
{
	public class SproutedCorruptSeedshot : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sprouted Corrupt Seedshot");
        }
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Seed);
			aiType = ProjectileID.Seed;
			projectile.width = 14;
			projectile.height = 14;
		}
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("SproutedCorruptSeedshotFall"), 15, 0, Main.myPlayer);
		}
	}   
}