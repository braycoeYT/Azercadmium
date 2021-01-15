using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Neutron
{
	public class NeutronFragment : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Neutron Fragment");
			Tooltip.SetDefault("The manifestations of death and intensity inhabit this heavily dense fragment");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Cyan;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}