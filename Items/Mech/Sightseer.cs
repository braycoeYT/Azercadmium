using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Mech
{
	public class Sightseer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts regular arrows into lasers and cursed flames");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 19;
			item.useTime = 19;
			item.damage = 58;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.rare = ItemRarityID.LightPurple;
		}
		int shootCount;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootCount++;
			if (type == ProjectileID.WoodenArrowFriendly) {
				if (shootCount % 2 == 0) type = 95;
				else type = 88;
			}
            return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(ItemID.SoulofSight, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}