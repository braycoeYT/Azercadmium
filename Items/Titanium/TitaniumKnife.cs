using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titanium
{
	public class TitaniumKnife : ModItem
	{
		public override void SetDefaults() {
			item.damage = 72;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 6.2f;
			item.value = Item.sellPrice(0, 3, 22, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}