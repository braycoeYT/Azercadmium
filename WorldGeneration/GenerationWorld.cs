using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Azercadmium.Enums;
using Azercadmium.Systems;

namespace Azercadmium.WorldGeneration
{
    [Obsolete("Replaced with TestAzercadmiumWorld")]
    public class GenerationWorld : ModWorld
    {
        public static int realWindSpeed;
        public static LegacyWindState windState;

        public override void Initialize() => HellWind.windSpeedIntensity = WorldGen.genRand.NextFloat(1);

        public override TagCompound Save()
        {
            return new TagCompound()
            {
                ["realWindSpeed"] = realWindSpeed,
                ["windState"] = (int)windState,
            };
        }

        public override void Load(TagCompound tag)
        {
            HellWind.VisibleWindSpeed = realWindSpeed = tag.GetInt("realWindSpeed");
            windState = (LegacyWindState)tag.GetInt("windState");
        }

        public override void PostUpdate()
        {
            HellWind.Update();
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(realWindSpeed);
            writer.Write(HellWind.VisibleWindSpeed);
            writer.Write(HellWind.windSpeedIntensity);
        }

        public override void NetReceive(BinaryReader reader)
        {
            realWindSpeed = reader.ReadInt32();
            HellWind.VisibleWindSpeed = reader.ReadInt32();
            HellWind.windSpeedIntensity = reader.ReadInt32();
        }
    }
}
