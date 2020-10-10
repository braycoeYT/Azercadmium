using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles.Furniture.AlternateGold
{
	public class AlternateGoldTable : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Alternate Gold Table");
			AddMapEntry(new Color(231, 178, 28), name);
			dustType = 10;
			disableSmartCursor = true;
			adjTiles = new int[] { TileID.Tables };
		}
		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 48, 32, ItemType<Items.Gold.AlternateGoldTable>());
		}
	}
}