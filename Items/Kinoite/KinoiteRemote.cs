using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Kinoite
{
	public class KinoiteRemote : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons a friendly Kinoite rover to follow you\nThe rover can scan for rare enemies nearby");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Kinoite.KinoiteRover>();
			item.buffType = BuffType<Buffs.Pets.KinoiteRoverBuff>();
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.width = 24;
			item.height = 24;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 600, true);
			}
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KinoiteBar>(), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}