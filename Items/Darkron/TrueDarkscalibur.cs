using Azercadmium.Projectiles.Darkron;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Darkron
{
	public class TrueDarkscalibur : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("True Dusk Cleaver");
			Tooltip.SetDefault("The forgotten lost cousin of the True Exalibur\nShoots a homing darkron blob along with several mini homing darkron blobs");
		}
		public override void SetDefaults() {
			item.damage = 40;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.6f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = ModContent.ProjectileType<DarkronBlob>();
			item.shootSpeed = 11f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 4 + Main.rand.Next(5);
			for (int i = 0; i < numberProjectiles; i++) {
				float rand = Main.rand.NextFloat(0.2f, 0.6f);
				Vector2 perturbedSpeed = new Vector2(speedX * rand, speedY * rand).RotatedByRandom(MathHelper.ToRadians(25));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<MiniDarkronBlob>(), (int)(damage * 0.5f), knockBack / 4f, player.whoAmI);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Darkscalibur>());
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}