using Microsoft.Xna.Framework;
using System;
using Terraria;
using Azercadmium.Enums;
using Azercadmium.WorldGeneration;

namespace Azercadmium.Systems
{
    public static class HellWind
    {
        private static float visibleWindSpeed;

        public const float windIntensityMax = 0.02f;
        public const float windIntensityMin = 0.00785f;
        public static float VisibleWindSpeed { get => visibleWindSpeed; set => visibleWindSpeed = value; }
        public static int WindSpeed { get => GenerationWorld.realWindSpeed; set => GenerationWorld.realWindSpeed = value; }
        public static float windSpeedIntensity;
        public static LegacyWindState _WindState { get => GenerationWorld.windState; set => GenerationWorld.windState = value; }

        public static void Update()
        {
            visibleWindSpeed = MathHelper.Lerp(visibleWindSpeed, WindSpeed, windSpeedIntensity);
            if (Math.Abs(visibleWindSpeed) > Math.Abs(WindSpeed) - 0.01f && Math.Abs(visibleWindSpeed) < Math.Abs(WindSpeed) + 0.01f)
            {
                visibleWindSpeed = WindSpeed;
            }
            if (visibleWindSpeed == WindSpeed)
            {
                if (_WindState == LegacyWindState.Dying)
                {
                    if (WorldGen.genRand.NextBool((int)MathHelper.Clamp(1225 - Math.Abs(WindSpeed * 20), 20, 2000)))
                    {
                        WindSpeed = (int)MathHelper.Clamp(WorldGen.genRand.Next(Math.Abs(WindSpeed) - 8, Math.Abs(WindSpeed) + 2) * (WindSpeed < 0 ? -1 : 1), -50, 50);
                    } 
                }
                else
                {
                    if (WorldGen.genRand.NextBool(1000))
                    {
                        WindSpeed = (int)MathHelper.Clamp(WorldGen.genRand.Next(WindSpeed - 5, WindSpeed + 5), -50, 50);
                    }
                }
            }
            else
            {
                if (windSpeedIntensity <= windIntensityMin || windSpeedIntensity > windIntensityMax)
                    windSpeedIntensity = WorldGen.genRand.NextFloat(windIntensityMax);
                windSpeedIntensity = MathHelper.Lerp(windSpeedIntensity, 0, windSpeedIntensity * 0.002f);
            }
            if (Math.Abs(WindSpeed) > 8)
            {
                if (GenerationWorld.windState == LegacyWindState.Normal || GenerationWorld.windState == LegacyWindState.Windy)
                {
                    if (WorldGen.genRand.NextBool(1225 - Math.Abs(WindSpeed * 20)))
                    {
                        GenerationWorld.windState = LegacyWindState.Dying;
                    }
                }
            }
            else
            {
                if (GenerationWorld.windState == LegacyWindState.Dying)
                {
                    if (WorldGen.genRand.NextBool(500 - Math.Abs(WindSpeed * 15)))
                    {
                        GenerationWorld.windState = LegacyWindState.Normal;
                    }
                }
                else
                {
                    if (WorldGen.genRand.NextBool(500 - Math.Abs(WindSpeed * 15)))
                    {
                        GenerationWorld.windState = LegacyWindState.Intensifying;
                    }
                }
            }
            if (Math.Abs(WindSpeed) < 2)
            {
                GenerationWorld.windState = LegacyWindState.Normal;
            }
            if (Math.Abs(WindSpeed) > 20 && GenerationWorld.windState != LegacyWindState.Dying)
            {
                GenerationWorld.windState = LegacyWindState.Windy;
            }
        }
    }
}