using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Azercadmium.Helpers
{
    public static class MathmaticsHelper
    {
        public static int GetDirection(int x, int x2) => x < x2 ? -1 : x == x2 ? 0 : 1;
        public static int GetDirection(float x, float x2) => x < x2 ? -1 : x == x2 ? 0 : 1;

        public static Vector2 ShootTo(Vector2 startPos, Vector2 shootToPos, float speed) => new Vector2(0, speed).RotatedBy((shootToPos - startPos).ToRotation() - MathHelper.PiOver2);
        public static Vector2 LerpVect2(Vector2 pos1, Vector2 pos2, float amount) => new Vector2(MathHelper.Lerp(pos1.X, pos2.X, amount), MathHelper.Lerp(pos1.Y, pos2.Y, amount));
        public static Vector2 CircleOffset(float repeatTime = 255, float range = 16, int amount = 1, int whoami = 1) => new Vector2((float)(Math.Sin((float)(Main.GameUpdateCount % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2)) * (range / 2)), (float)(Math.Cos((float)(Main.GameUpdateCount % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2f)) * (range / 2f))).RotatedBy(MathHelper.TwoPi / amount * whoami);
        public static Vector2 CircleOffset(int currentTime, float repeatTime = 255, float range = 16, int amount = 1, int whoami = 1) => new Vector2((float)(Math.Sin((float)(currentTime % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2)) * (range / 2)), (float)(Math.Cos((float)(currentTime % (MathHelper.Pi * (repeatTime * 2))) / (repeatTime / 2f)) * (range / 2f))).RotatedBy(MathHelper.TwoPi / amount * whoami);
    }
}