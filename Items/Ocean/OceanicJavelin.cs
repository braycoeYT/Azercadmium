using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Ocean
{
	public class OceanicJavelin : ModItem
	{
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.useTime = 20;
			item.knockBack = 4f;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 0, 54);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Ocean.OceanicJavelin>();
			item.shootSpeed = 12f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Goldfish);
			recipe.AddIngredient(ItemID.Coral);
			recipe.AddIngredient(ItemID.Starfish);
			recipe.AddIngredient(ItemID.Seashell);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}