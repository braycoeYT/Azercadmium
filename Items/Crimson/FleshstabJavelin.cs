using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Crimson
{
	public class FleshstabJavelin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("On impact, explodes into multiple ichor splashes");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 65;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 41;
			item.useTime = 41;
			item.knockBack = 5.1f;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 3, 56);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Crimson.FleshstabJavelin>();
			item.shootSpeed = 31f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CrimtaneJavelin>());
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}