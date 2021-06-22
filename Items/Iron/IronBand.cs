using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Iron
{
	public class IronBand : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases the power of Ironskin Potions");
		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(0, 0, 30, 0);
			item.rare = ItemRarityID.White;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.bandofMetal = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}