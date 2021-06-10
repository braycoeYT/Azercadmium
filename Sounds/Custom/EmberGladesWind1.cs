using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Sounds.Custom
{
    public class EmberGladesWind1 : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            if (soundInstance.State == SoundState.Playing)
            {
                return null;
            }
            soundInstance.Volume = volume * 0.33f;
            soundInstance.Pan = pan;
            return soundInstance;
        }
    }
}