using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Darkron
{
	public class Blackout : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots out a small trail of mini darkron orbs capable of chasing enemies");
		}
		public override void SetDefaults() {
			item.damage = 81;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 12;
			item.useTime = 14;
			item.shootSpeed = 5.7f;
			item.knockBack = 4.4f;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 4, 60, 0);
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Darkron.Blackout>();
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}