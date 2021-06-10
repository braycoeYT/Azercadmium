using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Tiles.Tree
{
    public abstract class AZTree : ModTile
    {
        /// <summary>
        /// Defaults as 5
        /// </summary>
        public int minHeight = 5;

        /// <summary>
        /// Defaults as 20
        /// </summary>
        public int maxHeight = 20;

        /// <summary>
        /// Defaults as 8
        /// </summary>
        public int branchChance = 8;

        public int axePower;

        public string branch;

        public string top;

        public abstract void Drops(int i, int j, int axePower, bool branch);

        private int GetGreatestAxePower(int i, int j)
        {
            Player player = Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)];
            int axe = 0;
            if (player.HeldItem != null)
            {
                if (player.HeldItem.axe > 0)
                {
                    axe = player.HeldItem.axe;
                }
            }
            for (int k = 0; k < Main.maxInventory; k++)
            {
                if (player.inventory[k].axe > axe)
                {
                    axe = player.inventory[k].axe;
                }
            }
            return axe;
        }

        public virtual void ModifyTreeTextures(int i, int j, SpriteBatch spriteBatch, ref string branchTexturePath, ref string topsTexturePath, ref Color drawColor) { }

        public virtual void PostDrawTree(int i, int j, SpriteBatch spriteBatch, string branchTexturePath, string topsTexturePath, Color drawColor, Rectangle drawRectangle, Vector2 offset) { }

        public sealed override void PostSetDefaults() => AZTreeLoader.trees.Add(Type, this);

        public sealed override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak) => false;

        public sealed override bool CanKillTile(int i, int j, ref bool blockDamaged) => GetGreatestAxePower(i, j) >= axePower;

        public sealed override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail || effectOnly)
            {
                return;
            }
            Tile tile = Framing.GetTileSafely(i, j);
            Drops(i, j, GetGreatestAxePower(i, j), false);
            tile.ClearTile();
            if (tile.frameX == 22)
            {
                if (tile.frameY >= 132 && tile.frameY <= 176)
                {
                    return;
                }
            }
            if (tile.frameX == 44)
            {
                if (tile.frameY >= 132 && tile.frameY <= 178)
                {
                    return;
                }
            }
            if (tile.frameX == 66)
            {
                if (tile.frameY >= 0 && tile.frameY <= 44 || tile.frameY >= 198)
                {
                    return;
                }
            }
            if (tile.frameX == 88)
            {
                if (tile.frameY >= 66 && tile.frameY <= 110 || tile.frameY >= 198)
                {
                    return;
                }
            }
            if (Framing.GetTileSafely(i - 1, j).type == Type)
            {
                Drops(i, j - 1, GetGreatestAxePower(i - 1, j), false);
                Framing.GetTileSafely(i - 1, j).ClearTile();
            }
            if (Framing.GetTileSafely(i + 1, j).type == Type)
            {
                Drops(i, j + 1, GetGreatestAxePower(i + 1, j), false);
                Framing.GetTileSafely(i + 1, j).ClearTile();
            }
            for (int k = j - 1; k > 0; k--)
            {
                if (Framing.GetTileSafely(i, k).type == Type)
                {
                    Drops(i, k, GetGreatestAxePower(i, k), false);
                    Framing.GetTileSafely(i, k).ClearTile();
                    if (Framing.GetTileSafely(i - 1, k).type == Type)
                    {
                        Drops(i, k, GetGreatestAxePower(i - 1, k), true);
                        Framing.GetTileSafely(i - 1, k).ClearTile();
                    }
                    if (Framing.GetTileSafely(i + 1, k).type == Type)
                    {
                        Drops(i, k, GetGreatestAxePower(i + 1, k), true);
                        Framing.GetTileSafely(i + 1, k).ClearTile();
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height)
        {
            width = 20;
            offsetY = 0;
            height = 20;
        }

        public static bool GrowTree(int i, int j, AZTree instance)
        {
            // check if the sapling is too high to remove some growing errors I guess
            if (j - instance.maxHeight <= 0)
            {
                return false;
            }
            // Gets a random number for the height
            int height = WorldGen.genRand.Next(instance.minHeight, instance.maxHeight);
            // Changes the number depending on the tiles above it
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < height; l++)
                {
                    Tile tile = Framing.GetTileSafely(i + k - 1, j - l);
                    if (tile.active())
                    {
                        // stop growing if there is a non sapling tile in the way
                        // unless the tile can be cut by weapons. Because we can destroy those without much consequence
                        if (!AZTreeLoader.saplings.Contains(tile.type) && !Main.tileCut[tile.type])
                        {
                            return false;
                        }
                    }
                }
            }
            // Destroys the sapling and removes paint cause these trees don't support paint yet
            Framing.GetTileSafely(i, j).active(active: false);
            Framing.GetTileSafely(i, j - 1).active(active: false);
            Framing.GetTileSafely(i, j).color(color: 0);
            Framing.GetTileSafely(i, j - 1).color(color: 0);
            bool rootLeft = WorldGen.genRand.NextBool();
            if (rootLeft)
            {
                Tile tile = Framing.GetTileSafely(i - 1, j);
                if (tile.active() && Main.tileCut[tile.type])
                {
                    WorldGen.KillTile(i - 1, j);
                }
                if (rootLeft = Framing.GetTileSafely(i - 1, j + 1).active())
                {
                    tile.active(active: true);
                    tile.type = instance.Type;
                    int rand = WorldGen.genRand.Next(3);
                    if (rand == 0)
                    {
                        tile.frameX = 44;
                        tile.frameY = 134;
                    }
                    else if (rand == 1)
                    {
                        tile.frameX = 44;
                        tile.frameY = 156;
                    }
                    else
                    {
                        tile.frameX = 44;
                        tile.frameY = 178;
                    }
                }
            }
            bool rootRight = WorldGen.genRand.NextBool();
            if (rootRight)
            {
                if (Framing.GetTileSafely(i + 1, j).active() && Main.tileCut[Framing.GetTileSafely(i + 1, j).type])
                {
                    WorldGen.KillTile(i + 1, j);
                }
                if (rootRight = Framing.GetTileSafely(i + 1, j + 1).active())
                {
                    Tile tile = Framing.GetTileSafely(i + 1, j);
                    tile.active(active: true);
                    tile.type = (ushort)instance.Type;
                    int rand = WorldGen.genRand.Next(3);
                    if (rand == 0)
                    {
                        tile.frameX = 22;
                        tile.frameY = 132;
                    }
                    else if (rand == 1)
                    {
                        tile.frameX = 22;
                        tile.frameY = 154;
                    }
                    else
                    {
                        tile.frameX = 22;
                        tile.frameY = 176;
                    }
                }
            }

            // Gets the right tile frame for the middle
            Tile tile1 = Framing.GetTileSafely(i, j);
            tile1.active(active: true);
            tile1.type = (ushort)instance.Type;
            int random1 = WorldGen.genRand.Next(3);
            if (rootRight && rootLeft)
            {
                if (random1 == 0)
                {
                    tile1.frameX = 88;
                    tile1.frameY = 132;
                }
                else if (random1 == 1)
                {
                    tile1.frameX = 88;
                    tile1.frameY = 154;
                }
                else
                {
                    tile1.frameX = 88;
                    tile1.frameY = 176;
                }
            }
            else if (rootLeft)
            {
                if (random1 == 0)
                {
                    tile1.frameX = 66;
                    tile1.frameY = 132;
                }
                else if (random1 == 1)
                {
                    tile1.frameX = 66;
                    tile1.frameY = 154;
                }
                else
                {
                    tile1.frameX = 66;
                    tile1.frameY = 176;
                }
            }
            else if (rootRight)
            {
                if (random1 == 0)
                {
                    tile1.frameX = 0;
                    tile1.frameY = 132;
                }
                else if (random1 == 1)
                {
                    tile1.frameX = 0;
                    tile1.frameY = 154;
                }
                else
                {
                    tile1.frameX = 0;
                    tile1.frameY = 176;
                }
            }
            else
            {
                if (random1 == 0)
                {
                    tile1.frameX = 0;
                    tile1.frameY = 0;
                }
                else if (random1 == 1)
                {
                    tile1.frameX = 0;
                    tile1.frameY = 22;
                }
                else
                {
                    tile1.frameX = 0;
                    tile1.frameY = 44;
                }
            }

            // Grows the tree and places branches            
            for (int k = 1; k < height; k++)
            {
                Tile tile = Framing.GetTileSafely(i, j - k);
                if (tile.active() && Main.tileCut[tile.type])
                {
                    WorldGen.KillTile(i, j - k);
                }
                tile.active(active: true);
                tile.type = (ushort)instance.Type;
                bool branchLeft = WorldGen.genRand.NextBool(instance.branchChance) && k != 1 && k != height - 1;
                if (branchLeft)
                {
                    Tile tile2 = Framing.GetTileSafely(i - 1, j - k);
                    if (tile2.active() && Main.tileCut[tile2.type])
                    {
                        WorldGen.KillTile(i - 1, j - k);
                    }
                    int rand = WorldGen.genRand.Next(3);
                    bool rand2 = WorldGen.genRand.NextBool(instance.branchChance);
                    tile2.active(active: true);
                    tile2.type = (ushort)instance.Type;
                    if (rand2)
                    {
                        if (rand == 0)
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 0;
                        }
                        else if (rand == 1)
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 22;
                        }
                        else
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 44;
                        }
                    }
                    else
                    {
                        if (rand == 0)
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 198;
                        }
                        else if (rand == 1)
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 220;
                        }
                        else
                        {
                            tile2.frameX = 66;
                            tile2.frameY = 242;
                        }
                    }
                }
                bool branchRight = WorldGen.genRand.NextBool(instance.branchChance) && k != 1 && k != height - 1;
                if (branchRight)
                {
                    Tile tile2 = Framing.GetTileSafely(i + 1, j - k);
                    if (tile2.active() && Main.tileCut[tile2.type])
                    {
                        WorldGen.KillTile(i + 1, j - k);
                    }
                    int rand = WorldGen.genRand.Next(3);
                    bool rand2 = WorldGen.genRand.NextBool(instance.branchChance);
                    tile2.active(active: true);
                    tile2.type = (ushort)instance.Type;
                    if (rand2)
                    {
                        if (rand == 0)
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 66;
                        }
                        else if (rand == 1)
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 88;
                        }
                        else
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 110;
                        }
                    }
                    else
                    {
                        if (rand == 0)
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 198;
                        }
                        else if (rand == 1)
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 220;
                        }
                        else
                        {
                            tile2.frameX = 88;
                            tile2.frameY = 242;
                        }
                    }
                }
                bool branchBoth = branchLeft && branchRight;
                int random2 = WorldGen.genRand.Next(3);
                if (branchBoth)
                {
                    if (random2 == 0)
                    {
                        tile.frameX = 44;
                        tile.frameY = 0;
                    }
                    else if (random2 == 1)
                    {
                        tile.frameX = 44;
                        tile.frameY = 22;
                    }
                    else
                    {
                        tile.frameX = 44;
                        tile.frameY = 44;
                    }
                }
                else if (branchLeft)
                {
                    if (random2 == 0)
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 88;
                        Framing.GetTileSafely(i, j - k).frameY = 0;
                    }
                    else if (random2 == 1)
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 88;
                        Framing.GetTileSafely(i, j - k).frameY = 22;
                    }
                    else
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 88;
                        Framing.GetTileSafely(i, j - k).frameY = 44;
                    }
                }
                else if (branchRight)
                {
                    if (random2 == 0)
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 66;
                        Framing.GetTileSafely(i, j - k).frameY = 66;
                    }
                    else if (random2 == 1)
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 66;
                        Framing.GetTileSafely(i, j - k).frameY = 88;
                    }
                    else
                    {
                        Framing.GetTileSafely(i, j - k).frameX = 66;
                        Framing.GetTileSafely(i, j - k).frameY = 110;
                    }
                }
                else
                {
                    int rand = WorldGen.genRand.Next(8);
                    if (rand == 0)
                    {
                        if (random2 == 0)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 66;
                        }
                        else if (random2 == 1)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 88;
                        }
                        else
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 110;
                        }
                    }
                    else if (rand == 1)
                    {
                        if (random2 == 0)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 66;
                        }
                        else if (random2 == 1)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 88;
                        }
                        else
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 110;
                        }
                    }
                    else if (rand == 2)
                    {
                        if (random2 == 0)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 0;
                        }
                        else if (random2 == 1)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 22;
                        }
                        else
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 22;
                            Framing.GetTileSafely(i, j - k).frameY = 44;
                        }
                    }
                    else
                    {
                        if (random2 == 0)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 0;
                        }
                        else if (random2 == 1)
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 22;
                        }
                        else
                        {
                            Framing.GetTileSafely(i, j - k).frameX = 0;
                            Framing.GetTileSafely(i, j - k).frameY = 44;
                        }
                    }
                }
            }

            if (Framing.GetTileSafely(i, j - height).active() && Main.tileCut[Framing.GetTileSafely(i, j - height).type])
            {
                WorldGen.KillTile(i, j - height);
            }
            Framing.GetTileSafely(i, j - height).active(active: true);
            Framing.GetTileSafely(i, j - height).type = (ushort)instance.Type;
            // Chance for a broken top
            bool rand3 = WorldGen.genRand.NextBool(15);
            int rand4 = WorldGen.genRand.Next(3);

            if (rand3)
            {
                if (rand4 == 0)
                {
                    Framing.GetTileSafely(i, j - height).frameX = 0;
                    Framing.GetTileSafely(i, j - height).frameY = 198;
                }
                else if (rand4 == 1)
                {
                    Framing.GetTileSafely(i, j - height).frameX = 0;
                    Framing.GetTileSafely(i, j - height).frameY = 220;
                }
                else
                {
                    Framing.GetTileSafely(i, j - height).frameX = 0;
                    Framing.GetTileSafely(i, j - height).frameY = 242;
                }
            }
            else
            {
                if (rand4 == 0)
                {
                    Framing.GetTileSafely(i, j - height).frameX = 22;
                    Framing.GetTileSafely(i, j - height).frameY = 198;
                }
                else if (rand4 == 1)
                {
                    Framing.GetTileSafely(i, j - height).frameX = 22;
                    Framing.GetTileSafely(i, j - height).frameY = 220;
                }
                else
                {
                    Framing.GetTileSafely(i, j - height).frameX = 22;
                    Framing.GetTileSafely(i, j - height).frameY = 242;
                }
            }
            return true;
        }

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            string topTexture = top;
            string branchTexture = branch;
            ModifyTreeTextures(i, j, spriteBatch, ref branchTexture, ref topTexture, ref drawColor);
            Rectangle drawRectangle = new Rectangle(tile.frameX, tile.frameY, 20, 20);
            Vector2 offset = Vector2.Zero;
            if (tile.frameX == 22)
            {
                if (tile.frameY == 198)
                {
                    offset = new Vector2(9f, -24f);
                    drawRectangle = new Rectangle(0, 0, 80, 82);
                    TileGlobal.TileDraw(ModContent.GetTexture(topTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(41, 42), 1f, SpriteEffects.None, 0f, offset);
                }
                else if (tile.frameY == 220)
                {
                    offset = new Vector2(9f, -24f);
                    drawRectangle = new Rectangle(82, 0, 80, 82);
                    TileGlobal.TileDraw(ModContent.GetTexture(topTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(41, 42), 1f, SpriteEffects.None, 0f, offset);
                }
                else if (tile.frameY == 242)
                {
                    offset = new Vector2(9f, -24f);
                    drawRectangle = new Rectangle(164, 0, 80, 82);
                    TileGlobal.TileDraw(ModContent.GetTexture(topTexture), i, j, new Rectangle(164, 0, 80, 82), drawColor, 0f, new Vector2(41, 42), 1f, SpriteEffects.None, 0f, offset);
                }
            }
            if (tile.frameX == 66)
            {
                if (tile.frameY == 198)
                {
                    offset = new Vector2(-3f, 7f);
                    drawRectangle = new Rectangle(0, 0, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
                else if (tile.frameY == 220)
                {
                    offset = new Vector2(-3f, 7f);
                    drawRectangle = new Rectangle(0, 42, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
                else if (tile.frameY == 242)
                {
                    offset = new Vector2(-3f, 7f);
                    drawRectangle = new Rectangle(0, 84, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
            }
            if (tile.frameX == 88)
            {
                if (tile.frameY == 198)
                {
                    offset = new Vector2(21f, 7f);
                    drawRectangle = new Rectangle(42, 0, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
                if (tile.frameY == 220)
                {
                    offset = new Vector2(21f, 7f);
                    drawRectangle = new Rectangle(42, 42, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
                if (tile.frameY == 242)
                {
                    offset = new Vector2(21f, 7f);
                    drawRectangle = new Rectangle(42, 84, 42, 42);
                    TileGlobal.TileDraw(ModContent.GetTexture(branchTexture), i, j, drawRectangle, drawColor, 0f, new Vector2(21, 21), 1f, SpriteEffects.None, 0f, offset);
                }
            }
            PostDrawTree(i, j, spriteBatch, branchTexture, topTexture, drawColor, drawRectangle, offset);
        }
    }
}