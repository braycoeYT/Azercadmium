using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class DiscusMedal : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases max mana by 20");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statManaMax2 += 20;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}