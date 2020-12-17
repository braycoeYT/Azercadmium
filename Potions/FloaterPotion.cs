using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Potions
{
    public class FloaterPotion : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Increases max wingtime");
        }
        public override void SetDefaults() {
            item.width = 32;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = 425;
            item.buffType = mod.BuffType("Floater");
            item.buffTime = 21600;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Feather, 1);
			recipe.AddIngredient(ItemID.SoulofFlight, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();

            Mod xtraarmory = ModLoader.GetMod("Xtraarmory");
			if (xtraarmory != null) {
                recipe = new ModRecipe(mod);
			    recipe.AddIngredient(mod.ItemType("ThrowableFloatingPotion"), 150);
			    recipe.AddTile(TileID.Bottles);
			    recipe.SetResult(this);
			    recipe.AddRecipe();
            }
		}
    }
}