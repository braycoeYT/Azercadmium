using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Titan
{
	public class TitanBag : ModItem
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
			player.QuickSpawnItem(ItemID.AdamantiteBar, Main.rand.Next(10, 21));
			player.QuickSpawnItem(ItemID.TitaniumBar, Main.rand.Next(10, 21));
			player.QuickSpawnItem(ItemID.SoulofLight, Main.rand.Next(5, 16));
			player.QuickSpawnItem(ItemID.SoulofNight, Main.rand.Next(5, 16));
			player.QuickSpawnItem(ModContent.ItemType<Items.Titan.TitanicEnergy>(), Main.rand.Next(70, 141));

			//Dev sets Azercadmium
			if (Main.rand.NextFloat() < .05f) {
				switch (Main.rand.Next(1, 2)) {
					case 1: player.QuickSpawnItem(mod.ItemType("BraycoesHair"));
						break;
				}
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Titan.TitanTankorb>();
	}
}