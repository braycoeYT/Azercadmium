using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Scavenger
{
	public class FloppyDisc : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons the Matrix Scavenger");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 7;
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 20;
			item.value = 0;
			item.rare = ItemRarityID.Orange;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(mod.NPCType("MatrixScavenger")) && !Main.dayTime;
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Scavenger.MatrixScavenger>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PixieDust, 6);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}