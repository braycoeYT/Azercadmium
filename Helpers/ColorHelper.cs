using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Azercadmium.Helpers
{
    [Obsolete("Replaced with internal Mod methods")]
    public static class ColorHelper
    {
        public static Color ColorLerp(Color[] colors, float time, float offset = 0f)
        {
            float c = 1f / time;
            float fade = (Main.GameUpdateCount + offset) * c % 1;
            int index = (int)((Main.GameUpdateCount + offset) * c % colors.Length);
            return Color.Lerp(colors[index], colors[(index + 1) % colors.Length], fade);
        }

        public static Color MovingRainbow(float time = 30, float offset = 0f)
        {
            return ColorLerp(new Color[]
            {
                    Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Violet, Color.Magenta,
            },
            time, offset);
        }

        public static Color Rainbow(float time = 30, float offset = 0f)
        {
            Color[] colors = new Color[]
            {
                    Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Violet, Color.Magenta,
            };
            float c = 1f / time;
            float fade = offset * c % 1;
            int index = (int)(offset * c % colors.Length);
            return Color.Lerp(colors[index], colors[(index + 1) % colors.Length], fade);
        }

        public static Color EmberGladesColor2 => Color.White * 0.8f * (float)((Math.Sin(Main.GameUpdateCount % MathHelper.Pi) + 1) * 0.45f);
    }
}