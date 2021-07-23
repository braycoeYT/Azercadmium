using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Jelly
{
	[AutoloadEquip(EquipType.Wings)]
	public class EldritchTentacles : ModItem
	{
		/*public override bool Autoload(ref string name)
		{
			return !ModContent.GetInstance<ExampleConfigServer>().DisableExampleWings;
		}*/
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Allows flight and slow fall\nYou have increased mobility while wet\nCritical strikes summon big eerie jellies to damage enemies\nUp to 2 eerie jellies can be active at once");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(0, 6, 50, 0);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			player.wingTimeMax = 90;
			p.jellyExpert = true;
			if (player.wet) {
				player.jumpSpeedBoost *= 2f;
				player.moveSpeed *= 6f;
				player.maxRunSpeed *= 3f;
				player.runAcceleration *= 3f;
				player.wingTimeMax *= 2;
			}
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.75f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.5f;
			constantAscend = 0.125f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 6.5f;
			acceleration *= 1f;
		}
	}
}