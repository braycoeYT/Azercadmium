using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Tiles
{
	public class AzercadmiumGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PoisonDart)
				item.damage = 4;
			if (item.type == ItemID.Blowpipe)
				item.damage = 10;
			if (item.type == ItemID.Blowgun)
				item.damage = 34;
			if (item.type == ItemID.BoneArrow)
				item.damage = 10;
		}
		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			if (item.type == ItemID.RoyalGel || item.type == mod.ItemType("MonarchalGel"))
			{
				player.npcTypeNoAggro[mod.NPCType("BoneSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("EctojeweloSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("FleshySlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("MechanicalSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("SilvervoidSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("StarfurrySlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("VilespitSlime")] = true;
			}
		}
		public override void RightClick(Item item, Player player) {
			if (item.type == ItemID.FloatingIslandFishingCrate) {
				if (Main.rand.NextFloat() < .25f)
				player.QuickSpawnItem(mod.ItemType("Starfrenzy"));
			}
		}
	}
}