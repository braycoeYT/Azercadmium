using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class Stalagmite : ModItem
	{
		public override void SetDefaults() {
			item.damage = 16;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 4.5f;
			item.value = 25000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.GraniteBlock, 24);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}