using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Braycoe
{
	public class BraycoeSlime : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Braycoe's Slime");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.EyeSpring);
			aiType = ProjectileID.EyeSpring;
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
				modPlayer.BraycoeSlimePet = false;
			if (modPlayer.BraycoeSlimePet)
				projectile.timeLeft = 2;
		}
	}
}