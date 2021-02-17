using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Meteorite
{
	public class Starshooter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses seeds as ammo\nDeals extra damage if Starshots are used");
		}
		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 20;
			item.knockBack = 4.5f;
			item.shootSpeed = 15f;
			item.useTime = 22;
			item.useAnimation = 22;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.rare = 1;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			if (type == ModContent.ProjectileType<Projectiles.Other.Blowpipes.Starshot>())
				damage = (int)(damage * 1.25f);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}