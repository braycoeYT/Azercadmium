using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Discus
{
	public class VoidingMotherboard : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Immune to slow\nRandomly electrocutes the player for low damage\nA lot more commonly, buffs are given to the player");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.buffImmune[32] = true;
			if (Main.rand.NextFloat() < .00075f)
			player.AddBuff(144, 15, false);
			if (Main.rand.NextFloat() < .00075f)
			player.AddBuff(104, 120, false);
			if (Main.rand.NextFloat() < .0006f)
			player.AddBuff(2, 120, false);
			if (Main.rand.NextFloat() < .00052f)
			player.AddBuff(108, 120, false);
			if (Main.rand.NextFloat() < .00045f)
			player.AddBuff(5, 120, false);
			if (Main.rand.NextFloat() < .00035f)
			player.AddBuff(112, 120, false);
			if (Main.rand.NextFloat() < .0003f)
			player.AddBuff(6, 120, false);
			if (Main.rand.NextFloat() < .0002f)
			player.AddBuff(14, 120, false);
			if (Main.rand.NextFloat() < .0001f)
			player.AddBuff(7, 120, false);
			if (Main.rand.NextFloat() < .00005f)
			player.AddBuff(114, 120, false);
			if (Main.rand.NextFloat() < .00003f)
			player.AddBuff(115, 120, false);
			if (Main.rand.NextFloat() < .00003f)
			player.AddBuff(117, 120, false);
		}
	}
}