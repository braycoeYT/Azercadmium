using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace Azercadmium.Items.Nova
{
	public class MysteriousNova : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Sent from something powerful in deep space, this could help you in your adventure...\nNote: Still a work in progress");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(116, 179, 237);
                }
            }
        }
	}
}