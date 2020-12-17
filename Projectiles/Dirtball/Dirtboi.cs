using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Dirtball
{
	public class Dirtboi : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtboi");
			//Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
			int month = DateTime.Now.Month;
			int day = DateTime.Now.Day;
			if (month == 12 && day > 14)
				Main.projectileTexture[projectile.type] = mod.GetTexture("Projectiles/Dirtball/ChristmasDirtboi");
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
			projectile.width = 28;
			projectile.height = 20;
		}
		public override bool PreAI() {
			return true;
		}
		public override void AI() {
			Player player = Main.player[projectile.owner];
			AzercadmiumPlayer modPlayer = player.GetModPlayer<AzercadmiumPlayer>();
			if (player.dead)
				modPlayer.dirtboi = false;
			if (modPlayer.dirtboi)
				projectile.timeLeft = 2;
		}
	}
}