using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Backgrounds.Microbiome
{
	public class MicrobiomeUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			return Main.LocalPlayer.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome;
		}
		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/MicrobiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/MicrobiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/MicrobiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/MicrobiomeUG3");
		}
	}
}