using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Azercadmium.Aaa
{
    [Label("Client Config")]
    public class AZConfigClient : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Worldgen")]

        /*[Label("Generate Crimson/Corruption Lake")]
        [Tooltip("Toggles whether the lake in the evil biome step will be ran")]
        //[DefaultValue(true)]
        public bool generateEvilLake;*/

        [Label("Generate Ember Glades Lake")]
        [Tooltip("Toggles whether the lake in the ember glades biome step will be ran")]
        [DefaultValue(true)]
        public bool generateEmberGladesLake;

        [Label("Generate Ember Glades")]
        [Tooltip("Toggles whether the ember glades biome step will be ran")]
        [DefaultValue(true)]
        public bool generateEmberGlades;

        /*[Label("Generate Everfrost")]
        [Tooltip("Toggles whether the everfrost biome step will be ran")]
        [DefaultValue(true)]
        public bool generateEverfrost;*/

        public override void OnLoaded() => Azercadmium.clientConfigInstance = this;
    }
}