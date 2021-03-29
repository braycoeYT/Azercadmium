using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Mech
{
	public class France : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Not to be confused with the country with the same name\nStriking enemies may spawn holy stars from the sky");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.damage = 86;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 26;
			item.useTime = 26;
			item.knockBack = 5.1f;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 4, 60);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Mech.France>();
			item.shootSpeed = 12.5f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}