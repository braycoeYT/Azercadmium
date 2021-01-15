using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Azercadmium.Tiles.Zinc
{
    public class ZincAnvil : ModTile
    {
        public override void SetDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileTable[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);
            dustType = mod.DustType("ZincDust");
            AddMapEntry(new Color(83, 118, 141));
            adjTiles = new int[] { TileID.Anvils };
        }
        public override bool Drop(int i, int j) {
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
            int style2 = t.frameY / 18;
			if (style == 0 && style2 == 0) {
				Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("ZincAnvil"));
			}
			return base.Drop(i, j);
		}
    }
}