using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Dusts
{
    public class WhiteGlowOrbDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.frame = new Rectangle(0, 0, 14, 14);
            dust.noLight = false;
            dust.noGravity = true;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor) => Color.White;

        public override bool Update(Dust dust)
        {
            dust.scale *= 0.93f;
            if (dust.scale < 0.1f)
                dust.active = false;
            if (!dust.noLight)
                Lighting.AddLight(dust.position, dust.color.ToVector3());
            dust.position += dust.velocity;
            dust.velocity *= 0.97f;
            if (!dust.noGravity)
                dust.velocity.Y += 0.1f;
            return false;
        }
    }
}