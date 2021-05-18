using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Crimson
{
	public class Pulverizer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Inflicts ichor on struck enemies\nShoots ichor splashes at nearby enemies");
		}
		public override void SetDefaults() {
			item.damage = 64;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.knockBack = 5.6f;
			item.value = Item.sellPrice(0, 3, 56, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Crimson.Pulverizer>();
			item.shootSpeed = 16f;
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
			recipe.AddIngredient(ModContent.ItemType<Tenderizer>());
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}