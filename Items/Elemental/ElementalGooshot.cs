using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Elemental
{
	public class ElementalGooshot : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nInflicts several flames upon hitting enemies");
        }
		public override void SetDefaults() {
			item.damage = 14;
			item.ranged = true;
			item.width = 12;
			item.height = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 0, 2);
			item.rare = ItemRarityID.Lime;
			item.shoot = ProjectileType<Projectiles.Elemental.ElementalGooshot>();
			item.shootSpeed = 3f;
			item.ammo = AmmoID.Dart;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ElementalGoop>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 75);
			recipe.AddRecipe();
		}
	}
}