using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Dirtball
{
	public class DirtballBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}
		public override void SetDefaults() {
			item.maxStack = 99;
			item.consumable = true;
			item.width = 40;
			item.height = 36;
			item.rare = 12;
			item.expert = true;
		}
		public override bool CanRightClick() {
			return true;
		}
		public override void OpenBossBag(Player player) {
			switch (Main.rand.Next(1, 7)) {
					case 1: player.QuickSpawnItem(mod.ItemType("MuddyGreatsword"));
						break;
					case 2: player.QuickSpawnItem(mod.ItemType("DirtyBeholder"));
						break;
					case 3: player.QuickSpawnItem(mod.ItemType("Dirty3String"));
						break;
					case 4: player.QuickSpawnItem(mod.ItemType("PaydirtPistol"));
						break;
					case 5: player.QuickSpawnItem(mod.ItemType("DirtyBlowpipe"));
						break;
					case 6: player.QuickSpawnItem(mod.ItemType("DirtballsScepter"));
						break;
			}
			switch (Main.rand.Next(1, 4)) {
					case 1: player.QuickSpawnItem(mod.ItemType("EarthmightHelm"));
						break;
					case 2: player.QuickSpawnItem(mod.ItemType("EarthmightBreastplate"));
						break;
					case 3: player.QuickSpawnItem(mod.ItemType("EarthmightLeggings"));
						break;
			}
			switch (Main.rand.Next(1, 4)) {
					case 1: player.QuickSpawnItem(mod.ItemType("OvergrownHilt"));
						break;
					case 2: player.QuickSpawnItem(mod.ItemType("OvergrownHandgunFragment"));
						break;
					case 3: player.QuickSpawnItem(mod.ItemType("OvergrownElectricalComponent"));
						break;
			}
			player.QuickSpawnItem(ItemID.CopperBar, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.DirtBlock, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.MudBlock, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.Gel, 1 + Main.rand.Next(5));
			player.QuickSpawnItem(ItemID.Lens, 1 + Main.rand.Next(1));
			if (Main.rand.NextFloat() < .75f)
			player.QuickSpawnItem(mod.ItemType("DirtyMedal"));
			if (Main.rand.NextFloat() < .18f)
			player.QuickSpawnItem(mod.ItemType("CreepyBlob"));
			player.QuickSpawnItem(mod.ItemType("HardenedDirtShield"));
			if (Main.rand.NextFloat() < .33f)
			player.QuickSpawnItem(ItemID.DirtRod);

			//Dev sets Azercadmium
			if (Main.rand.NextFloat() < .05f) {
				switch (Main.rand.Next(1, 2)) {
					case 1: player.QuickSpawnItem(mod.ItemType("BraycoesHair"));
						break;
				}
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Dirtball.Dirtball>();
	}
}