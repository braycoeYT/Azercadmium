using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Empress
{
	public class EmpressBag : ModItem
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
			player.TryGettingDevArmor();
			int rand = Main.rand.Next(3);
			switch (rand) {
				case 0:
					player.QuickSpawnItem(ModContent.ItemType<Items.Empress.Exallite>());
					break;
				case 1:
					player.QuickSpawnItem(ModContent.ItemType<Items.Empress.RoyalSlimeGun>());
					break;
				case 2:
					player.QuickSpawnItem(ModContent.ItemType<Items.Empress.SacredCarrotTome>());
					break;
			}
			player.QuickSpawnItem(ModContent.ItemType<Items.Empress.EmpressCrown>());
			player.QuickSpawnItem(ModContent.ItemType<Items.Empress.EmpressShard>(), Main.rand.Next(16, 24));
			player.QuickSpawnItem(ModContent.ItemType<Items.Elemental.ElementalGel>(), Main.rand.Next(30, 71));

			//Dev sets Azercadmium
			if (Main.rand.NextFloat() < .05f) {
				switch (Main.rand.Next(1, 2)) {
					case 1: player.QuickSpawnItem(ModContent.ItemType<Items.Developer.Braycoe.BraycoesHair>());
						break;
				}
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Empress.EmpressSlime>();
	}
}