using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class EerieStakeLauncher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 4);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 31;
			item.useTime = 31;
			item.damage = 21;
			item.width = 48;
			item.height = 24;
			item.knockBack = 4.5f;
			item.shoot = ProjectileID.Stake;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Stake;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = ItemRarityID.Orange;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}