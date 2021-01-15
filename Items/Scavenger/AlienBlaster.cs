using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Scavenger
{
	public class AlienBlaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For killing space invaders and whatnot\nEvery third shot is replaced by a matrix bolt that does 1.5x damage");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 36;
			item.useTime = 36;
			item.damage = 112;
			item.width = 54;
			item.height = 30;
			item.knockBack = 3.1f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 16f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Pink;
			item.crit = 4;
		}
		int shootNum;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootNum++;
			if (shootNum % 3 == 0) {
				type = mod.ProjectileType("MatrixBlastFriendlyRanged");
				damage = (int)(damage * 1.5f);
				Main.PlaySound(SoundID.Item91, player.position);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(mod.ItemType("SoulofByte"), 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}