using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Zinc
{
	public class ZincBroadsword : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 11;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.1f;
			item.value = Item.sellPrice(0, 0, 5, 80);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ZincBar"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}