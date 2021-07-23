using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Jelly
{
	public class JellyBag : ModItem
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
			player.QuickSpawnItem(ItemType<EldritchTentacles>());
			player.QuickSpawnItem(ItemType<EerieBell>(), Main.rand.Next(40, 51));
			player.QuickSpawnItem(ItemType<OtherworldlyFang>(), Main.rand.Next(45, 56));
		}
		public override int BossBagNPC => NPCType<NPCs.Jelly.EldritchJellyfish>();
	}
}