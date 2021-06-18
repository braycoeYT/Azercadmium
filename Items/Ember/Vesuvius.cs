using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Items.Ember;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Ember
{
	public class Vesuvius : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Leaves a small fire trail behind");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 4.5f;
			item.damage = 19;
			item.rare = ItemRarityID.Orange;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 1, 37, 0);
			item.shoot = ProjectileType<Projectiles.Ember.Vesuvius>();
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock, 21);
			recipe.AddIngredient(ModContent.ItemType<CinderCedar>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 2);
			recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>(), 8);
			recipe.AddIngredient(ModContent.ItemType<BurntStinger>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}