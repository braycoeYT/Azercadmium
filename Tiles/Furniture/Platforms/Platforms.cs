using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Azercadmium.Tiles.Furniture.Platforms
{
    public class Platforms : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoSunLight[Type] = false;
            TileID.Sets.Platforms[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new[] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleMultiplier = 27;
            TileObjectData.newTile.StyleWrapLimit = 27;
            TileObjectData.newTile.UsesCustomCanPlace = false;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
            AddMapEntry(new Color(200, 200, 200));
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Platforms };
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            int num = 0;
            NumDust(i, j, true, ref num);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 0;
            int dustAmount = fail ? 1 : 6;
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 0 * 18)
            {
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Copper);
                }
            }
            else if (tile.frameY == 1 * 18)
            {
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Tin);
                }
            }
            else if (tile.frameY == 8 * 18)
            {
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.Fire);
                }
            }
            else if (tile.frameY == 9 * 18)
            {
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.PinkSlime);
                }
            }
            else if (tile.frameY == 10 * 18)
            {
                for (int k = 0; k < dustAmount; k++)
                {
                    Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.PinkSlime);
                }
            }
        }

        public override bool Drop(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 8 * 18)
            {
                Item.NewItem(new Vector2(i * 16, j * 16), ModContent.ItemType<Items.Ember.CinderCedarPlatform>());
            }
            else if (tile.frameY == 9 * 18)
            {
            }
            else if (tile.frameY == 10 * 18)
            {
                //Item.NewItem(new Vector2(i * 16, j * 16), ModContent.ItemType<EmpressPlatform>());
            }
            return false;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 9 * 18)
            {
                Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, DustID.PinkSlime);
                WorldGen.KillTile(i, j);
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 144)
            {
                Azercadmium.DrawTile(Azercadmium.extraTexture[6], i, j, new Rectangle(tile.frameX, 0, 18, 18), Azercadmium.EmberGladesPulseColor);
                if (tile.frameX == 144 || tile.frameX == 378)
                {
                    Azercadmium.DrawTile(Azercadmium.extraTexture[6], i, j + 1, new Rectangle(162, 0, 18, 18), Azercadmium.EmberGladesPulseColor);
                }
                if (tile.frameX == 180 || tile.frameX == 396)
                {
                    Azercadmium.DrawTile(Azercadmium.extraTexture[6], i, j + 1, new Rectangle(198, 0, 18, 18), Azercadmium.EmberGladesPulseColor);
                }
            }
        }
    }
}