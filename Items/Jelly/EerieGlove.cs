using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class EerieGlove : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Barrages enemies with tracking jellies");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 12;
			item.width = 28;
			item.height = 32;
			item.knockBack = 1.6f;
			item.shoot = ModContent.ProjectileType<Projectiles.Jelly.EerieGloveProj>();
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Orange;
			item.mana = 4;
			item.UseSound = SoundID.Item116;
			item.noUseGraphic = true;
		}
		float speed1;
		float speed2;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			speed1 = speedX;
			speed2 = speedY;
			return true;
		}
		public override void UseStyle(Player player) {
			Projectile.NewProjectile(player.position, new Vector2(speed1, speed2), ModContent.ProjectileType<Projectiles.Jelly.EerieGloveHand>(), 0, 0f, Main.myPlayer);
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