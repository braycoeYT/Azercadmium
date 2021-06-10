using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Sounds.Item
{
    public class Baseball_0 : ModSound
    {
        public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
        {
            soundInstance = sound.CreateInstance();
            soundInstance.Volume = volume * 0.66f;
            soundInstance.Pan = pan;
            soundInstance.Pitch = -Main.rand.NextFloat(-1f, 0.25f);
            return soundInstance;
        }
    }
}