using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Aquite
{
	public class AquiteStabber : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots multiple bubbles to the side on swing");
		}
		public override void SetDefaults() {
			item.damage = 124;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.knockBack = 6.2f;
			item.value = Item.sellPrice(0, 6, 16, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.crit = 17;
			item.shoot = ProjectileID.FlaironBubble;
			item.shootSpeed = 20f;
		}
		int direction;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (player.direction == 0) direction = -1;
			else direction = 1;
			speedY = 0;
			for (int i = 0; i < 3; i++) {
				Projectile.NewProjectile(position.X, position.Y, speedX * direction * Main.rand.NextFloat(0.5f, 1.2f), 0, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("AquiteBar"), 11);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}