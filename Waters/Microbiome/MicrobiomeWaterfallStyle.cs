using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Waters.Microbiome
{
	public class MicrobiomeWaterfallStyle : ModWaterfallStyle {
		public override void AddLight(int i, int j) =>
			Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), Color.Navy.ToVector3() * 0.5f);
	}
}