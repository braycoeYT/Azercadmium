using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class Redemption : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a slow moving Kinoite Lightning Orb\nThe lightning orb shoots Kinoite bolts which explode on contact behind it\nThe lightning orb also releases several Kinoite energy bits to chase enemies");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 76;
			item.useTime = 76;
			item.damage = 89;
			item.width = 28;
			item.height = 30;
			item.knockBack = 5.4f;
			item.shoot = ModContent.ProjectileType<Projectiles.Kinoite.KinoiteLightningOrb>();
			item.shootSpeed = 4f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
			item.mana = 22;
			item.UseSound = SoundID.Item116;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KinoiteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}