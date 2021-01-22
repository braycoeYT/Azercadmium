using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class Gardenbane : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts regular arrows to venomous red carnallite arrows");
		}
		public override void SetDefaults()  {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 27;
			item.useTime = 27;
			item.damage = 81;
			item.width = 36;
			item.height = 56;
			item.knockBack = 1.3f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Lime;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ProjectileID.WoodenArrowFriendly) {
				type = mod.ProjectileType("RedCarnalliteArrow");
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CarnalliteBow"));
			recipe.AddIngredient(mod.ItemType("RedCarnalliteBar"), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}