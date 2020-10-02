using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.CVirus
{
	public class SoulofByte : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul of Byte");
			Tooltip.SetDefault("'The essence of the computer destroyer'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults() {
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = 40;
			item.height = 40;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.rare = ItemRarityID.Pink;
		}
	}
}