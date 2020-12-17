using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Carnallite
{
	public class Herbarage : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts regular arrows to poisonous green carnallite arrows");
		}
		public override void SetDefaults()  {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 29;
			item.useTime = 29;
			item.damage = 17;
			item.width = 62;
			item.height = 96;
			item.knockBack = 1f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.2f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-16, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ProjectileID.WoodenArrowFriendly) {
				type = mod.ProjectileType("GreenCarnalliteArrow");
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GreenCarnalliteBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}