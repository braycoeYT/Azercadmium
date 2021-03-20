using Azercadmium.Items.Smore;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Snow
{
	public class ColdCrusher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A confectionous battering ram");
		}
		public override void SetDefaults() {
			item.damage = 56;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 58;
			item.useAnimation = 58;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 8.9f;
			item.value = Item.sellPrice(0, 1, 25, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.useTurn = false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddIngredient(ItemID.SnowBlock, 61);
			recipe.AddIngredient(ItemID.IceBlock, 46);
			recipe.AddIngredient(ModContent.ItemType<CocoaBeans>(), 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}