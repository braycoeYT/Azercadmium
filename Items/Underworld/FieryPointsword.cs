using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Underworld
{
	public class FieryPointsword : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Points at the cursor\nMay set any enemies it touches on fire");
		}
		public override void SetDefaults() {
			item.damage = 48;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 3;
			item.useTime = 3;
			item.shootSpeed = 1f;
			item.knockBack = 4.2f;
			item.width = 34;
			item.height = 34;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(0, 52, 0, 0);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			//item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Underworld.FieryPointsword>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}