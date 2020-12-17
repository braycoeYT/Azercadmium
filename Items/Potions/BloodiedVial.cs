using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Potions
{
    public class BloodiedVial : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Gives you a 6% chance of any javelance to leech health from enemies");
        }
        public override void SetDefaults() {
            item.width = 20;
            item.height = 28;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = 300;
            item.buffType = mod.BuffType("BloodDrop");
            item.buffTime = 25200;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(ItemID.WormTooth);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddIngredient(mod.ItemType("BloodySpiderLeg"));
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}