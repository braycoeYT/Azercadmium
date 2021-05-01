using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Darkron
{
	public class Darkscalibur : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The forgotten lost cousin of the Exalibur\nShoots a homing darkron blob");
		}
		public override void SetDefaults() {
			item.damage = 51;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.5f;
			item.value = Item.sellPrice(0, 4, 60, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = ModContent.ProjectileType<Projectiles.Darkron.DarkronBlob>();
			item.shootSpeed = 9f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}