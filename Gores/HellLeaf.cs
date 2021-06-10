using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Azercadmium.Systems;

namespace Azercadmium.Gores
{
    public class HellLeaf : ModGore
    {
        private const int goreTimeLeftMax = 666;
        private const int goreFadeTime = 566;
        private const int difference = goreTimeLeftMax - goreFadeTime;

        public override void OnSpawn(Gore gore)
        {
            gore.numFrames = 8;
            gore.timeLeft = goreTimeLeftMax;
            gore.scale = WorldGen.genRand.NextFloat(0.85f, 1.15f);
            gore.frame = (byte)WorldGen.genRand.Next(4);
            gore.behindTiles = true;
        }

        public override bool Update(Gore gore)
        {
            float windSpeed = Wind.GetWindSpeed(gore.position);
            gore.velocity.X = windSpeed * 0.1f;
            gore.velocity.Y = MathHelper.Clamp(windSpeed * 0.01f, 2.22f, 6.66f);
            gore.velocity = gore.velocity.RotatedBy(Math.Sin(gore.position.Y * 0.014f + gore.position.X * 0.014f + Main.GameUpdateCount * 0.066f) * (0.785f + windSpeed * 0.00785f));
            gore.frameCounter++;
            if (gore.frameCounter == 6)
            {
                gore.frame++;
                if (gore.frame >= 8)
                {
                    gore.frame = 0;
                }
                gore.frameCounter = 0;
            }
            gore.position += gore.velocity;
            if (goreTimeLeftMax - gore.timeLeft > goreFadeTime)
            {
                float _difference = gore.timeLeft - goreFadeTime;
                gore.alpha = (int)MathHelper.Lerp(0, 255, _difference / difference);
            }
            gore.rotation = gore.velocity.ToRotation() + MathHelper.PiOver2;
            if (gore.timeLeft <= 0)
            {
                gore.active = false;
            }
            gore.timeLeft--;
            return false;
        }
    }
}