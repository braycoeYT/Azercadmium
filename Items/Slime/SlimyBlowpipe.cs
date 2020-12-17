using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Slime
{
	public class SlimyBlowpipe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses seeds as ammo");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 10;
			item.knockBack = 3.5f;
			item.shootSpeed = 10f;
			item.useTime = 27;
			item.useAnimation = 27;
			item.value = Item.sellPrice(0, 0, 20, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(8, -5);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SlimyCore"), 3);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}