using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Sky
{
	public class FeatherfallShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Featherfall Shield");
			Tooltip.SetDefault("Hold the W key to fall slower");
		}
		public override void SetDefaults() {
			item.width = 58;
			item.height = 28;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.defense = 1;
			item.channel = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			if (player.controlUp)
			player.slowFall = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 18);
			recipe.AddIngredient(ItemID.RainCloud, 11);
			recipe.AddIngredient(ItemID.Feather, 6);
			recipe.AddIngredient(ItemID.FeatherfallPotion, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}