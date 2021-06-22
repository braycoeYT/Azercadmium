using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class LifeforceShield : ModItem 
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lifeforce Shield");
			Tooltip.SetDefault("Striking enemies increases your max health, capping out at 50 extra health\nTrue melee strikes increase your health slightly more than projectiles");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 26;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Blue;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.lifeforceShield = true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 9);
			recipe.AddIngredient(ItemID.LifeCrystal, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 9);
			recipe.AddIngredient(ItemID.LifeCrystal, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}