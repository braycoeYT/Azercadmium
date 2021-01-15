using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Orichalcum
{
	public class OrichalcumJabber : ModItem
	{
		public override void SetDefaults() {
			item.damage = 63;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 6.2f;
			item.value = Item.sellPrice(0, 2, 53, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 15;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 11);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}