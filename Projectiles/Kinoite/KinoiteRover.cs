using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Kinoite
{
    public class KinoiteRover : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Kinoite Rover");
            Main.projFrames[projectile.type] = 9;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            projectile.width = 28;
            projectile.height = 20;
        }
        public override bool PreAI() {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false;
            return true;
        }
        public override void AI() {
            Main.player[projectile.owner].accCritterGuide = true;
            Player player = Main.player[projectile.owner];
            AzercadmiumPlayer modPlayer = player.GetModPlayer<AzercadmiumPlayer>();
            if (player.dead)
                modPlayer.KinoiteRover = false;
            if (modPlayer.KinoiteRover)
                projectile.timeLeft = 2;
            else
                Main.player[projectile.owner].accCritterGuide = false;
            if (++projectile.frameCounter >= 20) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 9)
					projectile.frame = 0;
			}
        }
    }
}