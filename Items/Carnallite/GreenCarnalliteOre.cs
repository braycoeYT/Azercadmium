using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Azercadmium.Items.Carnallite
{
	public class GreenCarnalliteOre : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It pulsates very slowly with a circadian rhythm (and it is so mesmerizing someone happened to notice this)");
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Carnallite.GreenCarnalliteOre>();
			item.width = 16;
			item.height = 16;
			item.value = Item.sellPrice(0, 0, 9, 0);
			item.rare = ItemRarityID.Blue;
		}
	}
}