using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.GlowingMushroom
{
	public class GlowingMushbow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 14;
			item.useTime = 14;
			item.damage = 10;
			item.width = 28;
			item.height = 60;
			item.knockBack = 0;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Mushbow"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(ItemID.GlowingMushroom, 18);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}