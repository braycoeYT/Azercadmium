using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
	public class CharredChakram : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Has a chance to poison or burn enemies");
		}
		public override void SetDefaults() {
			item.damage = 37;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(0, 1, 37, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Ember.CharredChakram>();
			item.shootSpeed = 13f;
			item.noUseGraphic = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CinderCedar>(), 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 2);
			recipe.AddIngredient(ModContent.ItemType<FlareSerpentScale>(), 11);
			recipe.AddIngredient(ModContent.ItemType<BurntStinger>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}