using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class LostHeroSword : ModItem
	{
		public override void SetDefaults() {
			item.damage = 15;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 4.6f;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shoot = ProjectileID.Arkhalis;
			item.shootSpeed = 15f;
			item.channel = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBroadsword);
			recipe.AddIngredient(ItemID.Granite, 14);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBroadsword);
			recipe.AddIngredient(ItemID.Granite, 14);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}