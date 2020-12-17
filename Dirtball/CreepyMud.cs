using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class CreepyMud : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It is literally just dirt, mud, slime, and a lens mashed together...\nSummons Dirtball");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 38;
			item.height = 68;
			item.maxStack = 20;
			item.value = 0;
			item.rare = -1;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(mod.NPCType("Dirtball"));
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Dirtball.Dirtball>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ItemID.MudBlock, 5);
			recipe.AddIngredient(ItemID.Gel, 3);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}