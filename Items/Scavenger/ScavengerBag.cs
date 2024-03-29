using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Scavenger
{
	public class ScavengerBag : ModItem
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
			player.QuickSpawnItem(mod.ItemType("SoulofByte"), Main.rand.Next(25, 40));
			player.QuickSpawnItem(ModContent.ItemType<Darkron.DarkronBar>(), Main.rand.Next(20, 35));
			player.QuickSpawnItem(mod.ItemType("MechanicalGearPiece"));

			//Dev sets Azercadmium
			if (Main.rand.NextFloat() < .05f) {
				switch (Main.rand.Next(1, 2)) {
					case 1: player.QuickSpawnItem(mod.ItemType("BraycoesHair"));
						break;
				}
			}
		}
		public override int BossBagNPC => NPCType<NPCs.Scavenger.MatrixScavenger>();
	}
}