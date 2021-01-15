using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Zinc
{
	public class ZincOre : ModItem
	{
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Zinc.ZincOre>();
			item.width = 16;
			item.height = 16;
			item.value = Item.sellPrice(0, 0, 1, 60);
			item.rare = ItemRarityID.White;
		}
	}
}