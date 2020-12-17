using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Smore
{
	public class Smore : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("S'more");
			Tooltip.SetDefault("I'd get s'more puns, but there are none left...");
		}
		public override void SetDefaults() {
			item.width = 32;
			item.height = 24;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.buffType = BuffID.WellFed;
            item.buffTime = 43200;
			item.potion = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GrahamCracker"));
			recipe.AddIngredient(mod.ItemType("CocoaBeans"));
			recipe.AddIngredient(ItemID.CookedMarshmallow);
			recipe.AddTile(TileID.Campfire);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}