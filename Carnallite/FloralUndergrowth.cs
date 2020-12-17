using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class FloralUndergrowth : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("An amalgamation of the jungle");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8)); //first is speed, second is amount of frames
		}
		public override void SetDefaults() {
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = ItemRarityID.Yellow;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddIngredient(ItemID.MudBlock);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddIngredient(mod.ItemType("PlanteraTooth"));
			recipe.AddIngredient(ItemID.ChlorophyteBar);
			recipe.AddIngredient(mod.ItemType("CarnalliteBar"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 6);
			recipe.AddRecipe();
		}
	}
}