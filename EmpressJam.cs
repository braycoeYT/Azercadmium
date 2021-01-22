using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Empress
{
	public class EmpressJam : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("One of the fanciest jams around");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Lime;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.buffType = BuffID.Slimed;
            item.buffTime = 20 * 3600;
		}
		public override void OnConsumeItem(Player player) {
			player.AddBuff(BuffID.WellFed, 20 * 3600, false);
		}
	}
}