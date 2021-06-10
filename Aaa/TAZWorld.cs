using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Azercadmium.Aaa;
using Azercadmium.Biomes;
using Azercadmium.Items;
using Azercadmium.Systems;
using Azercadmium.Tiles;
using Azercadmium.Tiles.Chests;
using Azercadmium.Tiles.Ember;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Aaa
{
    public class TAZWorld : ModWorld
    {
        public const int hellLayerOffset = 200;

        public static bool DungeonLeft => Main.dungeonX < Main.maxTilesX / 2;

        public static int UnderworldY => Main.maxTilesY - hellLayerOffset;

        public static int emberGladesTileCount;

        public static int microbiomeTileCount;

        public static bool downedDirtball;

        public static bool downedTitan;

        public static bool downedScavenger;

        public static bool downedEmpress;

        public static bool downedHemi;

        public static bool downedAncy;

        public static bool devastation;

        public static bool emberThorns;

        public static bool aquite;

        public static bool jade;

        public static int EmberGladesBiomePointX;

        public static int EmberGladesBiomePointY;

        public static Point EmberGladesBiomePoint { get; set; }

        public static int EmberGladesBiomeX;

        public static int EmberGladesBiomeY;

        public static int EmberGladesBiomeWidth;

        public static int EmberGladesBiomeHeight;  

        public static Rectangle EmberGladesBiome { get; set; }
        //Parasitic Start
        public static int ParasiticBiomePointX;

        public static int ParasiticBiomePointY;
        public static Point ParasiticBiomePoint { get; set; }

        public static int ParasiticBiomeX;

        public static int ParasiticBiomeY;

        public static int ParasiticBiomeWidth;

        public static int ParasiticBiomeHeight;
        public static Rectangle ParasiticBiome { get; set; }
        //Evil Lake Start
        public static int EvilLakeBiomeX;

        public static int EvilLakeBiomeY;

        public static int EvilLakeBiomeWidth;

        public static int EvilLakeBiomeHeight;

        public static Rectangle EvilLakeBiome;

        public static Point JungleLeft;

        public static Point JungleRight;

        public static Point EvilLeft;

        public static Point EvilRight;

        private Point SnowLeft;

        private Point SnowRight;

        private int genTile;

        private int chestTile;

        public override void Initialize()
        {
            Azercadmium.specialTileDrawPoints.Clear();
            genTile = ModContent.TileType<GenTile>();
            chestTile = ModContent.TileType<Containers>();
            devastation = false;

            downedDirtball = false;
            downedAncy = false;
            downedEmpress = false;
            downedHemi = false;
            downedScavenger = false;
            downedTitan = false;

            emberThorns = false;
            aquite = false;
            jade = false;

            EmberGladesBiomePointX = -1;
            EmberGladesBiomePointY = -1;
            EmberGladesBiomePoint = new Point(-1, -1);
            EmberGladesBiomeX = -1;
            EmberGladesBiomeY = -1;
            EmberGladesBiomeWidth = -1;
            EmberGladesBiomeHeight = -1;
            EmberGladesBiome = new Rectangle(-1, -1, -1, -1);

            ParasiticBiomePointX = -1;
            ParasiticBiomePointY = -1;
            ParasiticBiomePoint = new Point(-1, -1);
            ParasiticBiomeX = -1;
            ParasiticBiomeY = -1;
            ParasiticBiomeWidth = -1;
            ParasiticBiomeHeight = -1;
            ParasiticBiome = new Rectangle(-1, -1, -1, -1);

            Azercadmium.bothEvils = WorldGen.crimson || ModLoader.GetMod("BothEvils") != null;
        }

        public override TagCompound Save()
        {
            return new TagCompound()
            {
                ["DevastationMode"] = devastation,

                ["downedDirtball"] = downedDirtball,
                ["downedAncy"] = downedAncy,
                ["downedEmpress"] = downedEmpress,
                ["downedHemi"] = downedHemi,
                ["downedScavenger"] = downedScavenger,
                ["downedTitan"] = downedTitan,

                ["genEmberThorns"] = emberThorns,
                ["aquite"] = aquite,
                ["jade"] = jade,

                ["EmberGladesBiomePointX"] = EmberGladesBiomePointX,
                ["EmberGladesBiomePointY"] = EmberGladesBiomePointY,
                ["EmberGladesBiomeX"] = EmberGladesBiomeX,
                ["EmberGladesBiomeY"] = EmberGladesBiomeY,
                ["EmberGladesBiomeWidth"] = EmberGladesBiomeWidth,
                ["EmberGladesBiomeHeight"] = EmberGladesBiomeHeight,

                ["ParasiticBiomePointX"] = ParasiticBiomePointX,
                ["ParasiticBiomePointY"] = ParasiticBiomePointY,
                ["ParasiticBiomeX"] = ParasiticBiomeX,
                ["ParasiticBiomeY"] = ParasiticBiomeY,
                ["ParasiticBiomeWidth"] = ParasiticBiomeWidth,
                ["ParasiticBiomeHeight"] = ParasiticBiomeHeight,

                ["EvilLakeBiomeX"] = EvilLakeBiomeX,
                ["EvilLakeBiomeY"] = EvilLakeBiomeY,
                ["EvilLakeBiomeWidth"] = EvilLakeBiomeWidth,
                ["EvilLakeBiomeHeight"] = EvilLakeBiomeHeight,
            };
        }

        public override void Load(TagCompound tag)
        {
            devastation = tag.GetBool("DevastationMode");
            downedDirtball = tag.GetBool("downedDirtball");
            downedAncy = tag.GetBool("downedAncy");
            downedEmpress = tag.GetBool("downedEmpress");
            downedHemi = tag.GetBool("downedHemi");
            downedScavenger = tag.GetBool("downedScavenger");
            downedTitan = tag.GetBool("downedTitan");

            emberThorns = tag.GetBool("genEmberThorns");
            aquite = tag.GetBool("aquite");
            jade = tag.GetBool("jade");

            EmberGladesBiomePointX = tag.GetInt("EmberGladesBiomePointX");
            EmberGladesBiomePointY = tag.GetInt("EmberGladesBiomePointY");
            EmberGladesBiomePoint = new Point(EmberGladesBiomePointX, EmberGladesBiomePointX);
            EmberGladesBiomeX = tag.GetInt("EmberGladesBiomeX");
            EmberGladesBiomeY = tag.GetInt("EmberGladesBiomeY");
            EmberGladesBiomeWidth = tag.GetInt("EmberGladesBiomeWidth");
            EmberGladesBiomeHeight = tag.GetInt("EmberGladesBiomeHeight");
            EmberGladesBiome = new Rectangle(EmberGladesBiomeX, EmberGladesBiomeY, EmberGladesBiomeWidth, EmberGladesBiomeHeight);

            ParasiticBiomePointX = tag.GetInt("ParasiticBiomePointX");
            ParasiticBiomePointY = tag.GetInt("ParasiticBiomePointY");
            ParasiticBiomePoint = new Point(ParasiticBiomePointX, ParasiticBiomePointX);
            ParasiticBiomeX = tag.GetInt("ParasiticBiomeX");
            ParasiticBiomeY = tag.GetInt("ParasiticBiomeY");
            ParasiticBiomeWidth = tag.GetInt("ParasiticBiomeWidth");
            ParasiticBiomeHeight = tag.GetInt("ParasiticBiomeHeight");
            ParasiticBiome = new Rectangle(ParasiticBiomeX, ParasiticBiomeY, ParasiticBiomeWidth, ParasiticBiomeHeight);

            EvilLakeBiomeX = tag.GetInt("EvilLakeBiomeX");
            EvilLakeBiomeY = tag.GetInt("EvilLakeBiomeY");
            EvilLakeBiomeWidth = tag.GetInt("EvilLakeBiomeWidth");
            EvilLakeBiomeHeight = tag.GetInt("EvilLakeBiomeHeight");
            EvilLakeBiome = new Rectangle(EvilLakeBiomeX, EvilLakeBiomeY, EvilLakeBiomeWidth, EvilLakeBiomeHeight);
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = devastation;
            flags[1] = downedDirtball;
            flags[2] = downedAncy;
            flags[3] = downedEmpress;
            flags[4] = downedHemi;
            flags[5] = downedScavenger;
            flags[6] = downedTitan;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            devastation = flags[0];
            downedDirtball = flags[1];
            downedAncy = flags[2];
            downedEmpress = flags[3];
            downedHemi = flags[4];
            downedScavenger = flags[5];
            downedTitan = flags[6];
        }

        public static void SmoothenOutGenTiles()
        {
            ushort genTileType = (ushort)ModContent.TileType<GenTile>();
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

        public static void SmoothenOutGenTiles(Rectangle rectangle)
        {
            if (rectangle.X < 0)
            {
                rectangle.Width += rectangle.X;
                rectangle.X = 0;
            }
            if (rectangle.Y < 0)
            {
                rectangle.Height += rectangle.Y;
                rectangle.Y = 0;
            }
            if (rectangle.X + rectangle.Width > Main.maxTilesX)
            {
                rectangle.Width = Main.maxTilesX - rectangle.X;
            }
            if (rectangle.Y + rectangle.Height > Main.maxTilesY)
            {
                rectangle.Height = Main.maxTilesY - rectangle.Y;
            }
            ushort genTile = (ushort)ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    try
                    {
                        Tile tile = Framing.GetTileSafely(i, j);
                        bool flag1 = false;
                        bool flag2 = false;
                        bool flag3 = false;
                        bool flag4 = false;
                        if (tile.type == genTile)
                        {
                            if (j > 0)
                            {
                                Tile aboveTile = Framing.GetTileSafely(i, j - 1);
                                flag1 = aboveTile.active();
                                if (flag1)
                                {
                                    tile.ResetToType(genTile);
                                }
                            }
                            if (j != Main.maxTilesY)
                            {
                                Tile belowTile = Framing.GetTileSafely(i, j + 1);
                                flag2 = belowTile.active();
                            }
                            if (i > 0)
                            {
                                Tile leftTile = Framing.GetTileSafely(i - 1, j);
                                flag3 = leftTile.active();
                            }
                            if (i != Main.maxTilesX)
                            {
                                Tile rightTile = Framing.GetTileSafely(i + 1, j);
                                flag4 = rightTile.active();
                            }
                            bool flag5 = flag1 && flag2 && flag3 && flag4;
                            bool flag6 = !flag1 && !flag2 && !flag3 && !flag4;
                            if (flag5)
                            {
                                tile.ResetToType(genTile);
                                tile.active(true);
                            }
                            if (flag6)
                            {
                                WorldGen.KillTile(i, j, false, false, true);
                            }
                        }
                    }
                    catch
                    {
                        throw new Exception("You are cringe: {i:" + i + ", j:" + j + "} MaxTiles: {i:" + Main.maxTilesX + ", j:" + Main.maxTilesY + "} JungleLeft: " + JungleLeft + " JungleRight: " + JungleRight + " Rectangle: " + rectangle);
                    }
                }
            }
        }

        public static void ReplaceGenTiles(int type)
        {
            int genTileType = ModContent.TileType<GenTile>();
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.type == genTileType)
                    {
                        tile.type = (ushort)type;
                    }
                }
            }
        }

        public static void ReplaceGenTiles(int type, Rectangle rectangle)
        {
            int genTileType = ModContent.TileType<GenTile>();
            int minX = (int)MathHelper.Clamp(rectangle.X - 10, 0, Main.maxTilesX);
            int maxX = (int)MathHelper.Clamp(rectangle.X + rectangle.Width + 10, rectangle.X, Main.maxTilesX);
            int minY = (int)MathHelper.Clamp(rectangle.Y - 10, 0, Main.maxTilesY);
            int maxY = (int)MathHelper.Clamp(rectangle.Y + rectangle.Height + 10, rectangle.Y, Main.maxTilesY);
            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.type == genTileType)
                    {
                        tile.type = (ushort)type;
                    }
                }
            }
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            genTile = ModContent.TileType<GenTile>();
            chestTile = ModContent.TileType<Containers>();
            int index = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));
            if (index != -1)
            {
                tasks.Insert(index + 1, new PassLegacy("Hell Oasis", EmberGlades.Generate));
            }
            index = tasks.FindIndex(genpass => genpass.Name.Equals("Hellforge"));
            if (index != -1)
            {
                //tasks.Insert(index + 1, new PassLegacy("Hell Oasis", GenerateOasis));
                tasks.Insert(index + 1, new PassLegacy("Azercadmium Plants", AddPlants));
            }
            index = tasks.FindIndex(genpass => genpass.Name.Equals("Corruption"));
            /*if (index != -1 && GetInstance<AZConfigClient>().generateEvilLake)
            {
                tasks.Insert(index + 1, new PassLegacy("Evil Lakes", GenerateEvilLakes));
            }*/

            index = tasks.FindIndex(genpass => genpass.Name.Equals("Vines"));
            if (index != -1)
            {
                tasks.Insert(index + 1, new PassLegacy("Azercadmium Vines", GenVines));
            }
            index = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            if (index != -1)
            {
                tasks.Insert(index + 1, new PassLegacy("Azercadmium Extras", ExtraGen));
            }
        }

        public static bool CanPlacePlant(int i, int j, int type)
        {
            if (j > Main.maxTilesY - 8 || j < 8)
            {
                return false;
            }
            Tile tile = Framing.GetTileSafely(i, j);
            Tile anchorTile = Framing.GetTileSafely(i, j + 1);
            if (tile.active() || !anchorTile.active())
            {
                return false;
            }
            foreach (PlantInfo plantInfo in Azercadmium.PlantInfo)
            {
                if (plantInfo.tileType == type)
                {
                    if (tile.liquid > 0)
                    {
                        if (tile.lava())
                        {
                            if (plantInfo.lavaLiquidPlacement == LiquidPlacement.NotAllowed)
                            {
                                return false;
                            }
                            if (plantInfo.lavaLiquidPlacement == LiquidPlacement.OnlyInFullLiquid)
                            {
                                if (tile.liquid != byte.MaxValue)
                                {
                                    return false;
                                }
                            }
                        }
                        else if (!tile.honey())
                        {
                            if (plantInfo.waterLiquidPlacement == LiquidPlacement.NotAllowed)
                            {
                                return false;
                            }
                            if (plantInfo.waterLiquidPlacement == LiquidPlacement.OnlyInFullLiquid)
                            {
                                if (tile.liquid != byte.MaxValue)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (plantInfo.lavaLiquidPlacement == LiquidPlacement.OnlyInLiquid || plantInfo.waterLiquidPlacement == LiquidPlacement.OnlyInLiquid)
                        {
                            return false;
                        }
                    }
                    for (int k = 0; k < plantInfo.tileAnchors.Length; k++)
                    {
                        if (anchorTile.type == plantInfo.tileAnchors[k])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void AddPlants(GenerationProgress progress)
        {
            progress.Message = "Generating Grasses...";
            ushort ashPlants = (ushort)ModContent.TileType<AshPlants>();
            ushort hellPlants = (ushort)ModContent.TileType<HellPlants>();
            for (int i = 8; i < Main.maxTilesX - 8; i++)
            {
                for (int j = Main.maxTilesY - 200; j < Main.maxTilesY - 8; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    int chance = 20;
                    int hellPlantsChance = 10;
                    if (i > EmberGladesBiome.X && i < EmberGladesBiome.X + EmberGladesBiome.Width)
                    {
                        if (j > EmberGladesBiome.Y && j < EmberGladesBiome.Y + EmberGladesBiome.Height)
                        {
                            chance = 1;
                            hellPlantsChance = 2;
                        }
                    }
                    if (WorldGen.genRand.NextBool(chance))
                    {
                        if (WorldGen.genRand.NextBool(hellPlantsChance))
                        {
                            if (CanPlacePlant(i, j, hellPlants))
                            {
                                tile.active(active: true);
                                tile.type = hellPlants;
                                tile.frameY = 0;
                                tile.frameX = (short)(WorldGen.genRand.Next(Azercadmium.hellGrassMaxStyles) * 18);
                            }
                        }
                        else
                        {
                            if (CanPlacePlant(i, j, ashPlants))
                            {
                                tile.active(active: true);
                                tile.type = ashPlants;
                                tile.frameY = 0;
                                tile.frameX = (short)(WorldGen.genRand.Next(Azercadmium.ashGrassMaxStyles) * 18);
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateJungleInfo()
        {
            JungleLeft = Point.Zero;
            JungleRight = Point.Zero;
            int[] tileDetect = new int[] { TileID.JungleGrass, TileID.JunglePlants, TileID.JunglePlants2, TileID.JungleVines, };
            for (int i = DungeonLeft ? Main.maxTilesX / 2 : 0; i < Main.maxTilesX / (DungeonLeft ? 1 : 2); i++)
            {
                for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 200; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    for (int k = 0; k < tileDetect.Length; k++)
                    {
                        if (tile.type == tileDetect[k] && JungleLeft == Point.Zero)
                        {
                            JungleLeft = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                        if (tile.type == tileDetect[k])
                        {
                            JungleRight = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                    }
                }
            }
        }

        public static void UpdateEvilInfo()
        {
            EvilLeft = Point.Zero;
            EvilRight = Point.Zero;
            int[] tileDetect = new int[] { TileID.FleshGrass, TileID.CrimtaneThorns, TileID.CrimsonVines, TileID.JungleVines, };
            for (int i = DungeonLeft ? Main.maxTilesX / 2 : 0; i < Main.maxTilesX / (DungeonLeft ? 1 : 2); i++)
            {
                for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 200; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    for (int k = 0; k < tileDetect.Length; k++)
                    {
                        if (tile.type == tileDetect[k] && EvilLeft == Point.Zero)
                        {
                            EvilLeft = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                        if (tile.type == tileDetect[k])
                        {
                            EvilRight = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                    }
                }
            }
        }

        private void UpdateSnowInfo()
        {
            int[] tileDetect = new int[] { TileID.SnowBlock, TileID.IceBlock, TileID.CorruptIce, TileID.FleshIce, };
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = (int)Main.worldSurface; j < Main.maxTilesY - 200; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    for (int k = 0; k < tileDetect.Length; k++)
                    {
                        if (tile.type == tileDetect[k] && SnowLeft == Point.Zero)
                        {
                            SnowLeft = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                        if (tile.type == tileDetect[k])
                        {
                            SnowRight = new Point(i, j);
                            i++;
                            j = (int)Main.worldSurface;
                        }
                    }
                }
            }
            mod.Logger.Debug("SnowLeft: " + SnowLeft);
            mod.Logger.Debug("SnowRight: " + SnowRight);
        }

        public static ThornInfo? GetThorn(ushort type)
        {
            foreach (ThornInfo data in Azercadmium.ThornInfo)
            {
                if (data.tileType == type)
                {
                    return data;
                }
            }
            return null;
        }

        public static ThornInfo? GetThorn(int i, int j)
        {
            int type = Framing.GetTileSafely(i, j).type;
            foreach (ThornInfo data in Azercadmium.ThornInfo)
            {
                if (data.tileType == type)
                {
                    return data;
                }
            }
            return null;
        }

        public static void GenerateThorns()
        {
            if (!NPC.downedMechBossAny || emberThorns)
            {
                return;
            }
            emberThorns = true;
            int tileType = ModContent.TileType<EmberGrass>();
            int tileType2 = ModContent.TileType<EmberThornTile>();
            for (int k = 0; k < 12; k++)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        Tile tile = Framing.GetTileSafely(i, j);
                        if (tile.active() && tile.type == tileType2)
                        {
                            if (WorldGen.genRand.NextBool((k + 1) * 2))
                                GrowThorn(i, j);
                        }
                    }
                }
            }
            Main.NewText("The glades of hell are rising!", Color.Orange);
        }

        public static Point GrowThorn(int i, int j)
        {
            Point tilePos = new Point(i, j);
            Tile tile = Framing.GetTileSafely(i, j);
            int tileType = ModContent.TileType<EmberThornTile>();
            int thorns = 0;
            Rectangle nearby = (new Rectangle(i + 10, j + 10, 20, 20));
            for (int k = nearby.X; k < nearby.X + nearby.Width; k++)
            {
                for (int l = nearby.Y; l < nearby.Y + nearby.Height; l++)
                {
                    if (tile.type == tileType)
                    {
                        thorns++;
                        if (thorns > 30)
                        {
                            return tilePos;
                        }
                    }
                }
            }
            for (int k = 0; k < 8; k++)
            {
                Point direction = new Point(WorldGen.genRand.NextBool() ? -1 : 1, 0);
                if (WorldGen.genRand.NextBool())
                {
                    direction.Y = direction.X;
                    direction.X = 0;
                }
                Point newPos = new Point(tilePos.X + direction.X, tilePos.Y + direction.Y);
                Tile newTile = Framing.GetTileSafely(newPos.X, newPos.Y);
                if (!newTile.active())
                {
                    bool flag = WorldGen.PlaceTile(newPos.X, newPos.Y, tileType, true);
                    if (flag)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            Dust.NewDust(newPos.ToWorldCoordinates(), 16, 16, DustID.Fire);
                        }
                    }
                    return newPos;
                }
            }
            return tilePos;
        }





        
        private void GenVines(GenerationProgress progress)
        {
            string message = "Generating Modded Vines";
            int emberGrassTileType = ModContent.TileType<EmberGrass>();
            int ashVineTileType = ModContent.TileType<AshVines>();
            int emberVineTileType = ModContent.TileType<EmberVines>();
            progress.Message = message + "... Ember Glades";
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.active())
                    {
                        if (tile.type == emberGrassTileType)
                        {
                            Tile bottomTile = Framing.GetTileSafely(i, j + 1);
                            if (!bottomTile.active())
                            {
                                if (WorldGen.genRand.Next(15) != 0)
                                {
                                    if (WorldGen.genRand.NextBool(3))
                                    {
                                        WorldGen.PlaceTile(i, j + 1, emberVineTileType);
                                    }
                                    else
                                    {
                                        WorldGen.PlaceTile(i, j + 1, ashVineTileType);
                                    }
                                }
                            }
                        }
                        if (tile.type == ashVineTileType)
                        {
                            Tile bottomTile2 = Framing.GetTileSafely(i, j + 1);
                            if (!bottomTile2.active())
                            {
                                if (WorldGen.genRand.Next(10) != 0)
                                {
                                    WorldGen.PlaceTile(i, j + 1, ashVineTileType);
                                }
                            }
                        }
                        if (tile.type == emberVineTileType)
                        {
                            Tile bottomTile3 = Framing.GetTileSafely(i, j + 1);
                            if (!bottomTile3.active())
                            {
                                if (WorldGen.genRand.Next(12) != 0)
                                {
                                    WorldGen.PlaceTile(i, j + 1, emberVineTileType);
                                }
                            }
                        }
                    }
                }
            }
            progress.Message = message;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile2 = Framing.GetTileSafely(i, j);
                    if (tile2.active())
                    {
                        if (tile2.type == ashVineTileType || tile2.type == emberVineTileType)
                        {
                            WorldGen.TileFrame(i, j, true, false);
                        }
                    }
                }
            }
        }

        public override void PostWorldGen() => HellWind.WindSpeed = WorldGen.genRand.Next(-25, 25);

        private void SetEmberGladesPoint()
        {
            Vector2 world = TAZPlayer.GetEmberGladesTeleportPosition();
            if (world != Vector2.Zero)
            {
                Point point = world.ToTileCoordinates();
            }
        }

        private void ExtraGen(GenerationProgress progress)
        {
            for (int k = 0; k < 125000; k++)
            {
                int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int j = WorldGen.genRand.Next(200, (int)Main.worldSurface);
                Tile tile = Framing.GetTileSafely(i, j);
                Tile bottomTile = Framing.GetTileSafely(i, j + 1);
                if (bottomTile.active() && TileID.Sets.Crimson[bottomTile.type] && (!tile.active() || Main.tileCut[tile.type]) && tile.liquid > 0 && tile.liquidType() == 0)
                {
                    int index = WorldGen.PlaceChest(i, j, (ushort)chestTile, false, 2);
                    if (index != -1)
                    {
                        Chest chest = Main.chest[index];
                        chest.AddShop(AzercadmiumGlobalItem.GetItem(ItemID.ChaosFish));
                    }
                }
                if (bottomTile.active() && TileID.Sets.Corrupt[bottomTile.type] && (!tile.active() || Main.tileCut[tile.type]) && tile.liquid > 0 && tile.liquidType() == 0)
                {
                    int index = WorldGen.PlaceChest(i, j, (ushort)chestTile, false, 3);
                    if (index != -1)
                    {
                        Chest chest = Main.chest[index];
                        chest.AddShop(AzercadmiumGlobalItem.GetItem(ItemID.ChaosFish));
                    }
                }
            }
        }

        private void GenerateEvilLakes(int i, int j, ushort hardSand, ushort sandstone, ushort wall)
        {
            EvilLakeBiomeX = i - 130;
            EvilLakeBiomeY = j - 40;
            EvilLakeBiomeWidth = 290;
            EvilLakeBiomeHeight = 210;
            EvilLakeBiome = new Rectangle(EvilLakeBiomeX, EvilLakeBiomeY, EvilLakeBiomeWidth, EvilLakeBiomeHeight);
            WorldGen.TileRunner(i - 90, j + 8, 60, 1, hardSand, true);
            WorldGen.TileRunner(i + 90, j + 8, 60, 1, hardSand, true);
            WorldGen.TileRunner(i - 100, j + 16, 66, 1, sandstone, true);
            WorldGen.TileRunner(i + 100, j + 16, 66, 1, sandstone, true);
            for (int m = (i - 80); m < i + 80; m += 4)
            {
                WorldGen.TileRunner(m, j + 35, 48, 1, hardSand, true);
                WorldGen.TileRunner(m, j + 35, 60, 1, sandstone, true);
                WorldGen.Lakinater(m, j);
                WorldGen.Lakinater(m, j + 40);
            }
            for (int o = EvilLakeBiomeX; o < EvilLakeBiomeX + EvilLakeBiomeWidth; o++)
            {
                for (int p = EvilLakeBiomeY; p < EvilLakeBiomeY + EvilLakeBiomeHeight; p++)
                {
                    Tile t = Framing.GetTileSafely(o, p);
                    if (t.active())
                    {
                        if (t.type == TileID.Trees)
                        {
                            t.active(active: false);
                        }
                    }
                    if (t.active() && t.collisionType > 0 || t.liquid > 0)
                    {
                        WorldGen.KillWall(o, p);
                        WorldGen.PlaceWall(o, p, wall);
                    }
                    else
                    {
                        t.wall = 0;
                    }
                }
            }
            int x = EvilLakeBiomeX + EvilLakeBiomeWidth / 2;
            for (int n = EvilLakeBiomeY; n < EvilLakeBiomeY + EvilLakeBiomeHeight + 80; n++)
            {
                WorldGen.digTunnel(x * 16, n * 16, 0, 0, 1, (EvilLakeBiomeHeight - n + 200) / 18, true);
            }
            for (int m = i - 40; m < i + 40; m++)
            {
                WorldGen.TileRunner(m, j + 120, 55, 1, sandstone, true);
                WorldGen.TileRunner(m, j + 110, 44, 2, hardSand, true);
            }
            WorldGen.TileRunner(i - 55, j + 100, 55, 1, sandstone, true);
            WorldGen.TileRunner(i - 50, j + 100, 44, 2, hardSand, true);
            WorldGen.TileRunner(i + 55, j + 100, 55, 1, sandstone, true);
            WorldGen.TileRunner(i + 50, j + 100, 44, 2, hardSand, true);
            WorldGen.TileRunner(i - 70, j + 80, 55, 1, sandstone, true);
            WorldGen.TileRunner(i - 60, j + 80, 44, 2, hardSand, true);
            WorldGen.TileRunner(i + 70, j + 80, 55, 1, sandstone, true);
            WorldGen.TileRunner(i + 60, j + 80, 44, 2, hardSand, true);
            WorldGen.TileRunner(i - 90, j + 65, 55, 1, sandstone, true);
            WorldGen.TileRunner(i - 80, j + 65, 44, 2, hardSand, true);
            WorldGen.TileRunner(i + 90, j + 65, 55, 1, sandstone, true);
            WorldGen.TileRunner(i + 80, j + 65, 44, 2, hardSand, true);
            for (int m = (i - 80); m < i + 80; m += 4)
            {
                WorldGen.TileRunner(m, j + 35, 48, 2, hardSand, true);
                WorldGen.Lakinater(m, j);
                WorldGen.Lakinater(m, j + 90 - Math.Abs(m - i));
                WorldGen.Lakinater(m, j + 120 - (int)(Math.Abs(m - i) * 1.25));
            }
        }
        private void GenerateEvilLakes(GenerationProgress progress)
        {
            for (int k = 0; k < 125000; k++)
            {
                int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int j = WorldGen.genRand.Next(200, (int)Main.worldSurface - 60);
                Tile tile = Framing.GetTileSafely(i, j);
                if (tile.active() && TileID.Sets.Crimson[tile.type])
                {
                    GenerateEvilLakes(i, j, TileID.CrimsonHardenedSand, TileID.CrimsonSandstone, WallID.CrimsonSandstone);
                    break;
                }
            }
            for (int k = 0; k < 125000; k++)
            {
                int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int j = WorldGen.genRand.Next(200, (int)Main.worldSurface - 60);
                Tile tile = Framing.GetTileSafely(i, j);
                if (tile.active() && TileID.Sets.Corrupt[tile.type])
                {
                    GenerateEvilLakes(i, j, TileID.CorruptHardenedSand, TileID.CorruptSandstone, WallID.CorruptSandstone);
                    break;
                }
            }
            for (int k = 0; k < 125000; k++)
            {
                int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int j = WorldGen.genRand.Next(200, (int)Main.worldSurface - 60);
                Tile tile = Framing.GetTileSafely(i, j);
                if (tile.active() && TileID.Sets.Hallow[tile.type])
                {
                    GenerateEvilLakes(i, j, TileID.HallowHardenedSand, TileID.HallowSandstone, WallID.HallowSandstone);
                    break;
                }
            }
        }

        /*public static void GenerateAquite()
        {
            if (!aquite)
            {
                aquite = true;
                Azercadmium.BroadcastText("The areas beneath the ocean have begun to condense...", Color.DarkCyan);
                int repeat = (int)(Main.maxTilesX * Main.maxTilesY * 0.000055);
                int tileType = ModContent.TileType<AquiteOreTile>();
                Rectangle oceanRight = new Rectangle(0, (int)Main.worldSurface, 400, 400);
                Rectangle oceanLeft = new Rectangle(Main.maxTilesX - 400, (int)Main.worldSurface, 400, 400);
                for (int k = 0; k < repeat; k++)
                {
                    int i = WorldGen.genRand.Next(oceanRight.X, oceanRight.X + oceanRight.Width);
                    int j = WorldGen.genRand.Next(oceanRight.Y, oceanRight.Y + oceanRight.Height);
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.active() && (tile.type == TileID.Dirt || tile.type == TileID.Stone || tile.type == TileID.Sand))
                    {
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(2, 8), tileType);
                    }
                    i = WorldGen.genRand.Next(oceanLeft.X, oceanLeft.X + oceanLeft.Width);
                    j = WorldGen.genRand.Next(oceanLeft.Y, oceanLeft.Y + oceanLeft.Height);
                    tile = Framing.GetTileSafely(i, j);
                    if (tile.active() && (tile.type == TileID.Dirt || tile.type == TileID.Stone || tile.type == TileID.Sand))
                    {
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(6, 12), tileType);
                    }
                }
            }
        }*/

        /*public static void GenerateJade()
        {
            if (!jade)
            {
                int jadeType = ModContent.TileType<Gems>();
                for (int k = 0; k < Main.maxTilesX + Main.maxTilesY; k++)
                {
                    int i = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                    int j = WorldGen.genRand.Next(20, Main.maxTilesY - 20);
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.wall == WallID.Sandstone || tile.wall == WallID.CorruptSandstone || tile.wall == WallID.CrimsonSandstone || tile.wall == WallID.HallowSandstone)
                    {
                        TileGlobal.GrowGem(i, j, jadeType, 0);
                    }
                }
            }
        }*/
        public override void TileCountsAvailable(int[] tileCounts)
        {
            emberGladesTileCount = 0;
            for (int i = 0; i < Azercadmium.TileEmberGladesCache.Length; i++)
            {
                if (Azercadmium.TileEmberGladesCache[i])
                {
                    emberGladesTileCount += tileCounts[i];
                }
            }         
        }

        public override void PostDrawTiles()
        {
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
            foreach (Point point in Azercadmium.specialTileDrawPoints)
            {
                Tile tile = Framing.GetTileSafely(point.X, point.Y);
            }
            if (Azercadmium.clearSpecialDrawPoints)
            {
                Azercadmium.clearSpecialDrawPoints = false;
                Azercadmium.specialTileDrawPoints.Clear();
            }
            Main.spriteBatch.End();
        }
    }
}