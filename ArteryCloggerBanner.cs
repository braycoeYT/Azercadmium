using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Crimson.Banners
{
	public class ArteryCloggerBanner : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.createTile = TileType<Tiles.Banners.MonsterBanner>();
			item.placeStyle = 2; //which frame horizontally
		}
	}
}