using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cobalt
{
	public class CobaltWakizashi : ModItem
	{
		public override void SetDefaults() {
			item.damage = 51;
			item.melee = true;
			item.width = 30;
			item.height = 38;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 4.1f;
			item.value = Item.sellPrice(0, 1, 38, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}