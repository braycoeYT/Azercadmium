using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Crimson
{
	public class CrimtaneJavelin : ModItem
	{
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 36;
			item.useTime = 36;
			item.knockBack = 4.8f;
			item.maxStack = 9999;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(copper: 3);
			item.ranged = true;
			item.noMelee = true;
			item.consumable = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Crimson.CrimtaneJavelin>();
			item.shootSpeed = 10f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 500);
			recipe.AddRecipe();
		}
	}
}