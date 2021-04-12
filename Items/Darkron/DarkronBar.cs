using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Darkron
{
	public class DarkronBar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Filled with malice");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.LightRed;
			item.width = 30;
			item.height = 26;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("DarkronBar");
			item.placeStyle = 0;
		}
	}
}