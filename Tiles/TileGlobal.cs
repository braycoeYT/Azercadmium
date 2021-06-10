using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Tiles.Ember;
using Azercadmium.Tiles.Tree;

namespace Azercadmium.Tiles
{
    public class TileGlobal : GlobalTile
    {
        public static Texture bruiseAppleTexture;

        public static void GemFrame(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile top = Main.tile[i, j - 1];
            Tile bottom = Framing.GetTileSafely(i, j + 1);
            Tile left = Main.tile[i - 1, j];
            Tile right = Main.tile[i + 1, j];
            if (top != null && top.active() && !top.bottomSlope() && top.type >= 0 && Main.tileSolid[top.type] && !Main.tileSolidTop[top.type])
            {
                if (tile.frameY < 54 || tile.frameY > 90)
                {
                    tile.frameY = (short)(54 + WorldGen.genRand.Next(3) * 18);
                }
                return;
            }
            if (bottom != null && bottom.active() && !bottom.halfBrick() && !bottom.topSlope() && bottom.type >= 0 && Main.tileSolid[bottom.type] && !Main.tileSolidTop[bottom.type])
            {
                if (tile.frameY < 0 || tile.frameY > 36)
                {
                    tile.frameY = (short)(WorldGen.genRand.Next(3) * 18);
                }
                return;
            }
            if (left != null && left.active() && left.type >= 0 && Main.tileSolid[left.type] && !Main.tileSolidTop[left.type])
            {
                if (tile.frameY < 108 || tile.frameY > 54)
                {
                    tile.frameY = (short)(108 + WorldGen.genRand.Next(3) * 18);
                }
                return;
            }
            if (right != null && right.active() && right.type >= 0 && Main.tileSolid[right.type] && !Main.tileSolidTop[right.type])
            {
                if (tile.frameY < 162 || tile.frameY > 198)
                {
                    tile.frameY = (short)(162 + WorldGen.genRand.Next(3) * 18);
                }
                return;
            }
            WorldGen.KillTile(i, j);
        }

        public static void TileDraw(Texture2D texture, int i, int j, Rectangle? frame, Color color, float rotation = 0f, Vector2 origin = default(Vector2), float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Vector2 offset = default(Vector2))
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero + offset, frame, color, rotation, origin, scale, effects, layerDepth);
        }

        public override void SetDefaults() => Main.tileMerge[TileID.Ash][ModContent.TileType<EmberGrass>()] = true;

        /// <summary>
        /// Attempts to grow a gem at the given tile
        /// </summary>
        /// <param name="i">The x position in tile coordinates</param>
        /// <param name="j">The y position in tile coordinates</param>
        /// <param name="type">What tile to place (Normally is just <see cref="Gems"/>)</param>
        /// <param name="style">The style to place it</param>
        /// <returns></returns>
        public static bool GrowGem(int i, int j, int type, int style = 0)
        {
            int side = WorldGen.genRand.Next(4); // 0 = top | 1 = right | 2 = bottom | 3 = left
            if (side == 0)
            {
                Tile tile = Framing.GetTileSafely(i, j - 1);
                if (!tile.active() || Main.tileCut[tile.type])
                {
                    if (TileLoader.CanPlace(i, j - 1, type))
                    {
                        return WorldGen.PlaceTile(i, j - 1, type, true, false, -1, style);
                    }
                }
                return false;
            }
            if (side == 1)
            {
                Tile tile = Framing.GetTileSafely(i + 1, j);
                if (!tile.active() || Main.tileCut[tile.type])
                {
                    if (TileLoader.CanPlace(i + 1, j, type))
                    {
                        return WorldGen.PlaceTile(i + 1, j, type, true, false, -1, style);
                    }
                }
                return false;
            }
            if (side == 2)
            {
                Tile tile = Framing.GetTileSafely(i, j + 1);
                if (!tile.active() || Main.tileCut[tile.type])
                {
                    if (TileLoader.CanPlace(i, j + 1, type))
                    {
                        return WorldGen.PlaceTile(i, j + 1, type, true, false, -1, style);
                    }
                }
                return false;
            }
            if (side == 3)
            {
                Tile tile = Framing.GetTileSafely(i - 1, j);
                if (!tile.active() || Main.tileCut[tile.type])
                {
                    if (TileLoader.CanPlace(i - 1, j, type))
                    {
                        return WorldGen.PlaceTile(i + 1, j, type, true, false, -1, style);
                    }
                }
                return false;
            }
            return false;
        }

        public override void RandomUpdate(int i, int j, int type)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.wall == WallID.Sandstone || tile.wall == WallID.CorruptSandstone || tile.wall == WallID.CrimsonSandstone || tile.wall == WallID.HallowSandstone)
            {
                if (NPC.downedMoonlord)
                {
                    if (WorldGen.genRand.NextBool(360))
                    {
                        //GrowGem(i, j, ModContent.TileType<Gems>());
                    }
                }
            }
        }

        /*public override bool PreDraw(int i, int j, int type, SpriteBatch spriteBatch)
        {
            Tile below = Framing.GetTileSafely(i, j + 1);
            if (below.type == ModContent.TileType<BruiseAppleTile>()) // Draws the bruised apple so that is can have special layer properties and such
            {
                SpriteEffects effects = i % 2 == 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally; // Every other apple will be flipped horizontally
                Vector2 offset = new Vector2(8, 24); // Offset for the sprite so it can be centered properly
                Azercadmium.DrawTile(Main.tileTexture[below.type], i, j, new Rectangle(below.frameX, 0, 32, 32), Color.Lerp(Lighting.GetColor(i, j), Color.White, 0.5f), 0f, new Vector2(16, 16), 1f, effects, 0f, offset);
                Azercadmium.DrawTile(Main.tileTexture[below.type], i, j, new Rectangle(below.frameX, 32, 32, 32), Azercadmium.EmberGladesPulseColor, 0f, new Vector2(16, 16), 1f, effects, 0f, offset);
            }
            return true;
        }*/

        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile above = Framing.GetTileSafely(i, j - 1);
            if (AZTreeLoader.GetTree(tile) == null)
            {
                return AZTreeLoader.GetTree(i, j - 1) == null;
            }
            return true;
        }

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile aboveTile = Framing.GetTileSafely(i, j - 1);
        }
    }
}