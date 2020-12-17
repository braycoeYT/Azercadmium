using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Accessories
{
	public class AncientAmalgamPendant : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Amalgam Pendant");
			Tooltip.SetDefault("The discus on the pendant is severely mutated\nImmune to slow\nMost discuses are friendly\nRandomly electrocutes the player for low damage\nA lot more commonly, buffs are given to the player\nIncreases max minions by one\nIncreases max mana by 20 and mana regen by 1");
		}
		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = 35000;
			item.rare = ItemRarityID.Yellow;
			item.expert = true;
			item.defense = 2;
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
			player.npcTypeNoAggro[mod.NPCType("AquamarineTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("CocoaTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("CorruptDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("DesertDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("DungeonDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("IcyDiscus1")] = true;
			player.npcTypeNoAggro[mod.NPCType("IcyDiscus2")] = true;
			player.npcTypeNoAggro[mod.NPCType("MagmaAssaultDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("MushyDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("RainydayDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("RedTintedDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("SpaceScavengerDiscus")] = true;
			player.npcTypeNoAggro[mod.NPCType("VinefuryDiscus")] = true;
			player.maxMinions += 1;
			player.statManaMax2 += 20;
			player.manaRegen += 1;
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("VoidingMotherboard"));
			recipe.AddIngredient(mod.ItemType("HappyDiscus"));
			recipe.AddIngredient(mod.ItemType("DiscusGuardianPendant"));
			recipe.AddIngredient(mod.ItemType("DirtyMedal"));
			recipe.AddIngredient(mod.ItemType("AncientDiscusMedal"));
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}