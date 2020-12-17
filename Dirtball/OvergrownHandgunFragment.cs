using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class OvergrownHandgunFragment : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("How much damage did you expect a gun this moldy to do?\nOnly at 0.1% of its power");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 27;
			item.useTime = 27;
			item.damage = 1;
			item.width = 26;
			item.height = 24;
			item.knockBack = 1.2f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = -1;
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