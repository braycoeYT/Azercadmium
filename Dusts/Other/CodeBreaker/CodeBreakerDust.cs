using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Dusts.Other.CodeBreaker
{
	public class CodeBreakerDust : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noLight = true;
			dust.color = new Color(61, 148, 48);
			dust.scale = 2f;
			dust.noGravity = true;
			dust.velocity /= 2f;
			dust.alpha = 100;
		}
		public override bool Update(Dust dust) {
			dust.position += dust.velocity;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0.061f, 0.148f, 0.048f);
			dust.scale -= 0.03f;
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false;
		}
	}
}