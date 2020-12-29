using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Dirtball
{
    public class Dirtboi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dirtboi");
            Main.projFrames[projectile.type] = 2;
            Main.projPet[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            aiType = ProjectileID.ZephyrFish;
            projectile.width = 28;
            projectile.height = 20;

            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            if (month == 12 && day > 14)
                projectile.frame = 1;
        }
        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false;
            projectile.frameCounter = 0;
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            AzercadmiumPlayer modPlayer = player.GetModPlayer<AzercadmiumPlayer>();
            if (player.dead)
                modPlayer.dirtboi = false;
            if (modPlayer.dirtboi)
                projectile.timeLeft = 2;
        }
    }
}