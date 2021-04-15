using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Projectiles.Dungeon
{
	public class SpectreScythe : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spectre Scythe");
			Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.DeathSickle);
			aiType = ProjectileID.DeathSickle;
		}
		public override void PostAI() {
			for (int i = 0; i < 1; i++) {
				int dustType = 180;
				int dustIndex = Dust.NewDust(projectile.position, projectile.width, projectile.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
	}   
}