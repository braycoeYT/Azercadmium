using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Adamantite
{
	[AutoloadEquip(EquipType.Head)]
	public class WearableAdamantiteBar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Pretend to be a certain talking Adamantite Bar, I guess.");
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 22;
			item.value = Item.sellPrice(0, 7, 50, 0);
			item.rare = ItemRarityID.Orange;
			item.vanity = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}