using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Zinc.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ZincLeggings : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 13, 0);
			item.defense = 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}