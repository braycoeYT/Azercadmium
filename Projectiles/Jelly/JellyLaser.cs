using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Jelly
{
	public class JellyLaser : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Water Blast");
		}
		public override void SetDefaults() {
			projectile.CloneDefaults(83);
			projectile.aiStyle = 1;
			aiType = ProjectileID.GreenLaser;
		}
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNpCsAndTiles, List<int> drawCacheProjsBehindNpCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) {
            drawCacheProjsBehindNpCs.Add(index);
        }
	}
}