using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Accessories
{
	public class BeakerofLightning : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Beaker of Lightning");
			Tooltip.SetDefault("Grants immunity to electricity");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[BuffID.Electrified] = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(mod.ItemType("Electrolight"), 20);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}