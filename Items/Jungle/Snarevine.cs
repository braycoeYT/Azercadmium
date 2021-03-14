using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Jungle
{
	public class Snarevine : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Inflicts poison on enemies");
		}
		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.damage = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 34;
			item.useTime = 34;
			item.knockBack = 5.4f;
			item.maxStack = 9999;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(copper: 5);
			item.ranged = true;
			item.noMelee = true;
			item.consumable = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Jungle.Snarevine>();
			item.shootSpeed = 9f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 600);
			recipe.AddRecipe();
		}
	}
}