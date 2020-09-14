using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Nova.Twilight
{
	public class Twilight1 : ModItem
	{
		public override void SetStaticDefaults()  {
			DisplayName.SetDefault("Twilight I");
			Tooltip.SetDefault("Each boomerang fires a small crystal shard towards the cursor every two seconds");
		}
		public override void SetDefaults() {
			item.damage = 15;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 7.9f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Twilight1");
			item.shootSpeed = 12f;
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
			recipe.AddIngredient(mod.ItemType("MysteriousNova"));
			recipe.AddIngredient(mod.ItemType("DriedEssence"));
			recipe.AddIngredient(mod.ItemType("GlazedLens"));
			recipe.AddIngredient(mod.ItemType("SlimyCore"));
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}