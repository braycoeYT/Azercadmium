using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Azercadmium.Tiles.Ember
{
    public class EmberCrate : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                18
            };
            TileObjectData.newTile.CoordinateWidth = 18;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
            dustType = 259;
            AddMapEntry(new Color(193, 43, 43));
        }
        public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
            int style2 = t.frameY / 18;
			if (style == 0 && style2 == 0)
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Ember.EmberCrate>());
			}
			return base.Drop(i, j);
		}
    }
}