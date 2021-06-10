using System;
using Terraria;
using Azercadmium.NPCs;

namespace Azercadmium.Helpers
{
    [Obsolete("Replaced with the GlobalNPC methods")]
    public static class NPCHelper
    {
        //public static InstancedGlobalNPC GetInstancedGlobalNPC(this NPC npc) => npc.GetGlobalNPC<InstancedGlobalNPC>();
        //public static NPCGlobal GetNPCGlobal(this NPC npc) => npc.GetGlobalNPC<NPCGlobal>();

        public static int ChangeProjectileDamageDependingOnDifficulty(int damage) => Main.expertMode ? (int)(damage * 0.25f) : (int)(damage * 0.5f);

        public static void UpdateOldPos(this NPC npc)
        {
            npc.oldPos[0] = npc.position;
            for (int i = (npc.oldPos.Length - 1); i > 0; i--)
                npc.oldPos[i] = npc.oldPos[i - 1];
        }

        public static void QuetzalcoatlHeadAI(this NPC npc)
        {
        }
    }
}