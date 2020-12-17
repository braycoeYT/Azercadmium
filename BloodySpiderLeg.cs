using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items
{
	public class BloodySpiderLeg : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Spider Leg");
			Tooltip.SetDefault("Crunchy!");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.White;
		}
	}
}