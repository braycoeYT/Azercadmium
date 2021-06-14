using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots a very fast bolt of lightning that can bounce off of tiles and pierce enemies many times\nEach bolt ignores immunity frames and hits 5x faster than normal projectiles");
			Item.staff[item.type] = true;
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 17;
			item.useTime = 17;
			item.damage = 174;
			item.width = 28;
			item.height = 30;
			item.knockBack = 1.8f;
			item.shoot = ModContent.ProjectileType<Projectiles.Kinoite.KinoiteStaffBolt>();
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
			item.mana = 6;
			item.UseSound = SoundID.Item116;
			item.color = Color.AliceBlue;
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