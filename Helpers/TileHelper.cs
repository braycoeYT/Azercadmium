using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Azercadmium.ID;
using Azercadmium.Items.Copper;
using Azercadmium.Items.Gold;
using Azercadmium.Items.Iron;
using Azercadmium.Items.Lead;
using Azercadmium.Items.Platinum;
using Azercadmium.Items.Silver;
using Azercadmium.Items.Tin;
using Azercadmium.Items.Tungsten;

namespace Azercadmium.Helpers
{
    [Obsolete("Replaced with Global Tile Methods")]
    public static class TileHelper
    {
        public const string statueExtrasPath = "Azercadmium/Tiles/Furniture/StatueExtras";
        public const string plantsExtrasPath = "Azercadmium/Tiles/Foliage/PlantsExtras";

        public static Point GetFrame(int frameX, int frameY, int tileWidth = 1, int tileHeight = 1, bool xDirection = false)
            => new Point((int)((frameX + 18) * 0.05555555f / tileWidth), (int)((frameY + 18) * 0.05555555f / tileHeight));

        /*public static bool SpreadTest(int i, int j, int size = 5)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int sizeLeft = (int)((size - 1) * 0.5f);
            int sizeRight = (size - 1) - sizeLeft;
            for (int k = 0; k < size; k++)
            {
                for (int l = 0; l < size; l++)
                {
                    int m = i + sizeRight - k;
                    int n = j + sizeRight - l;

                    if (WorldGen.PlaceTile(m, n, TileID.Obsidian, true, true, -1, 0))
                    {
                        NetMessage.SendTileSquare(-1, m, n, 1);
                        //return true;
                    }
                }
            }
            return false;
        }*/

        public static int DoorDrop(int frameX, int frameY, bool opened)
        {
            int num = opened ? 4 : 3;
            Point frame = GetFrame(frameX, frameY, num, 3);
            switch (frame.X)
            {
                case 0:
                switch (frame.Y)
                {
                    case DoorID.CopperDoorStyle:
                    return ModContent.ItemType<CopperDoor>();

                    case DoorID.TinDoorStyle:
                    return ModContent.ItemType<TinDoor>();

                    case DoorID.IronDoorStyle:
                    return ModContent.ItemType<IronDoor>();

                    case DoorID.LeadDoorStyle:
                    return ModContent.ItemType<LeadDoor>();

                    case DoorID.SilverDoorStyle:
                    return ModContent.ItemType<SilverDoor>();

                    case DoorID.TungstenDoorStyle:
                    return ModContent.ItemType<TungstenDoor>();

                    case DoorID.GoldDoorStyle:
                    return ModContent.ItemType<GoldDoor>();

                    case DoorID.PlatinumDoorStyle:
                    return ModContent.ItemType<PlatinumDoor>();
                }
                break;
            }
            return 0;
        }

        public static int ChairDrop(int frameX, int frameY)
        {
            Point frame = GetFrame(frameX, frameY, 2, 2);
            switch (frame.Y)
            {
                case 0:
                return ModContent.ItemType<CopperChair>();
                case 1:
                return ModContent.ItemType<TinChair>();
                case 2:
                return ModContent.ItemType<IronChair>();
                case 3:
                return ModContent.ItemType<LeadChair>();
                case 4:
                return ModContent.ItemType<SilverChair>();
                case 5:
                return ModContent.ItemType<TungstenChair>();
                case 6:
                return ModContent.ItemType<AlternateGoldChair>();
                case 7:
                return ModContent.ItemType<PlatinumChair>();
            }
            return 0;
        }

        public static int TableDrop(int frameX, int frameY)
        {
            Point frame = GetFrame(frameX, frameY, 3, 2);
            switch (frame.X)
            {
                case 0:
                return ModContent.ItemType<CopperTable>();
                case 1:
                return ModContent.ItemType<TinTable>();
                case 2:
                return ModContent.ItemType<IronTable>();
                case 3:
                return ModContent.ItemType<LeadTable>();
                case 4:
                return ModContent.ItemType<SilverTable>();
                case 5:
                return ModContent.ItemType<TungstenTable>();
                case 6:
                return ModContent.ItemType<AlternateGoldTable>();
                case 7:
                return ModContent.ItemType<PlatinumTable>();
            }
            return 0;
        }

        /*public static int StatueDrop(int frameX, int frameY)
        {
            Point frame = GetFrame(frameX, frameY, 4, 4);
            switch (frame.X)
            {
                case 0:
                return ModContent.ItemType<BraycoeStatue>();
                case 1:
                return ModContent.ItemType<NalydStatue>();
                case 2:
                return ModContent.ItemType<HBDeusStatue>();
                case 3:
                return ModContent.ItemType<PufferfisherStatue>();
                case 4:
                return ModContent.ItemType<SlimeladStatue>();
                case 5:
                return ModContent.ItemType<RaccoonStatue>();
                case 6:
                return ModContent.ItemType<UnknownBearStatue>();
                case 7:
                return ModContent.ItemType<BookManStatue>();
                case 8:
                return ModContent.ItemType<RayquazaStatue>();
                case 9:
                return ModContent.ItemType<WoodioStatue>();
            }
            return 0;
        }*/

        public static void KillPlantDust(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            switch (tile.frameX)
            {
                case 0:
                case 18:
                case 36:
                case 54:
                for (int k = 0; k < Main.rand.Next(7, 14); k++)
                    DustOnTile(GetRectangle(i, j), TDustID.Fire);
                DustOnTile(GetRectangle(i, j), TDustID.CollisionFire);
                break;
                case 72:
                case 90:
                case 108:
                for (int k = 0; k < Main.rand.Next(7, 14); k++)
                    DustOnTile(GetRectangle(i, j), 24);
                break;
                case 126:
                case 144:
                for (int k = 0; k < Main.rand.Next(3, 7); k++)
                    DustOnTile(GetRectangle(i, j), 24);
                for (int k = 0; k < Main.rand.Next(3, 7); k++)
                    DustOnTile(GetRectangle(i, j), TDustID.Fire);
                DustOnTile(GetRectangle(i, j), TDustID.CollisionFire);
                break;
                case 162:
                case 180:
                case 198:
                case 216:
                for (int k = 0; k < Main.rand.Next(7, 14); k++)
                    DustOnTile(GetRectangle(i, j), TDustID.Fire);
                DustOnTile(GetRectangle(i, j), TDustID.CollisionFire);
                break;
                case 234:
                case 252:
                case 270:
                for (int k = 0; k < Main.rand.Next(7, 14); k++)
                    DustOnTile(GetRectangle(i, j), 24);
                break;
                case 288:
                case 306:
                for (int k = 0; k < Main.rand.Next(3, 7); k++)
                    DustOnTile(GetRectangle(i, j), 24);
                for (int k = 0; k < Main.rand.Next(3, 7); k++)
                    DustOnTile(GetRectangle(i, j), TDustID.Fire);
                DustOnTile(GetRectangle(i, j), TDustID.CollisionFire);
                break;
            }
        }

        public static Vector2 GetVector(int i, int j) => new Vector2(i * 16, j * 16);

        public static Rectangle GetRectangle(int i, int j) => new Rectangle(i * 16, j * 16, 16, 16);

        public static Point NearbyTile(int i, int j, int checkSize, int checkType, int checkStyle = 0)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int sizeLeft = (int)((checkSize - 1) * 0.5f);
            int sizeRight = (checkSize - 1) - sizeLeft;
            for (int k = 0; k < checkSize; k++)
            {
                for (int l = 0; l < checkSize; l++)
                {
                    int m = i + sizeRight - k;
                    int n = j + sizeRight - l;

                    Tile _tile = Framing.GetTileSafely(m, n);
                    if (_tile.type == checkType)
                    {
                        TileObjectData _object = TileObjectData.GetTileData(_tile);
                        if (_object.Style == checkStyle)
                        {
                            return new Point(m, n);
                        }
                    }
                }
            }
            return Point.Zero;
        }

        public static int DustOnTile(Rectangle rectangle, int type, float scale = 1f) => Dust.NewDust(rectangle.TopLeft(), rectangle.Width, rectangle.Height, type, 0, 0, 0, default, scale);

        public static void DrawStatueExtras(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 0)
            {
                switch (tile.frameX)
                {
                    case 144:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 0, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero);
                    break;
                    case 180:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 0, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 216:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j + 1, new Rectangle(0, 16, 32, 16), Lighting.GetColor(i, j + 1), -MathHelper.PiOver2, Vector2.Zero, 1f, default, default, new Vector2(-16, 16));
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 32, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero);
                    break;
                    case 252:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j + 1, new Rectangle(0, 16, 32, 16), Lighting.GetColor(i, j + 1), -MathHelper.PiOver2, Vector2.Zero, 1f, SpriteEffects.FlipVertically, default, new Vector2(32, 16));
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 32, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 288:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 48, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero);
                    break;
                    case 324:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 48, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 576:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j + 1, new Rectangle(0, 880, 32, 16), Lighting.GetColor(i, j + 1), MathHelper.PiOver2, Vector2.Zero, 1f, SpriteEffects.None, default, new Vector2(-16, 16));
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 864, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero);
                    break;
                    case 612:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j + 1, new Rectangle(0, 880, 32, 16), Lighting.GetColor(i, j + 1), MathHelper.PiOver2, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, default, new Vector2(32, 0));
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i, j - 1, new Rectangle(0, 864, 32, 16), Lighting.GetColor(i, j - 1), default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                }
            }
        }

        public static void DrawStatueGlowMask(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.frameY == 54)
            {
                Color glowColor = new Color(255, 255, 255, 80);
                switch (tile.frameX)
                {
                    case 18:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 336, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 54:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 336, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 90:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 272, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 126:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 272, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 162:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 400, 32, 80), glowColor, default, Vector2.Zero, 1f);
                    break;
                    case 198:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 400, 32, 80), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 234:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 480, 32, 80), glowColor, default, Vector2.Zero);
                    break;
                    case 270:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 480, 32, 80), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 306:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 192, 32, 80), glowColor, default, Vector2.Zero);
                    break;
                    case 342:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 4, new Rectangle(0, 192, 32, 80), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 378:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 64, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 414:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 64, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 450:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 128, 32, 64), glowColor, default, Vector2.Zero, 1f);
                    break;
                    case 486:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 128, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 522:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 560, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 558:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 560, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 594:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 624, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 630:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 624, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 666:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 688, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 702:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 688, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 810:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 752, 32, 64), glowColor, default, Vector2.Zero);
                    break;
                    case 846:
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 752, 32, 64), glowColor, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                    case 882: // FunkItOut (R)
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 800, 32, 64), glowColor * 0.6f, default, Vector2.Zero);
                    break;
                    case 918: // FunkItOut (L)
                    DrawingHelper.TileDraw(ModContent.GetTexture(statueExtrasPath), i - 1, j - 3, new Rectangle(0, 800, 32, 64), glowColor * 0.6f, default, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally);
                    break;
                }
            }
        }

        public static void DrawPlantsExtras(int i, int j, ref Color drawColor)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            const float hellPlantBrightnessMult = 0.4f;
            switch (tile.frameX)
            {
                case 0:
                drawColor = Color.White;
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 18:
                break;
                case 36:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 54:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 126:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 144:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 162:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 180:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 198:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
                case 216:
                Lighting.AddLight(new Vector2(i * 16, j * 16), Color.Orange.ToVector3() * hellPlantBrightnessMult);
                break;
            }
        }

        public static void DrawPlantsPost(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            DrawingHelper.TileDraw(ModContent.GetTexture(plantsExtrasPath), i, j, new Rectangle(tile.frameX, 0, 16, 20), Color.White);
        }

        public static void DrawBlock(Texture2D texture, int i, int j, Color color) => DrawingHelper.TileDraw(texture, i, j, new Rectangle(Main.tile[i, j].frameX, Main.tile[i, j].frameY, 16, 16), color);

        public static void ShowItemIcon(int type)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = type;
        }

        public static int CountTiles(int[] types, Vector2 pos, int tileDistance)
        {
            int count = 0;
            Rectangle rect = new Rectangle(pos.ToTileCoordinates().X - tileDistance, pos.ToTileCoordinates().Y - tileDistance, tileDistance * 2, tileDistance * 2);
            for (int i = rect.X; i < rect.X + rect.Width; i++)
            {
                for (int j = rect.Y; j < rect.Y + rect.Height; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    for (int k = 0; k < types.Length; k++)
                    {
                        if (tile.type == types[k])
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }
    }
}