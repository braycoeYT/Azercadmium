using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Terraria.World.Generation;
using Azercadmium.Helpers;
using Azercadmium.Items;
using Azercadmium.Items.Ember;
using Azercadmium.Tiles.Ember;
using Azercadmium.Tiles.Chests;
using Azercadmium.Tiles.Tree;
using Azercadmium.Aaa;

namespace Azercadmium.Biomes
{
    public static class EmberGlades
    {
        public static Rectangle EmberGladesBiome
        {
            get => new Rectangle(TAZWorld.EmberGladesBiomeX, TAZWorld.EmberGladesBiomeY, TAZWorld.EmberGladesBiomeWidth, TAZWorld.EmberGladesBiomeHeight);

            set
            {
                TAZWorld.EmberGladesBiomeX = value.X;
                TAZWorld.EmberGladesBiomeY = value.Y;
                TAZWorld.EmberGladesBiomeWidth = value.Width;
                TAZWorld.EmberGladesBiomeHeight = value.Height;
                TAZWorld.EmberGladesBiome = value;
            }
        }

        public static Rectangle ExagerratedEmberGladesBiome => new Rectangle(TAZWorld.EmberGladesBiomeX - 20, TAZWorld.EmberGladesBiomeY - 20, TAZWorld.EmberGladesBiomeWidth + 40, TAZWorld.EmberGladesBiomeHeight + 20);

        private static void OasisHoles1(Rectangle rectangle)
        {
            int genTile = ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    if (WorldGen.genRand.NextBool(10))
                    {
                        int rand = WorldGen.genRand.Next(-10, 10);
                        if (rand != 0)
                        {
                            Tile tile = WorldGenHelper.GetTileVerySafely(i + rand, j);
                            if (tile.active())
                            {
                                WorldGen.TileRunner(i, j, 4, 24, genTile, true, rand * 0.5f, 0, true);
                            }
                        }
                    }
                }
            }
        }

        private static void OasisHoles2(Rectangle rectangle)
        {
            int genTile = ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    if (Framing.GetTileSafely(i, j).active() || Framing.GetTileSafely(i, j).type != genTile || Framing.GetTileSafely(i, j).type != TileID.Ash)
                    {
                        return;
                    }
                    int unsafeCount = 0;
                    if (Framing.GetTileSafely(i + 1, j).collisionType > 0)
                    {
                        unsafeCount++;
                    }
                    if (Framing.GetTileSafely(i - 1, j).collisionType > 0)
                    {
                        unsafeCount++;
                    }
                    if (Framing.GetTileSafely(i, j + 1).collisionType > 0)
                    {
                        unsafeCount++;
                    }
                    if (Framing.GetTileSafely(i, j - 1).collisionType > 0)
                    {
                        unsafeCount++;
                    }
                    if (unsafeCount == 3 || unsafeCount == 4)
                    {
                        WorldGen.PlaceTile(i, j, genTile);
                    }
                }
            }
        }

        private static void OasisHoles3(Rectangle rectangle)
        {
            int genTile = ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    if (Framing.GetTileSafely(i, j).lava())
                    {
                        if (WorldGen.genRand.NextBool(40))
                        {
                            WorldGen.TileRunner(i, j, WorldGen.genRand.Next(7, 18), WorldGen.genRand.Next(7, 18), genTile, true, 12, 0, true);
                        }
                    }
                }
            }
        }

        private static void OasisHoles4(Rectangle rectangle)
        {
            int genTile = ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    if (WorldGen.genRand.NextBool(40))
                    {
                        Tile tile = Framing.GetTileSafely(i, j);
                        if ((tile.type == genTile || tile.type == TileID.Ash || tile.type == TileID.Hellstone) && tile.active() && !tile.lava())
                        {
                            Tile belowTile = WorldGenHelper.GetTileVerySafely(i, j + 10);
                            if (!belowTile.active() && !belowTile.lava())
                            {
                                int rand = WorldGen.genRand.Next(10, 50);
                                Tile belowTile2 = WorldGenHelper.GetTileVerySafely(i, j + rand);
                                if (belowTile2.active() && !belowTile2.lava())
                                {
                                    WorldGen.TileRunner(i, j, WorldGen.genRand.NextFloat(7, 18) + rand * 0.17, WorldGen.genRand.Next(10, 20), genTile, true, 0.5f, 7);
                                    WorldGen.TileRunner(i, j, WorldGen.genRand.NextFloat(7, 18) + rand * 0.17, WorldGen.genRand.Next(10, 20), genTile, true, -0.5f, 7);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void OasisHoles5(Rectangle rectangle)
        {
            int genTile = ModContent.TileType<GenTile>();
            for (int i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
            {
                for (int j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if ((tile.type == genTile || tile.type == TileID.Ash || tile.type == TileID.Hellstone) && !tile.lava())
                    {
                        if (WorldGen.genRand.NextBool(200))
                        {
                            Tile belowTile = WorldGenHelper.GetTileVerySafely(i, j + 10);
                            if (belowTile.active() && !belowTile.lava())
                            {
                                WorldGen.TileRunner(i, j, WorldGen.genRand.Next(7, 18), WorldGen.genRand.Next(15, 30), genTile, true, 0.5f, 7);
                                WorldGen.TileRunner(i, j, WorldGen.genRand.Next(7, 18), WorldGen.genRand.Next(15, 30), genTile, true, -0.5f, 7);
                            }
                        }
                    }
                }
            }
        }

        private static void GenerateCave(Rectangle surfaceRectangle)
        {
            if (!Azercadmium.clientConfigInstance.generateEmberGladesLake)
            {
                return;
            }
            for (int attempts = 0; attempts < 125000; attempts++)
            {
                Point randomPos = new Point(surfaceRectangle.X + 50 + WorldGen.genRand.Next(0, (int)MathHelper.Clamp(surfaceRectangle.Width - 50, 1, float.MaxValue)), surfaceRectangle.Y + 20 + WorldGen.genRand.Next(surfaceRectangle.Height - 30));
                Tile tile = Framing.GetTileSafely(randomPos.X, randomPos.Y);
                if (!tile.active())
                {
                    int dir = (randomPos.X > surfaceRectangle.X + surfaceRectangle.Width / 2) ? 1 : -1;
                    if (WorldGen.genRand.NextBool(50))
                    {
                        int rand = WorldGen.genRand.Next(-20, 20);
                        Tile caveTile1 = Framing.GetTileSafely(randomPos.X, randomPos.Y + 10);
                        if (caveTile1.active() && caveTile1.type == TileID.Ash && Framing.GetTileSafely(randomPos.X, randomPos.Y + 9).active())
                        {
                            WorldGen.CaveOpenater(randomPos.X, randomPos.Y - 5);
                            WorldGen.digTunnel(randomPos.X, randomPos.Y, WorldGen.genRand.Next(-4, 4), 6, 10, 30, false);
                            WorldGen.digTunnel(randomPos.X, randomPos.Y, WorldGen.genRand.Next(-4, 4), 6, 10, 30, false);
                            for (int i = EmberGladesBiome.X; i < EmberGladesBiome.X + EmberGladesBiome.Width; i++)
                            {
                                for (int j = EmberGladesBiome.Y; j < EmberGladesBiome.Y + EmberGladesBiome.Height; j++)
                                {
                                    if (Framing.GetTileSafely(i, j).liquid > 0)
                                    {
                                        Framing.GetTileSafely(i, j).RemoveWater();
                                    }
                                }
                            }
                            Point randomPos2 = new Point(randomPos.X + WorldGen.genRand.Next(-75, 75), randomPos.Y + WorldGen.genRand.Next(50));
                            WorldGen.digTunnel(randomPos.X, randomPos.Y, WorldGen.genRand.Next(-4, 4), 6, 10, 20, false);
                            int rand1 = WorldGen.genRand.Next(8, 15) * -dir;
                            WorldGen.digTunnel(randomPos.X, randomPos.Y + 10, rand1, 1, 10, 20, false);
                            int rand2 = WorldGen.genRand.Next(Math.Abs(rand1), Math.Abs(rand1) * 2) * -dir;
                            WorldGen.digTunnel(randomPos.X + rand1 / 1.25f, randomPos.Y + 12, rand2, -1, 10, 20, false);
                            WorldGen.digTunnel(randomPos.X + rand2 / 1.25f, randomPos.Y + 12, rand2, -2, 10, 20, false);
                            WorldGen.digTunnel(randomPos.X + rand2 / 1.5f, randomPos.Y + 8, rand2, -3, 10, 20, false);
                            WorldGen.digTunnel(randomPos.X + rand2 / 1.5f, randomPos.Y + 8, rand2, -3, 10, 20, false);
                            Rectangle lavaRect = new Rectangle(randomPos.X - 50, randomPos.Y - 50, 100, 100);
                            for (int k = lavaRect.X; k < lavaRect.X + lavaRect.Width; k++)
                            {
                                for (int l = lavaRect.Y; l < lavaRect.Y + lavaRect.Height; l++)
                                {
                                    Tile lavaTile = Framing.GetTileSafely(k, l);
                                    if (!lavaTile.active())
                                    {
                                        lavaTile.lava(lava: true);
                                        lavaTile.liquid = byte.MaxValue;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private static void AddEmberGrass()
        {
            ushort emberGrass = (ushort)ModContent.TileType<EmberGrass>();
            for (int i = EmberGladesBiome.X; i < EmberGladesBiome.X + EmberGladesBiome.Width; i++)
            {
                for (int j = EmberGladesBiome.Y; j < EmberGladesBiome.Y + EmberGladesBiome.Height; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.active())
                    {
                        if (tile.type == TileID.Ash)
                        {
                            Rectangle check = new Rectangle(i - 1, j - 1, 3, 3);
                            int active = 0;
                            for (int k = check.X; k < check.X + check.Width; k++)
                            {
                                for (int l = check.Y; l < check.Y + check.Height; l++)
                                {
                                    if (Framing.GetTileSafely(k, l).active())
                                    {
                                        active++;
                                    }
                                }
                            }
                            if (active < 9)
                            {
                                tile.type = emberGrass;
                            }
                        }
                    }
                }
            }
        }

        public static void Generate(GenerationProgress progress)
        {
            int genTile = ModContent.TileType<GenTile>();
            if (!Azercadmium.clientConfigInstance.generateEmberGlades)
            {
                return;
            }
            progress.Message = "Generating Hell Oasis...";
            int hellLeavesType = ModContent.TileType<LivingHellLeaves>();
            int emberGrassType = ModContent.TileType<EmberGrass>();
            TAZWorld.UpdateJungleInfo();
            EmberGladesBiome = new Rectangle(TAZWorld.JungleLeft.X, Main.maxTilesY - TAZWorld.hellLayerOffset, TAZWorld.JungleRight.X - TAZWorld.JungleLeft.X, TAZWorld.hellLayerOffset);
            Rectangle surface = new Rectangle(TAZWorld.EmberGladesBiome.X, TAZWorld.EmberGladesBiome.Y + 40, TAZWorld.EmberGladesBiome.Width, TAZWorld.EmberGladesBiome.Height - 140);
            Rectangle roof = new Rectangle(EmberGladesBiome.X, EmberGladesBiome.Y, EmberGladesBiome.Width, EmberGladesBiome.Height - 185);
            OasisHoles1(surface);
            OasisHoles2(surface);
            OasisHoles3(surface);
            OasisHoles4(surface);
            OasisHoles5(surface);
            OasisHoles1(surface);
            OasisHoles2(surface);
            OasisHoles1(surface);
            OasisHoles2(surface);
            TAZWorld.SmoothenOutGenTiles();
            TAZWorld.ReplaceGenTiles(TileID.Ash);
            GenerateCave(surface);
            AddEmberGrass();
            TAZWorld.ReplaceGenTiles(emberGrassType);
            for (int i = roof.X; i < roof.X + roof.Width; i++)
            {
                for (int j = roof.Y; j < roof.Y + roof.Height; j++)
                {
                    if (WorldGen.genRand.NextBool(9))
                    {
                        WorldGen.TileRunner(i, j, WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 9), genTile, true, 3, 1);
                    }
                }
            }
            TAZWorld.SmoothenOutGenTiles(ExagerratedEmberGladesBiome);
            TAZWorld.ReplaceGenTiles(hellLeavesType, ExagerratedEmberGladesBiome);
            Rectangle biomeRectangle = EmberGladesBiome;
            int chests = 0;
            int chestLootIndex1 = 0;
            ushort chestTile = (ushort)ModContent.TileType<Containers>();
            int[,] tileShape = new int[,]
            {
                            { 0, 0, 0, 0, 0, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 2, 3, 2, 2, 3, 2, },
                            { 2, 3, 2, 2, 3, 2, },
                            { 2, 3, 3, 3, 3, 2, },
                            { 2, 3, 3, 3, 3, 2, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 2, 0, 0, 0, 0, 2, },
                            { 2, 2, 0, 0, 2, 2, },
            };
            int[,] wallShape = new int[,]
            {
                            { 0, 0, 0, 0, 0, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 0, 1, 1, 1, 1, 0, },
                            { 0, 0, 1, 1, 0, 0, },
                            { 0, 0, 0, 0, 0, 0, },
                            { 0, 0, 0, 0, 0, 0, },
            };
            int length0 = tileShape.GetLength(0);
            int length1 = tileShape.GetLength(1);
            int[] treeAnchors = TileObjectData.GetTileData(ModContent.TileType<CinderCedarSapling>(), 0, 0).AnchorValidTiles;
            const int offset = 20;
            for (int k = 0; k < Main.maxTilesX + Main.maxTilesY; k++)
            {
                int i = biomeRectangle.X + WorldGen.genRand.Next(offset, biomeRectangle.Width - offset);
                int j = biomeRectangle.Y + WorldGen.genRand.Next(offset, biomeRectangle.Height - 135);
                Tile tile = Framing.GetTileSafely(i, j);
                if ((!tile.lava() && !tile.active() || Main.tileCut[tile.type]) && Framing.GetTileSafely(i, j + 1).collisionType == 1 && treeAnchors.Contains(Framing.GetTileSafely(i, j + 1).type) && AZTree.GrowTree(i, j, AZTreeLoader.GetTree(ModContent.TileType<CinderCedarTree>())))
                {
                    k += 200;
                }
            }
            for (int k = 0; k < 1250; k++)
            {
                int i = biomeRectangle.X + WorldGen.genRand.Next(offset, biomeRectangle.Width - offset);
                int j = biomeRectangle.Y + WorldGen.genRand.Next(offset, biomeRectangle.Height - 135);
                Tile tile = Framing.GetTileSafely(i, j);
                if (!tile.lava() && !tile.active() || Main.tileCut[tile.type])
                {
                    int index = WorldGen.PlaceChest(i, j, chestTile, k < 18000, 1);
                    if (index != -1)
                    {
                        for (int l = 0; l < length0; l++)
                        {
                            for (int m = 0; m < length1; m++)
                            {
                                int worldX = i - 2 + m;
                                int worldY = j + 2 - l;
                                if (tileShape[l, m] != 2)
                                {
                                    WorldGen.KillTile(worldX, worldY);
                                }
                            }
                        }
                        for (int l = 0; l < length0; l++)
                        {
                            for (int m = 0; m < length1; m++)
                            {
                                int tileType = 0;
                                int worldX = i - 2 + m;
                                int worldY = j + 2 - l;
                                if (tileShape[l, m] == 0)
                                {
                                    tileType = TileID.ObsidianBrick;
                                }
                                else if (tileShape[l, m] == 1)
                                {
                                    tileType = TileID.Obsidian;
                                }
                                else if (tileShape[l, m] == 2)
                                {
                                    tileType = -2;
                                }
                                else if (tileShape[l, m] == 3)
                                {
                                    tileType = -1;
                                }
                                if (tileType > 0)
                                {
                                    WorldGen.PlaceTile(worldX, worldY, tileType, true, true);
                                }
                                else if (tileType == -1)
                                {
                                    WorldGen.KillTile(worldX, worldY);
                                }
                            }
                        }
                        for (int l = 0; l < length0; l++)
                        {
                            for (int m = 0; m < length1; m++)
                            {
                                int wallType = 0;
                                int worldX = i - 2 + m;
                                int worldY = j + 2 - l;
                                if (wallShape[l, m] == 1)
                                {
                                    wallType = WallID.ObsidianBrickUnsafe;
                                }
                                if (wallType > 0)
                                {
                                    WorldGen.KillWall(worldX, worldY, false);
                                    Framing.GetTileSafely(worldX, worldY).wall = (ushort)wallType;
                                }
                                else if (wallType == -1)
                                {
                                    WorldGen.KillWall(worldX, worldY, false);
                                }
                            }
                        }
                        Chest chest = Main.chest[index];
                        int itemIndex = 0;
                        int[] chestLootTable1 = new int[] { ItemID.HotlineFishingHook, ItemID.LavaCharm, ModContent.ItemType<RevenantShield>(), };
                        chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(chestLootTable1[chestLootIndex1 % chestLootTable1.Length]);
                        chestLootIndex1++;
                        itemIndex++;
                        if (WorldGen.genRand.NextBool())
                        {
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.StickyDynamite, WorldGen.genRand.Next(2, 5));
                            itemIndex++;
                        }
                        int rand = WorldGen.genRand.Next(3);
                        if (rand == 2)
                        {
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.HallowedBar, WorldGen.genRand.Next(5, 12));
                            itemIndex++;
                        }
                        else if (rand == 1)
                        {
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.ChlorophyteBar, WorldGen.genRand.Next(5, 12));
                            itemIndex++;
                        }
                        else
                        {
                            //chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(azercadmium.ItemType("DarkronBar"), WorldGen.genRand.Next(5, 12));
                            //itemIndex++;
                        }
                        int rand2 = WorldGen.genRand.Next(2);
                        if (rand2 == 2)
                        {
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.ChlorophyteArrow, WorldGen.genRand.Next(100, 300));
                            itemIndex++;
                        }
                        else if (rand2 == 1)
                        {
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.ChlorophyteBullet, WorldGen.genRand.Next(100, 300));
                            itemIndex++;
                        }
                        List<short> potions = new List<short>()
                        {
                            ItemID.AmmoReservationPotion,
                            ItemID.InfernoPotion,
                            ItemID.EndurancePotion,
                            ItemID.LifeforcePotion,
                            ItemID.RagePotion,
                            ItemID.SummoningPotion,
                            ItemID.TeleportationPotion,
                            ItemID.WarmthPotion,
                            ItemID.WrathPotion,
                            //(short)azercadmium.ItemType("BloodiedVial"),
                            //(short)azercadmium.ItemType("StealthPotion"),
                            //(short)azercadmium.ItemType("FloaterPotion"),
                            //(short)azercadmium.ItemType("PsychicPotion"),
                        };
                        for (int l = 0; l < WorldGen.genRand.Next(1, 3); l++)
                        {
                            int potionIndex = WorldGen.genRand.Next(potions.Count);
                            chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(potions[potionIndex], WorldGen.genRand.Next(1, 3));
                            potions.RemoveAt(potionIndex);
                            itemIndex++;
                        }
                        chest.item[itemIndex] = AzercadmiumGlobalItem.GetItem(ItemID.GoldCoin, WorldGen.genRand.Next(3, 6));
                        itemIndex++;
                        chests++;
                    }
                }
                if (chests > 6)
                {
                    break;
                }
            }
        }

        public static void ExtraGeneration(GenerationProgress progress) => progress.Message += "... Ember Glades";

        public static void LoadWorld(TagCompound tag)
        {

        }
    }
}