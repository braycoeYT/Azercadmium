using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titan
{
	public class AdamantiteEnergyCore : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Adamantite Energy Core");
			Tooltip.SetDefault("The energy core is greatly empowered by the essence of the skies\nSummons the Titan Tankorb");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 5;
		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 28;
			item.maxStack = 20;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Titan.TitanTankorb>());
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Titan.TitanTankorb>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 3);
			recipe.AddIngredient(ItemID.SoulofFlight, 3);
			recipe.AddIngredient(ModContent.ItemType<Electrolight.Electrolight>(), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}