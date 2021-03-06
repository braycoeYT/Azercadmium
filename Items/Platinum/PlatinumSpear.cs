using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Platinum
{
	public class PlatinumSpear : ModItem
	{
		public override void SetDefaults() {
			item.damage = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 18;
			item.useTime = 24;
			item.shootSpeed = 3.7f;
			item.knockBack = 6f;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(0, 0, 27, 0);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Platinum.PlatinumSpear>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}