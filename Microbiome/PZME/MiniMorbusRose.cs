using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Microbiome.PZME
{
	public class MiniMorbusRose : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mini Morbus Rose");
		}

        public override void SetDefaults()
		{
			npc.width = 88;
			npc.height = 69;
			npc.damage = 136;
			npc.defense = 22;
			npc.lifeMax = 1292;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 5f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 44;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 2485;
            npc.damage = 218;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				player.AddBuff(mod.BuffType("Sick"), 300, true);
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = mod.DustType("MicrobiomeDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 0.5f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void AI()
		{
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
			}
			npc.rotation += 0.01f;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (AzercadmiumWorld.downedMineral)
			{
				return spawnInfo.player.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome ? 0.2f : 0f;
			}
			return 0f;
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("InfectedOnyx"));
			if (Main.rand.Next(30) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("SilvervoidCore"));
			if (Main.rand.Next(40) == 0)
				Item.NewItem(npc.getRect(), mod.ItemType("NucleusShard"));
		}
	}
}