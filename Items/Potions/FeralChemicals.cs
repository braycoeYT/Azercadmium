using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Potions
{
    public class FeralChemicals : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Increases melee speed by 10%");
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
            item.value = 250;
            item.buffType = mod.BuffType("Feral");
            item.buffTime = 21600;
        }
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}