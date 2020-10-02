using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Other.Masks
{
	[AutoloadEquip(EquipType.Head)]
	public class PolandballMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Can Polandball into space?");
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 22;
			item.value = Item.sellPrice(0, 0, 5, 0);
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