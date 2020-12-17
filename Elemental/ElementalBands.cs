using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Elemental
{
	public class ElementalBands : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Elemental Bands");
			Tooltip.SetDefault("It's kind of odd to have a band with smaller bands hooked to it...\nIncreases life and mana regen by 2\nIncreases armor penetration by 10\nHealing potion cooldown are decreased\nIncreases length of invincibility after taking damage");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			player.pStone = true;
			player.longInvince = true;
			player.lifeRegen += 2;
			player.manaRegen += 2;
			player.moveSpeed += 0.75f;
			player.armorPenetration += 10;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ItemID.BandofStarpower);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(mod.ItemType("ElementalGel"), 250);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.PhilosophersStone);
			recipe.AddIngredient(ItemID.BandofStarpower);
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(mod.ItemType("ElementalGel"), 250);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}