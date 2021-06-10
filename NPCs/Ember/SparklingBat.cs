using Azercadmium.Aaa;
using Azercadmium.Items.Ember;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Ember
{
    public class SparklingBat : ModNPC
    {
        public override string Texture => "Terraria/NPC_" + NPCID.JungleBat;

        public override void SetStaticDefaults() => Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.JungleBat];

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.JungleBat);
            aiType = NPCID.JungleBat;
            animationType = NPCID.JungleBat;
            npc.scale = 1.5f;
            npc.noTileCollide = true;
            npc.lifeMax = 100;
            npc.damage = 70;
            npc.defense = 12;
            npc.knockBackResist = 0.5f;
            npc.value = Item.buyPrice(silver: 2);
        }
        public override void DrawEffects(ref Color drawColor)
        {
            drawColor = Color.White;
            Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            if (Azercadmium.DownedAllMechBosses)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.75f);
                npc.damage = (int)(npc.damage * 1.6f);
                npc.defense = (int)(npc.defense * 1.5f);
                npc.knockBackResist *= 0.66f;
            }
            else if (NPC.downedMechBossAny)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.3f);
                npc.damage = (int)(npc.damage * 1.1f);
                npc.defense = (int)(npc.defense * 1.1f);
                npc.knockBackResist *= 0.7f;
            }
            else if (Main.hardMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.25f);
                npc.knockBackResist *= 0.8f;
            }
            else
            {
                npc.lifeMax = (int)(npc.lifeMax * 0.75f);
                npc.damage = (int)(npc.damage * 0.7f);
                npc.defense = (int)(npc.defense * 0.6f);
                npc.knockBackResist *= 0.9f;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit) {
            if (Main.rand.Next(2) == 0)
                target.AddBuff(BuffID.OnFire, 60*Main.rand.Next(4, 9));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return spawnInfo.player.GetModPlayer<TAZPlayer>().ZoneEmberGlades ? 0.3f : 0f;
        }
        public override void NPCLoot() {
            if (Main.rand.NextFloat() < 0.66f)
                Item.NewItem(npc.getRect(), ModContent.ItemType<SparkingBatFoot>());
        }
    }
}