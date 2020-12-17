using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Minions.Discus
{
	public class SandGrainDiscus : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sandgrain Assault Discus");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
		{
			npc.value = 0;
			npc.width = 77;
			npc.height = 67;
			npc.damage = 18;
			npc.defense = 3;
			npc.lifeMax = 31;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0.8f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			animationType = 82;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 62;
            npc.damage = 27;
			npc.knockBackResist = 0f;
        }
	}
}