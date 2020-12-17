using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class SuspiciousLookingDisc : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It appears to be moving, but that is all an illusion.\nSummons the Ancient Desert Discus in the desert night");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 20;
			item.value = 0;
			item.rare = ItemRarityID.Green;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(mod.NPCType("AncientDesertDiscus")) && !Main.dayTime && player.ZoneDesert;
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 6);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddIngredient(ItemID.Amber, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}