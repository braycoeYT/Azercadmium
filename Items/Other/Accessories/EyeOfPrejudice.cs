using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Accessories
{
	public class EyeOfPrejudice : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye of Prejudice");
			Tooltip.SetDefault("Using a javelance will launch a bleeding javelance which rains blood\nIncreases ranged critical strike chance by 10");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.redJavelance = true;
			player.rangedCrit += 10;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ShardOfPrejudice"));
			recipe.AddIngredient(ItemID.Shackle);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}