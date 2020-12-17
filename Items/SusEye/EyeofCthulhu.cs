using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.SusEye
{
	public class EyeofCthulhu : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye of Cthulhu");
			Tooltip.SetDefault("Using a suspicious looking eye summons the eye of cthulhu, but what does the eye of cthulhu summon?");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
		}
		public override void SetDefaults() {
			item.width = 152;
			item.height = 110;
			item.maxStack = 20;
			item.value = 0;
			item.rare = 12;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(mod.NPCType("SuspiciousLookingEye"));
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.SusEye.SuspiciousLookingEye>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ItemID.MudBlock, 5);
			recipe.AddIngredient(ItemID.Gel, 3);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}