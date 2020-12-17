using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Snow
{
	public class CryoCrystal : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Icy Crystal");
			Tooltip.SetDefault("'Each Icy Crystal you hold makes you feel a bit better in the cold...'");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 200;
			item.rare = ItemRarityID.White;
			item.useStyle = ItemUseStyleID.HoldingUp;
		}
	}
}