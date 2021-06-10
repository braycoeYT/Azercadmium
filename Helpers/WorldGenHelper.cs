using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Azercadmium.WorldGeneration;
using Azercadmium.Aaa;

namespace Azercadmium.Helpers
{
    public static class WorldGenHelper
    {
        public static Tile GetTileVerySafely(int i, int j)
        {
            i = Utils.Clamp(i, 0, Main.maxTilesX);
            j = Utils.Clamp(j, 0, Main.maxTilesY);
            return Framing.GetTileSafely(i, j);
        }

        public static void PlaceTile(int i, int j, int newType, int slope = -1, bool forced = true, bool mute = false, int plr = -1, bool net = false, int style = 0, byte liquid = 0)
        {
            Tile tile = Main.tile[i, j];
            WorldGen.PlaceTile(i, j, newType, mute, forced, plr, style);
            if (slope >= 0)
            {
                tile.slope(slope: (byte)slope);
            }
            if (liquid >= 0)
            {
                tile.liquid = liquid;
            }
            if (net)
            {
            }
        }

        public static void SmoothenOutGenTiles(int _i = -1, int _j = -1)
        {
            ushort genTileType = (ushort)ModContent.TileType<GenTile>();
            if (_i == -1 && _j == -1)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        Tile tile = Framing.GetTileSafely(i, j);
                        bool flag1 = false;
                        bool flag2;
                        bool flag3 = false;
                        bool flag4;
                        if (tile.type == genTileType)
                        {
                            if (j > 0)
                            {
                                Tile aboveTile = Framing.GetTileSafely(i, j - 1);
                                flag1 = aboveTile.active();
                                if (flag1)
                                {
                                    tile.ResetToType(genTileType);
                                }
                                else
                                {
                                }
                            }
                            Tile belowTile = Framing.GetTileSafely(i, j + 1);
                            flag2 = belowTile.active();
                            if (flag2)
                            {
                            }
                            else
                            {
                            }
                            if (i > 0)
                            {
                                Tile leftTile = Framing.GetTileSafely(i - 1, j);
                                flag3 = leftTile.active();
                                if (flag3)
                                {
                                }
                            }
                            Tile rightTile = Framing.GetTileSafely(i + 1, j);
                            flag4 = rightTile.active();
                            if (flag4)
                            {
                            }
                            bool flag5 = flag1 && flag2 && flag3 && flag4;
                            bool flag6 = !flag1 && !flag2 && !flag3 && !flag4;
                            if (flag5)
                            {
                                tile.ResetToType(genTileType);
                                tile.active(true);
                            }
                            if (flag6)
                            {
                                WorldGen.KillTile(i, j, false, false, true);
                            }
                        }
                    }
                }
            }
            else
            {

            }
        }

        public static void ReplaceGenTiles(ushort type)
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.type == ModContent.TileType<GenTile>())
                    {
                        tile.type = type;
                    }
                }
            }
        }

        public static Tile[] SafelyGetNearbyTileArray(int i, int j)
        {
            return new Tile[]
            {
                Framing.GetTileSafely(i + 1, j),
                Framing.GetTileSafely(i - 1, j),
                Framing.GetTileSafely(i, j + 1),
                Framing.GetTileSafely(i, j - 1),
            };
        }

        public static Tile[] SafelyGetNearbyTileArray2(int i, int j)
        {
            return new Tile[]
            {
                Framing.GetTileSafely(i + 1, j + 1),
                Framing.GetTileSafely(i + 1, j - 1),
                Framing.GetTileSafely(i - 1, j + 1),
                Framing.GetTileSafely(i - 1, j - 1),
            };
        }

        public static List<Tile> SafelyGetNearbyTileList(int i, int j)
        {
            return new List<Tile>
            {
                Framing.GetTileSafely(i + 1, j),
                Framing.GetTileSafely(i - 1, j),
                Framing.GetTileSafely(i, j + 1),
                Framing.GetTileSafely(i, j - 1),
            };
        }

        public static void RemoveWater(this Tile tile)
        {
            tile.liquid = 0;
            tile.liquidType(0);
            tile.checkingLiquid(checkingLiquid: false);
        }
    }
}