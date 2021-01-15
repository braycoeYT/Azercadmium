using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Azercadmium.Items.Aquite
{
	public class AquiteOre : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("From the oceanic depths, materialized from oceanic fossils and microbes");
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 9999;
			item.consumable = true;
			item.createTile = TileType<Tiles.Aquite.AquiteOre>();
			item.width = 16;
			item.height = 16;
			item.value = Item.sellPrice(0, 0, 18, 0);
			item.rare = ItemRarityID.Cyan;
		}
	}
}