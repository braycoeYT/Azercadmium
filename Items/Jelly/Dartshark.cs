using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class Dartshark : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("33% chance to not consume ammo\nMinishark's cousin");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 4);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 8;
			item.useTime = 8;
			item.damage = 11;
			item.width = 48;
			item.height = 24;
			item.knockBack = 0f;
			item.shoot = ProjectileID.Seed;
			item.shootSpeed = 18f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Dart;
			item.UseSound = SoundID.Item64;
			item.autoReuse = true;
			item.rare = ItemRarityID.Orange;
		}
		public override bool ConsumeAmmo(Player player) {
			return Main.rand.NextFloat() >= .33f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-10, 0);
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