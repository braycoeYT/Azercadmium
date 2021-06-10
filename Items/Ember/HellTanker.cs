using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Systems;
using Azercadmium.WorldGeneration;
using Azercadmium.Aaa;

namespace Azercadmium.Items.Ember
{
    public class HellTanker : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Tanker");
            Tooltip.SetDefault("Displays the wind speed in hell");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WeatherRadio);
            item.SetShopValues(2, Item.sellPrice(gold: 5));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(mod, "Wind1", "Wind Speed: " + HellWind.VisibleWindSpeed)
            { overrideColor = Color.Orange });
            tooltips.Add(new TooltipLine(mod, "Wind1", "Real Wind Speed: " + HellWind.WindSpeed)
            { overrideColor = Color.Orange });
            tooltips.Add(new TooltipLine(mod, "Wind1", "Wind Speed I: " + HellWind.windSpeedIntensity)
            { overrideColor = Color.Orange });
            tooltips.Add(new TooltipLine(mod, "Wind1", "Wind State: " + GenerationWorld.windState)
            { overrideColor = Color.Orange });
        }

        public override void UpdateInventory(Player player) => player.ModPlayer().hellTanker = true;

        public override void UpdateAccessory(Player player, bool hideVisual) => player.ModPlayer().hellTanker = true;
    }
}