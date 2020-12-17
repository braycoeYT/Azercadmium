using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Braycoe
{
	public class LemonadeTea : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Combines two amazing drinks!\nGrants the player the Happy buff");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Orange;
			item.autoReuse = true;
			item.useTurn = true;
			item.noMelee = true;
			item.maxStack = 9999;
			item.UseSound = SoundID.Item2;
			item.noUseGraphic = true;
			item.consumable = true;
			item.healLife = 105;
			item.healMana = 55;
			item.buffType = BuffID.Sunflower;
            item.buffTime = 1800;
			item.potion = true;
		}
	}
}