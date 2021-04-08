using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Zinc
{
	public class ZincSpear : ModItem
	{
		public override void SetDefaults() {
			item.damage = 11;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 22;
			item.useTime = 28;
			item.shootSpeed = 3.8f;
			item.knockBack = 6.1f;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(0, 0, 5, 40);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = false;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Zinc.ZincSpear>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}