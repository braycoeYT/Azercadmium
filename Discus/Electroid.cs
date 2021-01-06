using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class Electroid : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Can be used to upgrade the Dirtball Fragment items");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
		}
		public override void SetDefaults() {
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = 40;
			item.height = 40;
			item.maxStack = 20;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Pink;
		}
	}
}