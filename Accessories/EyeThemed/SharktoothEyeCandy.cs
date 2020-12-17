using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Accessories.EyeThemed
{
	public class SharktoothEyeCandy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sharktooth Eye Candy");
			Tooltip.SetDefault("Who would eat a shark tooth? You, apparently...\nAfter taking damage, mana cost is halved\nArmor penetration increased by 5");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 84000;
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			p.eyeCandy = true;
			player.armorPenetration += 5;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EyeCandy"));
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}