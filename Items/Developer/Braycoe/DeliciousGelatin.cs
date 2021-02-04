using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Developer.Braycoe
{
	public class DeliciousGelatin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Quite wobbly as well");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.buffType = BuffID.Slimed;
            item.buffTime = 10 * 3600;
		}
		public override void OnConsumeItem(Player player) {
			player.AddBuff(BuffID.WellFed, 10 * 3600, false);
		}
	}
}