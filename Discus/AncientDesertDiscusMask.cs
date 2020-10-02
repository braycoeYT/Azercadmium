using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Discus
{
	[AutoloadEquip(EquipType.Head)]
	public class AncientDesertDiscusMask : ModItem
	{
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.value = 0;
			item.rare = ItemRarityID.White;
			item.vanity = true;
		}
	}
}