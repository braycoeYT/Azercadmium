using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Empress
{
	public class EmpressShuriken : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Nuclei");
        }
		public override void SetDefaults() {
			projectile.width = 36;
			projectile.height = 36;
			projectile.aiStyle = -1;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 600;
			projectile.penetrate = -1;
			aiType = -1;
		}
		int Timer;
		int rand = Main.rand.Next(48, 241);
		public override void AI() {
			Timer++;
			if (Timer % rand == 0)
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 6, mod.ProjectileType("EggResidue"), projectile.damage + 20, 3, Main.myPlayer);
			if (Timer % 10 == 0) {
				if (Main.rand.NextBool()) 
					projectile.velocity.X += 2;
				else 
					projectile.velocity.X -= 2;
			}
			if (Timer % 10 == 0) {
				if (Main.rand.NextBool())
					projectile.velocity.Y += 2;
				else
					projectile.velocity.Y -= 2;
			}
			projectile.rotation += 1;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 153);
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
	}   
}