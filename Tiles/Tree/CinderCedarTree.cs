using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Items.Ember;

namespace Azercadmium.Tiles.Tree
{
    public class CinderCedarTree : AZTree
    {
        public override void SetDefaults()
        {
            Main.tileAxe[Type] = true;
            Main.tileFrameImportant[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Tree");
            AddMapEntry(Color.Yellow, name);
            disableSmartCursor = true;
            dustType = DustID.Fire;
            adjTiles = new int[] { TileID.Trees };
            axePower = 20;
            top = "Azercadmium/Tiles/Tree/CinderCedarTops";
            branch = "Azercadmium/Tiles/Tree/CinderCedarBranches";
        }
        
        public override void Drops(int i, int j, int axePower, bool branch)
        {
            Item.NewItem(new Vector2(i * 16, j * 16), 16, 16, ModContent.ItemType<CinderCedar>());
            if (Main.netMode != NetmodeID.Server)
            {
                int rand = WorldGen.genRand.Next(2, 12);
                for (int k = 0; k < rand; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, dustType);
                }
            }
            if (branch)
            {
                if (WorldGen.genRand.NextBool())
                {
                    Item.NewItem(new Vector2(i * 16, j * 16), 16, 16, ModContent.ItemType<HellfireAcorn>());
                }
            }
        }

        public override void PostDrawTree(int i, int j, SpriteBatch spriteBatch, string branchTexturePath, string topsTexturePath, Color drawColor, Rectangle drawRectangle, Vector2 offset)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameX == 22)
            {
                drawColor = Azercadmium.EmberGladesPulseColor;
                if (tile.frameY == 198 || tile.frameY == 220 || tile.frameY == 242)
                {
                    TileGlobal.TileDraw(ModContent.GetTexture(topsTexturePath + "Glow"), i, j, drawRectangle, drawColor, 0f, new Vector2(41, 42), 1f, SpriteEffects.None, 0f, offset);
                }
            }
            if (tile.frameX == 66 || tile.frameX == 88)
            {
                drawColor = Azercadmium.EmberGladesPulseColor;
                if (tile.frameY == 198 || tile.frameY == 220 || tile.frameY == 242)
                {
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexturePath + "Glow"), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
            }
        }
    }
}