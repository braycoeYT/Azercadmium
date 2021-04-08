using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium
{
    public static class AzercadmiumUtils
    {
        public static bool debugMode;

        public static void Initialize()
        {
            // Runs all initializing methods, only use in mod.PostSetupContent
            ReferenceSamples.Initialize();
            debugMode = false; // Set to true when debugging or testing
        }

        public static void Unload()
        {
            // Runs all unloading methods, only run in mod.Unload
            ReferenceSamples.Unload();
        }

        public static class ID
        {
            /*public static class ModItemID
            {
                public static void Initialize()
                {
                    Narrizuul = ModContent.ItemType<Items.Developer.Nalyddd.Narrizuul>();
                }

                public static int Narrizuul;
            }*/

            public static class GoreID
            {
                public static int RandomCloudPuff() => Main.rand.Next(3) + 11;
                public static int RandomSmokePuff() => Main.rand.Next(3) + 61;

                public const int CloudPuff = 11;
                public const int CloudPuff2 = 12;
                public const int CloudPuff3 = 13;
                public const int SmokePuff = 61;
                public const int SmokePuff2 = 62;
                public const int SmokePuff3 = 63;
            }
        }

        public static class Mathmatics
        {
            public const float NinePi = 28.2743338f; // 
            public const float EightPi = 25.1327412f; // 
            public const float SevenPi = 21.9911485f; // 
            public const float SixPi = 18.8495559f; //
            public const float FivePi = 15.7079632f; // I'm too lazy to do the rest
            public const float FourPi = 12.5663706f; // 720r
            public const float ThreePi = 9.42477796f; // 540r 
            public const float TwoPi = 6.28318530f; // 360r
            public const float Pi = 3.14159265f; // 180r
            public const float PiOver2 = 1.57079632f; // 90r
            public const float PiOver3 = 1.04719755f; // 60r
            public const float PiOver4 = 0.78539816f; // 45r
            public const float PiOver5 = 0.62831853f; // 36r
            public const float PiOver6 = 0.52359877f; // 30r
            public const float PiOver7 = 0.44879895f; // 25.7142857r
            public const float PiOver8 = 0.39269908f; // 22.5r
            public const float PiOver9 = 0.34906585f; // 20r

            public struct PointLine
            {
                public Point Point1;
                public Point Point2;

                public PointLine(Point point1, Point point2)
                {
                    Point1 = point1;
                    Point2 = point2;
                }

                public PointLine(int x1, int y1, int x2, int y2)
                {
                    Point1 = new Point(x1, y1);
                    Point2 = new Point(x2, y2);
                }

                public PointLine(int x1, int y1, Point point2)
                {
                    Point1 = new Point(x1, y1);
                    Point2 = point2;
                }

                public PointLine(Point point1, int x2, int y2)
                {
                    Point1 = point1;
                    Point2 = new Point(x2, y2);
                }
            }
            public struct LineVector
            {
                public Vector2 Coordinate1;
                public Vector2 Coordinate2;

                #region Construtors
                public LineVector(Vector2 coord1, Vector2 coord2)
                {
                    Coordinate1 = coord1;
                    Coordinate2 = coord2;
                }

                public LineVector(float coord1X, float coord1Y, float coord2X, float coord2Y)
                {
                    Coordinate1 = new Vector2(coord1X, coord1Y);
                    Coordinate2 = new Vector2(coord2X, coord2Y);
                }

                public LineVector(Vector2 coord1, float coord2X, float coord2Y)
                {
                    Coordinate1 = coord1;
                    Coordinate2 = new Vector2(coord2X, coord2Y);
                }

                public LineVector(float coord1X, float coord1Y, Vector2 coord2)
                {
                    Coordinate1 = new Vector2(coord1X, coord1Y);
                    Coordinate2 = coord2;
                }

                public LineVector(Point coord1, Point coord2)
                {
                    Coordinate1 = new Vector2(coord1.X, coord1.Y);
                    Coordinate2 = new Vector2(coord2.X, coord2.Y);
                }

                public LineVector(Point coord1, float coord2X, float coord2Y)
                {
                    Coordinate1 = new Vector2(coord1.X, coord1.Y);
                    Coordinate2 = new Vector2(coord2X, coord2Y);
                }

                public LineVector(float coord1X, float coord1Y, Point coord2)
                {
                    Coordinate1 = new Vector2(coord1X, coord1Y);
                    Coordinate2 = new Vector2(coord2.X, coord2.Y);
                }
                #endregion

                public void ToVector2(LineVector line, out Vector2 Vector2One, out Vector2 Vector2Two)
                {
                    Vector2One = line.Coordinate1;
                    Vector2Two = line.Coordinate2;
                }

                public float Length(LineVector line) => (line.Coordinate1 - line.Coordinate2).Length();

                public float ToRotation() => (Coordinate1 - Coordinate2).ToRotation();

                public Vector2 HalfVector() => Coordinate1 - (Coordinate2 * 0.5f);

                public LineVector LineFromWidth(Rectangle rectangle) => new LineVector(rectangle.X, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y);

                public LineVector LineFromHeight(Rectangle rectangle) => new LineVector(rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height);

                public LineVector RotateByCoordinate1(float radians) => new LineVector(Coordinate1, Coordinate1 + (Coordinate1 - Coordinate2).RotatedBy(radians));

                public LineVector RotateByCoordinate2(float radians) => new LineVector(Coordinate2 + (Coordinate2 - Coordinate1).RotatedBy(radians), Coordinate2);

                public bool ShouldExist() => Coordinate1 != Coordinate2;

                public PointLine GetPoints() => new PointLine(new Point((int)Coordinate1.X, (int)Coordinate1.Y), new Point((int)Coordinate2.X, (int)Coordinate2.Y));

                public PointLine GetTilePoints() => new PointLine(new Point((int)(Coordinate1.X * 0.0625f), (int)(Coordinate1.Y * 0.0625f)), new Point((int)(Coordinate2.X * 0.0625f), (int)(Coordinate2.Y * 0.0625f)));

                public List<Point> GetPointLine()
                {
                    List<Point> points = new List<Point>();
                    PointLine twoPoint = GetPoints();
                    int dX = -GetDirection(twoPoint.Point1.X, twoPoint.Point2.X);
                    int dY = -GetDirection(twoPoint.Point1.Y, twoPoint.Point2.Y);
                    int differenceX = twoPoint.Point1.X - twoPoint.Point2.X;
                    int differenceY = twoPoint.Point1.Y - twoPoint.Point2.Y;
                    int x = twoPoint.Point1.X;
                    int y = twoPoint.Point1.Y;

                    if (debugMode)
                    {
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(dX) + ": " + dX);
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(dY) + ": " + dY);
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(differenceX) + ": " + differenceX);
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(differenceY) + ": " + differenceY);
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(x) + ": " + x);
                        ReferenceSamples.azercadmium.Logger.Debug(nameof(y) + ": " + y);
                    }

                    for (int i = 0; i < (Math.Abs(differenceX) + 1); i++)
                    {
                        points.Add(new Point(x, y));
                        x += dX;

                        bool flag = false;
                        if (Math.Abs(differenceY) > 0 && dY != 0) // So it never divides by zero
                        {
                            for (int j = 1; j < (Math.Abs(differenceY) + 1); j++)
                            {
                                int quotient = (int)Math.Abs(differenceX / (float)differenceY * j);

                                if (debugMode)
                                {
                                    ReferenceSamples.azercadmium.Logger.Debug(nameof(i) + ": " + i);
                                    ReferenceSamples.azercadmium.Logger.Debug(nameof(j) + ": " + j);
                                    ReferenceSamples.azercadmium.Logger.Debug(nameof(quotient) + ": " + quotient);
                                }

                                if (i < quotient)
                                    break;

                                if (i == quotient)
                                {
                                    if (flag)
                                    {
                                        points.Add(new Point(x, y));
                                    }

                                    y += dY;
                                    flag = true;
                                }
                            }
                        }
                        else
                        {
                            if (i >= (Math.Abs(differenceX)))
                                break;
                        }
                    }
                    return points;
                }

                // Don't really have good ideas for these
                public override bool Equals(object obj) => false;

                public override int GetHashCode() => 0;

                public override string ToString() => "{Coordinate1: " + Coordinate1 + " Coordinate2: " + Coordinate2 + "}";

                #region Operators
                public static LineVector operator +(LineVector value1, LineVector value2) => new LineVector(value1.Coordinate1 + value1.Coordinate2, value2.Coordinate1 + value2.Coordinate2);

                public static LineVector operator -(LineVector value1, LineVector value2) => new LineVector(value1.Coordinate1 - value1.Coordinate2, value2.Coordinate1 - value2.Coordinate2);

                public static LineVector operator *(LineVector value1, LineVector value2) => new LineVector(value1.Coordinate1 * value1.Coordinate2, value2.Coordinate1 * value2.Coordinate2);

                public static LineVector operator /(LineVector value1, LineVector value2) => new LineVector(value1.Coordinate1 / value1.Coordinate2, value2.Coordinate1 / value2.Coordinate2);

                public static bool operator ==(LineVector value1, LineVector value2) => value1.Coordinate1 == value2.Coordinate1 && value1.Coordinate2 == value2.Coordinate2;

                public static bool operator !=(LineVector value1, LineVector value2) => value1.Coordinate1 != value2.Coordinate1 && value1.Coordinate2 != value2.Coordinate2;
                #endregion
            }

            public static int GetDirection(int x, int x2) => x < x2 ? -1 : x == x2 ? 0 : 1;
            public static int GetDirection(float x, float x2) => x < x2 ? -1 : x == x2 ? 0 : 1;

            public static Vector2 ShootTo(Vector2 startPos, Vector2 shootToPos, float speed) => new Vector2(0, speed).RotatedBy((shootToPos - startPos).ToRotation() - MathHelper.PiOver2);
            public static Vector2 LerpVect2(Vector2 pos1, Vector2 pos2, float amount) => new Vector2(MathHelper.Lerp(pos1.X, pos2.X, amount), MathHelper.Lerp(pos1.Y, pos2.Y, amount));
            public static Vector2 CircleOffset(float repeatTime = 255, float range = 16, int amount = 1, int whoami = 1) => new Vector2((float)(Math.Sin((float)(Main.GameUpdateCount % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2)) * (range / 2)), (float)(Math.Cos((float)(Main.GameUpdateCount % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2f)) * (range / 2f))).RotatedBy(MathHelper.TwoPi / amount * whoami);
            public static Vector2 CircleOffset(int currentTime, float repeatTime = 255, float range = 16, int amount = 1, int whoami = 1) => new Vector2((float)(Math.Sin((float)(currentTime % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2)) * (range / 2)), (float)(Math.Cos((float)(currentTime % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2f)) * (range / 2f))).RotatedBy(MathHelper.TwoPi / amount * whoami);
        }

        public static class Colorful
        {
            public static Color ColorLerp(Color[] colors, int time)
            {
                float c = 1f / time;
                float fade = Main.GameUpdateCount * c % 1;
                int index = (int)(Main.GameUpdateCount * c % colors.Length);
                return Color.Lerp(colors[index], colors[(index + 1) % colors.Length], fade);
            }

            public static Color MintChocolateRarity => ColorLerp(new Color[] { new Color(146, 255, 138), new Color(97, 56, 10), }, 30);
        }

        public static class Text
        {
            public static string TurnIntoItemText(int num, int stack = 1) => "[i/s" + stack + ":" + num + "]";
            public static string TurnIntoItemText(short num, int stack = 1) => "[i/s" + stack + ":" + num + "]";
        }

        public static class ReferenceSamples
        {
            public static Mod azercadmium;
            public static Mod bossChecklist;

            public static void Initialize()
            {
                azercadmium = ModLoader.GetMod("Azercadmium");
                bossChecklist = ModLoader.GetMod("BossChecklist");
            }

            public static void Unload()
            {
                azercadmium = null;
                bossChecklist = null;
            }
        }
        public static bool BossAlive() {
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Main.npc[i].active && (Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead)) {
					return true;
				}
            }
			return false;
        }
    }
    public static class NPCU 
    { 
        public static bool BossAlive() {
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Main.npc[i].active && (Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead)) {
					return true;
				}
            }
			return false;
        }
    }
     public static class ModUtils
    {
        public static Mod mod = ModLoader.GetMod("Azercadmium");
        public static bool debugMode;
        public static class Player
        {
            public static bool UseAmmo(Terraria.Player player, int type, int removeAmount = 1)
            {
                // Checks ammo / coin slots first
                for (int i = 0; i < 8; i++)
                {
                    int _i = i + 50; // The real inventory slot
                    Item item = player.inventory[_i];
                    if (debugMode)
                    {
                        Main.NewText(nameof(_i) + ": " + _i);
                        Main.NewText("ammo: " + item.ammo);
                        Main.NewText("stack: " + item.stack);
                        Main.NewText("consumable: " + item.consumable);
                    }
                    if (item.ammo == type && item.stack > 0)
                    {
                        if (item.consumable)
                            item.stack -= removeAmount;
                        return true;
                    }
                }
                for (int i = 0; i < Main.realInventory; i++)
                {
                    Item item = player.inventory[i];
                    if (debugMode)
                    {
                        Main.NewText(nameof(i) + ": " + i);
                        Main.NewText("ammo: " + item.ammo);
                        Main.NewText("stack: " + item.stack);
                        Main.NewText("consumable: " + item.consumable);
                    }
                    if (item.ammo == type && item.stack > 0)
                    {
                        if (item.consumable)
                            item.stack -= removeAmount;
                        return true;
                    }
                }
                return false;
            }

            public static bool UseAmmo(Terraria.Player player, int type, out int ammoTypeUsed, int removeAmount = 1)
            {
                // Checks ammo / coin slots first
                for (int i = 0; i < 8; i++)
                {
                    int _i = i + 50; // The real inventory slot
                    Item item = player.inventory[_i];
                    if (debugMode)
                    {
                        Main.NewText(nameof(_i) + ": " + _i);
                        Main.NewText("ammo: " + item.ammo);
                        Main.NewText("stack: " + item.stack);
                        Main.NewText("consumable: " + item.consumable);
                        Main.NewText("shoot: " + item.shoot);
                    }
                    if (item.ammo == type && item.stack > 0)
                    {
                        if (item.consumable)
                            item.stack -= removeAmount;
                        ammoTypeUsed = item.type;
                        return true;
                    }
                }
                for (int i = 0; i < Main.realInventory; i++)
                {
                    Item item = player.inventory[i];
                    if (debugMode)
                    {
                        Main.NewText(nameof(i) + ": " + i);
                        Main.NewText("ammo: " + item.ammo);
                        Main.NewText("stack: " + item.stack);
                        Main.NewText("consumable: " + item.consumable);
                    }
                    if (item.ammo == type && item.stack > 0)
                    {
                        if (item.consumable)
                            item.stack -= removeAmount;
                        ammoTypeUsed = item.type;
                        return true;
                    }
                }
                ammoTypeUsed = 0;
                return false;
            }
        }
    }
}