using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Azercadmium.Items.Smore.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GooeyLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Somehow just as strong as metal, but I wouldn't question it\nIncreases all damage by 4%");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 40, 0);
			item.rare = ItemRarityID.White;
			item.defense = 4;
		}
		public override void UpdateEquip(Player player) {
			player.allDamage += 0.04f;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Smore"), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}