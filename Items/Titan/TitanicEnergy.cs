using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.DataStructures;

namespace Azercadmium.Items.Titan
{
	public class TitanicEnergy : ModItem
	{
		public override void SetStaticDefaults() {
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6)); //first is speed, second is amount of frames
			Tooltip.SetDefault("Can be used to convert basic hardmode ores into their alts");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 26;
			item.maxStack = 9999;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.LightRed;
		}
	}
}