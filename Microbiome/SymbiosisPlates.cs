using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Microbiome
{
	[AutoloadEquip(EquipType.Body)]
	public class SymbiosisPlates : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases max health by 30");
		}
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 40000;
			item.rare = ItemRarityID.Blue;
			item.defense = 7;
		}
		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 30;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("TwistedMembraneBar"), 25);
			recipe.AddIngredient(mod.ItemType("Cytoplasm"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}