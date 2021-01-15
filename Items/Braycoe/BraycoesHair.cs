using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Braycoe
{
	[AutoloadEquip(EquipType.Head)]
	public class BraycoesHair : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Braycoe's Hair");
			Tooltip.SetDefault("Great for impersonating Azercadmium devs!");
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 22;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
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