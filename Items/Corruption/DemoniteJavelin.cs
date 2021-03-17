using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Corruption
{
	public class DemoniteJavelin : ModItem
	{
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 42;
			item.useTime = 42;
			item.knockBack = 5.4f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 27);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Corruption.DemoniteJavelin>();
			item.shootSpeed = 9f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}