using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Palladium
{
	public class PalladiumPiercer : ModItem
	{
		public override void SetDefaults() {
			item.damage = 57;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 4.9f;
			item.value = Item.sellPrice(0, 1, 84, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 11);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}