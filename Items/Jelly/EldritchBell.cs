using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Jelly
{
	public class EldritchBell : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Summons the Eldritch Jellyfish");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 3;
		}
		public override void SetDefaults() {
			item.width = 32;
			item.height = 32;
			item.maxStack = 20;
			item.value = 0;
			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.consumable = true;
			item.UseSound = SoundID.Item35.WithPitchVariance(4f);
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Jelly.EldritchJellyfish>()) && player.ZoneBeach;
		}
		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Jelly.EldritchJellyfish>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MetallicBell>());
			recipe.AddIngredient(ModContent.ItemType<EerieBell>(), 8);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}