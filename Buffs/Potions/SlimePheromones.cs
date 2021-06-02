using Terraria;
using Terraria.ModLoader;

namespace Azercadmium.Buffs.Potions
{
    public class SlimePheromones : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Slime Pheromones");
            Description.SetDefault("Most slimes are friendly");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.npcTypeNoAggro[1] = true;
			player.npcTypeNoAggro[16] = true;
			player.npcTypeNoAggro[59] = true;
			player.npcTypeNoAggro[71] = true;
			player.npcTypeNoAggro[81] = true;
			player.npcTypeNoAggro[138] = true;
			player.npcTypeNoAggro[121] = true;
			player.npcTypeNoAggro[122] = true;
			player.npcTypeNoAggro[141] = true;
			player.npcTypeNoAggro[147] = true;
			player.npcTypeNoAggro[183] = true;
			player.npcTypeNoAggro[184] = true;
			player.npcTypeNoAggro[204] = true;
			player.npcTypeNoAggro[225] = true;
			player.npcTypeNoAggro[244] = true;
			player.npcTypeNoAggro[302] = true;
			player.npcTypeNoAggro[333] = true;
			player.npcTypeNoAggro[335] = true;
			player.npcTypeNoAggro[334] = true;
			player.npcTypeNoAggro[336] = true;
			player.npcTypeNoAggro[537] = true;
            player.npcTypeNoAggro[mod.NPCType("BoneSlime")] = true;
			player.npcTypeNoAggro[mod.NPCType("MechanicalSlime")] = true;
			player.npcTypeNoAggro[mod.NPCType("StarpackSlime")] = true;
			player.npcTypeNoAggro[mod.NPCType("LivingMarshmellow")] = true;
			player.npcTypeNoAggro[mod.NPCType("RoastedLivingMarshmellow")] = true;
			player.npcTypeNoAggro[mod.NPCType("DirtSlime")] = true;
        }
    }
}