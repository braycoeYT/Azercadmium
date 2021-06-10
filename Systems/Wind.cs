using Microsoft.Xna.Framework;
using System;
using Terraria;
using Azercadmium.Enums;

namespace Azercadmium.Systems
{
    public static class Wind
    {
        public static bool HellWindyDay => Math.Abs(HellWind.VisibleWindSpeed) > 20 || HellWind._WindState == LegacyWindState.Windy;

        public static float GetWindSpeed(Vector2 position)
        {
            int realY = position.ToTileCoordinates().Y;
            if (realY < Main.worldSurface)
            {
                return Main.windSpeed * 100;
            }
            if (realY > Main.maxTilesY - 200)
            {
                return HellWind.VisibleWindSpeed;
            }
            return 0;
        }

        public static float GetWindOffset(Vector2 position, float offsetTime = 0, float offsetMult1 = 0.005f, float offsetMult2 = 0.33f)
        {
            float speed = GetWindSpeed(position);
            return speed - (float)Math.Sin((position.Y + position.X + offsetTime) * offsetMult1) * ((speed + 1) * offsetMult2);
        }
    }
}