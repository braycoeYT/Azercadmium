using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace Azercadmium.Projectiles.Titan
{
	public class TitansEnergizer : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Energizer");
        }
		public override void SetDefaults() {
			//aiType = ProjectileID.Bullet;
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.timeLeft = 3;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 0.3f;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 1;
		}
		public override void PostAI() {
			for (int i = 0; i < 4; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AI() {
			projectile.position = Main.MouseWorld;
		}
	}   
}