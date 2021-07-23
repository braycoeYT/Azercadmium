using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Jelly
{
	public class EerieSpear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots four otherworldly fangs on swing");
		}
		public override void SetDefaults() {
			item.width = 60;
			item.height = 60;
			item.damage = 39;
			item.useStyle = 5;
			item.useAnimation = 31;
			item.useTime = 31;
			item.knockBack = 6f;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(0, 4);
			item.ranged = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<Projectiles.Jelly.EerieSpear>();
			item.shootSpeed = 5f;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Jelly.EerieSpear>()) {
                    return false;
                }
            }
            return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}