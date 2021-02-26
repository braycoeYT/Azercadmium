using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Dusts
{
    public class DesertRoseDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.frame = new Rectangle(Main.rand.NextBool() ? 0 : 16, 16 * Main.rand.Next(4), 14, 14);
            dust.noLight = false;
        }
        public override Color? GetAlpha(Dust dust, Color lightColor) => Color.White;

        public override bool MidUpdate(Dust dust)
        {
            dust.rotation = 0f;
            Lighting.AddLight(dust.position, Color.White.ToVector3() * 0.1f);
            return true;
        }
    }
}