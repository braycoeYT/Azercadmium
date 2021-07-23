using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class ShadowMoon : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots a barrage of fangs on throw");
		}
		public override void SetDefaults() {
			item.width = 42;
			item.height = 38;
			item.value = Item.sellPrice(0, 4);
			item.rare = ItemRarityID.Orange;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 45;
			item.useTime = 45;
			item.knockBack = 6.25f;
			item.damage = 39;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Jelly.ShadowMoon>();
			item.shootSpeed = 12f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}