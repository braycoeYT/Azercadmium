using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class OvergrownElectricalComponent : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("How much damage did you expect a magic gun this rotten to do?\nOnly at 0.1% of its power");
		}
		public override void SetDefaults() {
			item.damage = 1;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1.2f;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.rare = -1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ElectricBoltPassive");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 1;
			item.UseSound = SoundID.Item91;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 0);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(71, 45, 34);
                }
            }
        }
	}
}