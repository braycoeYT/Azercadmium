using Azercadmium.Items.Other.Accessories;
using Azercadmium.Items.Plantera;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jungle
{
	public class JunglesProsperity : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Jungle's Prosperity");
			Tooltip.SetDefault("Increases max health by 25\nSummons spores over time that will damage enemies\nGreatly increases life regen when not moving\nReleases bees and heals life when damaged\nIncreases the strength of friendly bees\nLife regen is heavily increased in low health");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			player.statLifeMax2 += 25;
			player.SporeSac();
			player.sporeSac = true;
			player.shinyStone = true;
			player.strongBees = true;
			player.bee = true;
			p.hurtHeal = true;
			if (player.statLife < player.statLifeMax2 / 4)
			player.lifeRegen += 5;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SporeSac);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.HoneyComb);
			recipe.AddIngredient(ItemID.HiveBackpack);
			recipe.AddIngredient(ModContent.ItemType<BloomofLife>());
			recipe.AddIngredient(ModContent.ItemType<Hallow.SunProtection>());
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.LifeFruit, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}