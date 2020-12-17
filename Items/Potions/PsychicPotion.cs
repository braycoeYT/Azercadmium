using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Potions
{
    public class PsychicPotion : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Greatly increases mana regen at the cost of losing a small amount of health");
        }
        public override void SetDefaults() {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.buffType = mod.BuffType("Psychic");
            item.buffTime = 25200;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(mod.ItemType("LabyrinthFish"));
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}