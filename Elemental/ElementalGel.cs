using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;

namespace Azercadmium.Items.Elemental
{
	public class ElementalGel : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("I'm pretty sure this is what you get after mixing every flavor of gelatin together");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 8));
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 0, 50);
			item.rare = ItemRarityID.Lime;
		}
	}
}