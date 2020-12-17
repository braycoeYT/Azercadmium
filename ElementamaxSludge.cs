using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items
{
	public class ElementamaxSludge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Elementamax Sludge");
			Tooltip.SetDefault("Overloaded with elemental power");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 30;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = ItemRarityID.Lime;
		}
	}
}