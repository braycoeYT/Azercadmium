using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Developer.Braycoe
{
    public class SlimePheromoneSpray : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Makes most slimes friendly");
        }
        public override void SetDefaults() {
            item.width = 14;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.buffType = ModContent.BuffType<Buffs.Potions.SlimePheromones>();
            item.buffTime = 54000;
        }
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Gel, 6);
			recipe.AddIngredient(ItemID.PinkGel, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}