using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Azercadmium.Tiles.Ember;

namespace Azercadmium.Tiles.Tree
{
    public class CinderCedarSapling : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18, };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleWrapLimit = 100;
            TileObjectData.newTile.StyleMultiplier = 3;
            TileObjectData.newTile.RandomStyleRange = 3;
            TileObjectData.newTile.AnchorValidTiles = new int[] { TileID.Ash, ModContent.TileType<EmberGrass>() };
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sapling");
            AddMapEntry(new Color(255, 255, 10), name);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Saplings };
            AZTreeLoader.saplings.Add(Type);
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Framing.GetTileSafely(i, j).frameY == 0)
            {
                AZTree.GrowTree(i, j + 1, AZTreeLoader.trees[ModContent.TileType<CinderCedarTree>()]);
                return;
            }
            AZTree.GrowTree(i, j, AZTreeLoader.trees[ModContent.TileType<CinderCedarTree>()]);
       }
    }
}