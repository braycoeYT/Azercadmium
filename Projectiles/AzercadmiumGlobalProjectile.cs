using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles
{
	public class AzercadmiumGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true;
		bool init;
		public override void AI(Projectile projectile) {
			if (!init) {
				Player player = Main.player[projectile.owner];
				AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
				if (Azercadmium.JavelinCache[projectile.type])
					projectile.penetrate += p.javelinPenetration;
				init = true;
			}
		}
	}
}