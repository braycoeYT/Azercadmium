using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.CVirus
{
	public class CVirusBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Error Loading C:/Tmodloader/Mods/Azercadmium/Items/CVirus/CVirusBag: Item not found");
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
			player.QuickSpawnItem(ItemID.HallowedBar, Main.rand.Next(20, 35));
			player.QuickSpawnItem(mod.ItemType("MechanicalGearPiece"));
		}
		public override int BossBagNPC => NPCType<NPCs.Bosses.ComputerVirus>();
	}
}