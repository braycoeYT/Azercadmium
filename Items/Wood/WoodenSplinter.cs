using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Wood
{
	public class WoodenSplinter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("You've got to start somewhere...\nAnd this somewhere is poking slimes with splinters");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 18;
			item.useTime = 18;
			item.knockBack = 4f;
			item.maxStack = 9999;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(copper: 2);
			item.ranged = true;
			item.noMelee = true;
			item.consumable = true;
			item.noUseGraphic = true;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Wood.WoodenSplinter>();
			item.shootSpeed = 8f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 100);
			recipe.AddRecipe();
		}
	}
}