using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Aquite
{
	public class AquitePickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Capable of mining Lihzahrd Bricks");
		}
		public override void SetDefaults() {
			item.damage = 32;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.2f;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 210;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AquiteBar"), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}