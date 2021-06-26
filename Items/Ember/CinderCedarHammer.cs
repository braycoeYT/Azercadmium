using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
	public class CinderCedarHammer : ModItem
	{
		public override void SetDefaults() {
			item.damage = 27;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 14;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.5f;
			item.value = Item.sellPrice(gold: 2, silver: 27);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.hammer = 80;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ModContent.ItemType<Darkron.DarkronBar>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}