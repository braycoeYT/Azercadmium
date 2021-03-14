using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Potions
{
    public class PenetrationPotion : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Increases max javelin pierce by 2\nMakes javelins with no extra pierce instead strike a foe 2 extra times");
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
            item.buffType = mod.BuffType("Penetration");
            item.buffTime = 21600;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}