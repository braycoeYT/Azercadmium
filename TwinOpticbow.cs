using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Mech
{
	public class TwinOpticbow : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Has a chance to replace arrows with cursed flames or lasers");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 25;
			item.useTime = 25;
			item.damage = 51;
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
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int ran = Main.rand.Next(1, 21);
            if (ran == 1) type = 95;
			if (ran == 2) type = 14;
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