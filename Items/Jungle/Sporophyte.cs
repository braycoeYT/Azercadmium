using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jungle
{
	public class Sporophyte : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Sporophyte");
			Tooltip.SetDefault("Shoots stingers upwards");
		}
		public override void SetDefaults() {
			item.width = 42;
			item.height = 38;
			item.value = Item.sellPrice(0, 0, 54);
			item.rare = ItemRarityID.Orange;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 45;
			item.useTime = 45;
			item.knockBack = 5.4f;
			item.damage = 21;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Jungle.Sporophyte>();
			item.shootSpeed = 12f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 18);
			recipe.AddIngredient(ItemID.Stinger, 8);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}