using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Other
{
	[AutoloadBossHead]
	public class SuspiciousLookingEye : ModNPC
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Dreamin Eye");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults() {
			npc.CloneDefaults(NPCID.DemonEye);
			//npc.value = 0f;
			//npc.aiStyle = NPCID.DemonEye;
			animationType = 5;
			npc.lifeMax = 1000000;
			npc.damage = 718;
			npc.defense = 100;
			npc.noTileCollide = true;
			//npc.color = Color.Aqua;
			npc.boss = true;
			npc.knockBackResist = 0f;
        }
		public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
		{
			if (damage > 200000) {
				npc.life += damage;
				CombatText.NewText(npc.getRect(), Color.LimeGreen, damage);
				if (npc.life < 1)
					npc.life = npc.lifeMax;
			}
		}
		/*public override void OnHitPlayer(Player target, int damage, bool crit) {
			target.AddBuff(mod.BuffType("Scared"), Main.rand.Next(1, 4) * 60, true);
		}*/
		int Timer;
		int animationTimer;
		int attackTimer;
		bool movement = true;
		float shieldValue = 1f;
		int flee = 0;
		int attack = 1;
		bool attackDone = true;
		Player target;
		int difficultyBonus;
		float num321;
		float num322;
		bool dashDone = true;
		int dashTimer = 0;

		bool children = true;
		bool children2 = true;
		bool children3 = true;

		bool chat1 = true;
		bool chat2 = true;
		bool chat3 = true;
		bool chat4 = true;
		bool chat5 = true;
		bool chat6 = true;
		bool chat7 = true;
		bool chat8 = true;
		bool chat9 = true;
		bool chat10 = true;
		bool chat11 = true;
		bool chat12 = true;
		bool chat13 = true;
		bool chat14 = true;
		bool chat15 = true;
		bool chat16 = true;
		bool chat17 = true;
		bool chat18 = true;
		bool chat19 = true;
		bool chat20 = true;
		bool chat21 = true;
		bool chat22 = true;
		bool chat23 = true;
		bool chat24 = true;
		bool chat25 = true;
		bool chat26 = true;
		bool chat27 = true;
		bool chat28 = true;
		bool chat29 = true;
		bool chat30 = true;
		bool chat31 = true;
		bool chat32 = true;
		bool chat33 = true;
		bool chat34 = true;
		bool chat35 = true;
		bool chat36 = true;
		bool chat37 = true;
		bool chat38 = true;
		bool chat39 = true;
		bool chat40 = true;
		bool chat41 = true;
		bool chat42 = true;
		bool chat43 = true;
		bool chat44 = true;
		bool chat45 = true;
		bool chat46 = true;
		bool chat47 = true;
		bool chat48 = true;
		bool chat49 = true;
		bool chat50 = true;
		bool chat51 = true;
		bool chat52 = true;
		bool chat53 = true;
		bool chat54 = true;
		bool chat55 = true;
		bool chat56 = true;
		bool chat57 = true;
		bool chat58 = true;
		bool chat59 = true;
		bool chat60 = true;

		float attackTime;

		public override void AI() {
			Timer++;

			if ((double)(npc.life) < (double)(npc.lifeMax * 1f))
				if (chat1)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Warning: This is a joke boss and is not meant to be taken seriously.\nI am GOING to KILL you!?!?!?1/1/1/1";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat1 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.99f))
				if (chat2)
				{
					Color messageColor = Color.DarkRed;
					string chat = "And I am GOING to EAT your FREAKING DOG!!!(!(@(#R&*$(#&";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat2 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.98f))
				if (chat3)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Now let me tell you my backstory because u stpid";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat3 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.96f))
				if (chat4)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I was a small child a long time agoooooooooooooooooooooooooooooooooooo";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat4 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.94f))
				if (chat5)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then my best friend TIMMMMY was killed by the edgiest eye of edginess";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat5 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.92f))
				if (chat6)
				{
					Color messageColor = Color.DarkRed;
					string chat = "and I cried and commited cannibalism";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat6 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.90f))
				if (chat7)
				{
					Color messageColor = Color.DarkRed;
					string chat = "and I cried and commited cannibalism";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat7 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.88f))
				if (chat8)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then IIIIII was so sadddd I did it again and again and then I killed all my friends for no reason";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat8 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.86f))
				if (chat9)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I traveleeld acrossss the universe and bullyyedd my  parents because they called me a winner";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat9 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.84f))
				if (chat10)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I murdered a big boi worm because he accidentally went within 101010100101 light years of meee";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat10 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.82f))
				if (chat11)
				{
					Color messageColor = Color.DarkRed;
					string chat = "then I became the most powerful eye in the UNIVERSE!(!*))@*(#$???!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat11 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.8f))
				if (chat12)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Even more than the edgiest eye of edginess!?*&@^#%&7658!!!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat12 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.75f))
				if (chat13)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Here are my children!??!?!?! They will eat your kids!)(@I)#";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat13 = false;
					for (int i = 0; i < 30; i++) {
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.EyeofCthulhu);
					}
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.72f))
				if (chat14)
				{
					Color messageColor = Color.DarkRed;
					string chat = "im GONNA GET YUUUUUUU!!UU!!UU!!(@)#*&(@$(&#";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat14 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.66f))
				if (chat15)
				{
					Color messageColor = Color.DarkRed;
					string chat = "HOW AERE YOU STILL A LIVE!)!)!)!_@_)#$*#()$*&";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat15 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.63f))
				if (chat16)
				{
					Color messageColor = Color.DarkRed;
					string chat = "ALRIGHT YOU ARE ASKING FOR THIS#";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat16 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.6f))
				if (chat17)
				{
					Color messageColor = Color.DarkRed;
					string chat = "JK I will wait a bit so I look more edgy and coooollll!@*&(@)#)";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat17 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.55f))
				if (chat18)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Ok u are startin to git very annoying";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat18 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.53f))
				if (chat19)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Get ready n00b...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat19 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.5f))
				if (chat20)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Here are my GRANDCHILDREN!?!?!?!?!?!?! U DONT STAND A CHANCE!!?!?!?! MWHSAHSHQHAHAHAHAHAHAHSUIDYhgaewfiukashrgfk";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat20 = false;
					for (int i = 0; i < 30; i++) {
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.Retinazer);
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.Spazmatism);
					}
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.45f))
				if (chat21)
				{
					Color messageColor = Color.DarkRed;
					string chat = "o no my hp is gone";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat21 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.435f))
				if (chat22)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Im about to DIE!?!?!?!?!??!!??! SOMEONE LIKE ME!?!?!??!?! U MUST B CHEATING!!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat22 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.415f))
				if (chat23)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Welllll guess WAT!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat23 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.4f))
				if (chat24)
				{
					Color messageColor = Color.DarkRed;
					string chat = "It isn't over yet, kiddo child bob joe poophead!!!!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat24 = false;
					for (int i = 0; i < 30; i++) {
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - Main.rand.Next(-600, 601), NPCID.SpikeBall);
					}
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.38f))
				if (chat25)
				{
					Color messageColor = Color.DarkRed;
					string chat = "OH YEAHH!H!!!H!H!! FLAMETHROWERS!!!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat25 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.36f))
				if (chat26)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I'm gonnnna spank ur butt so freaking hard it will go to space!?!?!?!??!?!!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat26 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.34f))
				if (chat27)
				{
					Color messageColor = Color.DarkRed;
					string chat = "O NO HOW IN THE WORLD ARE YOU BEATING ME YOU STINKHEADq?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat27 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.32f))
				if (chat28)
				{
					Color messageColor = Color.DarkRed;
					string chat = "WE're NO strangers 32 loveosss?!?!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat28 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.3f))
				if (chat29)
				{
					Color messageColor = Color.DarkRed;
					string chat = "WE're NO strangers 32 loveosss?!?!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat29 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.28f))
				if (chat30)
				{
					Color messageColor = Color.DarkRed;
					string chat = "OH SORRYRYRYRY, I WAS thinking of my GIRLFRIEND";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat30 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.27f))
				if (chat31)
				{
					Color messageColor = Color.DarkRed;
					string chat = "She died in a CAR CRASH the day after I married her........... oh poor Ajfiuarfharieluf the Fourth////";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat31 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.25f))
				if (chat32)
				{
					Color messageColor = Color.DarkRed;
					string chat = "YOU KNOW WHAT FIGHT MY GREAT GREAT GRANDCHILDREN YOU DUM IDOT STICK!!?!?!?!?@#34";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat32 = false;
					for (int i = 0; i < 30; i++) {
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.Plantera);
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.CultistBoss);
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.SolarCrawltipedeHead);
					}
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.23f))
				if (chat33)
				{
					Color messageColor = Color.DarkRed;
					string chat = "O NO I AM DYING!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat33 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.21f))
				if (chat34)
				{
					Color messageColor = Color.DarkRed;
					string chat = "That doesn't mak any SENSE!? YOU MUST BE CHEATING!?!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat34 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.19f))
				if (chat35)
				{
					Color messageColor = Color.DarkRed;
					string chat = "You, a human!? Defeating ME!?!?!?!?!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat35 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.17f))
				if (chat36)
				{
					Color messageColor = Color.DarkRed;
					string chat = "U NO WHAT!? COME AND GET ME YOU CHEATING CHICHIN@!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat36 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.16f))
				if (chat37)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Let me tell you a story.";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat37 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.15f))
				if (chat38)
				{
					Color messageColor = Color.DarkRed;
					string chat = "After I killed all my friends for no reason, an evil universe takeover man asked me to join him on his EVIL plans.";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat38 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.14f))
				if (chat39)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I said NO YOU STINKY CRAPHOLE, YOUR MOMS SO FAT-";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat39 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.13f))
				if (chat40)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then HE KILLED my PARENTS!>!>?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat40 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.12f))
				if (chat41)
				{
					Color messageColor = Color.DarkRed;
					string chat = "I got so angery I slapped him so HARD he went into a BLACK HOEL!?!?!*@$&)^RT#*YEGFUWK";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat41 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.11f))
				if (chat42)
				{
					Color messageColor = Color.DarkRed;
					string chat = "Then I was so powerful I reviedsd them and now they are OK!?";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat42 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.1f))
				if (chat43)
				{
					Color messageColor = Color.DarkRed;
					string chat = "IN FACT, HERE they are NOW!!??!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat43 = false;
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.Harpy);
					NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.Everscream);
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.09f))
				if (chat44)
				{
					Color messageColor = Color.DarkRed;
					string chat = "...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat44 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.08f))
				if (chat45)
				{
					Color messageColor = Color.DarkRed;
					string chat = "...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat45 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.07f))
				if (chat46)
				{
					Color messageColor = Color.DarkRed;
					string chat = "It appears that the current time, which is one of suffering, is continuing, despite the severe injuries the both of us, I suffering extreme, irreversible damage, and I, a being of supreme evil, feel the urge, caused by my state of cockiness, a mask I hide behind to hide the fear, to tell you, a homo sapien of admirable power and endurance, which I shall past this point, refer to as “kiddo”, as an insult.";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat46 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.06f))
				if (chat47)
				{
					Color messageColor = Color.DarkRed;
					string chat = "See I AM BIGGEST BRAIN!?! UNLIKE U NOOB!?!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat47 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.05f))
				if (chat48)
				{
					Color messageColor = Color.DarkRed;
					string chat = "To reach MAXIMUM EDGINESS, I will say a BAD BAD BAD wordd!?!?4387950";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat48 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.04f))
				if (chat49)
				{
					Color messageColor = Color.DarkRed;
					string chat = "3, 2, 1.... ****!?!?!? HAHAAH U AREW WETING YOUR PANTS AFTER Hearin THAT@>";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat49 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.03f))
				if (chat50)
				{
					Color messageColor = Color.DarkRed;
					string chat = "alright since I am about to die  I am going to spam my best friend's goldfish's child's son's daughter's best friend's sister's owner's father's murderer's son's child's best friends at U)(*&^%$#@!#$%^^^^??!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat50 = false;
					for (int i = 0; i < 30; i++) {
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-600, 601), (int)npc.position.Y - 600, NPCID.DukeFishron);
					}
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.02f))
				if (chat51)
				{
					Color messageColor = Color.DarkRed;
					string chat = "UWU";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat51 = false;
				}
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.02f))
				if (chat52)
				{
					Color messageColor = Color.DarkRed;
					string chat = "CHAGNE WORLD< FINAL MESSAFEGE< GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOODBYE YOU SUCKER BUTTHOLE PIECE OF CRAP!)(*&^%$#@";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat52 = false;
				}

			attackTime += 2f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.875f))
				attackTime += 0.4f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.75f))
				attackTime += 0.4f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.625f))
				attackTime += 0.4f;	
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.5f))
				attackTime += 0.4f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.325f))
				attackTime += 0.4f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.25f))
				attackTime += 0.4f;
			if ((double)(npc.life) < (double)(npc.lifeMax * 0.125f))
				attackTime += 0.4f;
			if (AzercadmiumWorld.devastation)
				attackTime += 2f;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
									{
										npc.TargetClosest(true);
									}
									bool dead2 = Main.player[npc.target].dead;
									float num376 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
									float num377 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
									float num378 = (float)Math.Atan2((double)num377, (double)num376) + 1.57f;
									if (num378 < 0f)
									{
										num378 += 6.283f;
									}
									else if ((double)num378 > 6.283)
									{
										num378 -= 6.283f;
									}
									float num379 = 0.1f;
									if (npc.rotation < num378)
									{
										if ((double)(num378 - npc.rotation) > 3.1415)
										{
											npc.rotation -= num379;
										}
										else
										{
											npc.rotation += num379;
										}
									}
									else if (npc.rotation > num378)
									{
										if ((double)(npc.rotation - num378) > 3.1415)
										{
											npc.rotation += num379;
										}
										else
										{
											npc.rotation -= num379;
										}
									}
									if (npc.rotation > num378 - num379 && npc.rotation < num378 + num379)
									{
										npc.rotation = num378;
									}
									if (npc.rotation < 0f)
									{
										npc.rotation += 6.283f;
									}
									else if ((double)npc.rotation > 6.283)
									{
										npc.rotation -= 6.283f;
									}
									if (npc.rotation > num378 - num379 && npc.rotation < num378 + num379)
									{
										npc.rotation = num378;
									}
									if (Main.rand.Next(5) == 0)
									{
										int num380 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_131D1_cp_0_cp_0 = Main.dust[num380];
										var_9_131D1_cp_0_cp_0.velocity.X = var_9_131D1_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_131F5_cp_0_cp_0 = Main.dust[num380];
										var_9_131F5_cp_0_cp_0.velocity.Y = var_9_131F5_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != 1 && !Main.dayTime && !dead2 && npc.timeLeft < 10)
									{
										int num;
										for (int num381 = 0; num381 < 200; num381 = num + 1)
										{
											if (num381 != npc.whoAmI && Main.npc[num381].active && (Main.npc[num381].type == 125 || Main.npc[num381].type == 126) && Main.npc[num381].timeLeft - 1 > npc.timeLeft)
											{
												npc.timeLeft = Main.npc[num381].timeLeft - 1;
											}
											num = num381;
										}
									}
									if (Main.dayTime | dead2)
									{
										npc.velocity.Y = npc.velocity.Y - 0.04f;
										if (npc.timeLeft > 10)
										{
											npc.timeLeft = 10;
											return;
										}
									}
									else if (npc.ai[0] == 0f)
									{
										if (npc.ai[1] == 0f)
										{
											float num382 = 7f;
											float num383 = 0.1f;
											if (Main.expertMode)
											{
												num382 = 8.25f;
												num383 = 0.115f;
											}
											int num384 = 1;
											if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
											{
												num384 = -1;
											}
											Vector2 vector40 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num385 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num384 * 300) - vector40.X;
											float num386 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector40.Y;
											float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
											float num388 = num387;
											num387 = num382 / num387;
											num385 *= num387;
											num386 *= num387;
											if (npc.velocity.X < num385)
											{
												npc.velocity.X = npc.velocity.X + num383;
												if (npc.velocity.X < 0f && num385 > 0f)
												{
													npc.velocity.X = npc.velocity.X + num383;
												}
											}
											else if (npc.velocity.X > num385)
											{
												npc.velocity.X = npc.velocity.X - num383;
												if (npc.velocity.X > 0f && num385 < 0f)
												{
													npc.velocity.X = npc.velocity.X - num383;
												}
											}
											if (npc.velocity.Y < num386)
											{
												npc.velocity.Y = npc.velocity.Y + num383;
												if (npc.velocity.Y < 0f && num386 > 0f)
												{
													npc.velocity.Y = npc.velocity.Y + num383;
												}
											}
											else if (npc.velocity.Y > num386)
											{
												npc.velocity.Y = npc.velocity.Y - num383;
												if (npc.velocity.Y > 0f && num386 < 0f)
												{
													npc.velocity.Y = npc.velocity.Y - num383;
												}
											}
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 600f)
											{
												npc.ai[1] = 1f;
												npc.ai[2] = 0f;
												npc.ai[3] = 0f;
												npc.target = 255;
												npc.netUpdate = true;
											}
											else if (npc.position.Y + (float)npc.height < Main.player[npc.target].position.Y && num388 < 400f)
											{
												if (!Main.player[npc.target].dead)
												{
													npc.ai[3] += 1f;
													if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.9)
													{
														npc.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.8)
													{
														npc.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.7)
													{
														npc.ai[3] += 0.3f;
													}
													if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.6)
													{
														npc.ai[3] += 0.3f;
													}
												}
												
											}
										}
										else if (npc.ai[1] == 1f)
										{
											npc.rotation = num378;
											float num393 = 12f;
											if (Main.expertMode)
											{
												num393 = 15f;
											}
											Vector2 vector41 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num394 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector41.X;
											float num395 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector41.Y;
											float num396 = (float)Math.Sqrt((double)(num394 * num394 + num395 * num395));
											num396 = num393 / num396;
											npc.velocity.X = num394 * num396;
											npc.velocity.Y = num395 * num396;
											npc.ai[1] = 2f;
										}
										else if (npc.ai[1] == 2f)
										{
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 25f)
											{
												npc.velocity.X = npc.velocity.X * 0.96f;
												npc.velocity.Y = npc.velocity.Y * 0.96f;
												if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
												{
													npc.velocity.X = 0f;
												}
												if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
												{
													npc.velocity.Y = 0f;
												}
											}
											else
											{
												npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
											}
											if (npc.ai[2] >= 70f)
											{
												npc.ai[3] += 1f;
												npc.ai[2] = 0f;
												npc.target = 255;
												npc.rotation = num378;
												if (npc.ai[3] >= 4f)
												{
													npc.ai[1] = 0f;
													npc.ai[3] = 0f;
												}
												else
												{
													npc.ai[1] = 1f;
												}
											}
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.4)
										{
											npc.ai[0] = 1f;
											npc.ai[1] = 0f;
											npc.ai[2] = 0f;
											npc.ai[3] = 0f;
											npc.netUpdate = true;
											return;
										}
									}
									else if (npc.ai[0] == 1f || npc.ai[0] == 2f)
									{
										if (npc.ai[0] == 1f)
										{
											npc.ai[2] += 0.005f;
											if ((double)npc.ai[2] > 0.5)
											{
												npc.ai[2] = 0.5f;
											}
										}
										else
										{
											npc.ai[2] -= 0.005f;
											if (npc.ai[2] < 0f)
											{
												npc.ai[2] = 0f;
											}
										}
										npc.rotation += npc.ai[2];
										npc.ai[1] += 1f;
										if (npc.ai[1] == 100f)
										{
											npc.ai[0] += 1f;
											npc.ai[1] = 0f;
											if (npc.ai[0] == 3f)
											{
												npc.ai[2] = 0f;
											}
											else
											{
												Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1, 1f, 0f);
												int num;
												for (int num397 = 0; num397 < 2; num397 = num + 1)
												{
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num397;
												}
												for (int num398 = 0; num398 < 20; num398 = num + 1)
												{
													Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num398;
												}
												Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
											}
										}
										Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										npc.velocity.X = npc.velocity.X * 0.98f;
										npc.velocity.Y = npc.velocity.Y * 0.98f;
										if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
										{
											npc.velocity.X = 0f;
										}
										if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
										{
											npc.velocity.Y = 0f;
											return;
										}
									}
									else
									{
										npc.damage = (int)((double)npc.defDamage * 1.5);
										npc.defense = npc.defDefense + 10;
										npc.HitSound = SoundID.NPCHit4;
										if (npc.ai[1] == 0f)
										{
											float num399 = 8f;
											float num400 = 0.15f;
											if (Main.expertMode)
											{
												num399 = 9.5f;
												num400 = 0.175f;
											}
											Vector2 vector42 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num401 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector42.X;
											float num402 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - 300f - vector42.Y;
											float num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
											num403 = num399 / num403;
											num401 *= num403;
											num402 *= num403;
											if (npc.velocity.X < num401)
											{
												npc.velocity.X = npc.velocity.X + num400;
												if (npc.velocity.X < 0f && num401 > 0f)
												{
													npc.velocity.X = npc.velocity.X + num400;
												}
											}
											else if (npc.velocity.X > num401)
											{
												npc.velocity.X = npc.velocity.X - num400;
												if (npc.velocity.X > 0f && num401 < 0f)
												{
													npc.velocity.X = npc.velocity.X - num400;
												}
											}
											if (npc.velocity.Y < num402)
											{
												npc.velocity.Y = npc.velocity.Y + num400;
												if (npc.velocity.Y < 0f && num402 > 0f)
												{
													npc.velocity.Y = npc.velocity.Y + num400;
												}
											}
											else if (npc.velocity.Y > num402)
											{
												npc.velocity.Y = npc.velocity.Y - num400;
												if (npc.velocity.Y > 0f && num402 < 0f)
												{
													npc.velocity.Y = npc.velocity.Y - num400;
												}
											}
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 300f)
											{
												npc.ai[1] = 1f;
												npc.ai[2] = 0f;
												npc.ai[3] = 0f;
												npc.TargetClosest(true);
												npc.netUpdate = true;
											}
											vector42 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											num401 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector42.X;
											num402 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector42.Y;
											npc.rotation = (float)Math.Atan2((double)num402, (double)num401) - 1.57f;
											if (Main.netMode != 1)
											{
												npc.localAI[1] += 1f;
												if ((double)npc.life < (double)npc.lifeMax * 0.75)
												{
													npc.localAI[1] += 1f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.5)
												{
													npc.localAI[1] += 1f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.25)
												{
													npc.localAI[1] += 1f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.1)
												{
													npc.localAI[1] += 2f;
												}
												if (npc.localAI[1] > 60f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
												{
													npc.localAI[1] = 0f;
													float num404 = 8.5f;
													int num405 = 50; //25
													int num406 = 100;
													if (Main.expertMode)
													{
														num404 = 10f;
														num405 = 46; //46
													}
													num403 = (float)Math.Sqrt((double)(num401 * num401 + num402 * num402));
													num403 = num404 / num403;
													num401 *= num403;
													num402 *= num403;
													vector42.X += num401 * 15f;
													vector42.Y += num402 * 15f;
													int num407 = Projectile.NewProjectile(vector42.X, vector42.Y, num401, num402, num406, num405, 0f, Main.myPlayer, 0f, 0f);
													return;
												}
											}
										}
										else
										{
											int num408 = 1;
											if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
											{
												num408 = -1;
											}
											float num409 = 8f;
											float num410 = 0.2f;
											if (Main.expertMode)
											{
												num409 = 9.5f;
												num410 = 0.25f;
											}
											Vector2 vector43 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num411 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num408 * 340) - vector43.X;
											float num412 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector43.Y;
											float num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
											num413 = num409 / num413;
											num411 *= num413;
											num412 *= num413;
											if (npc.velocity.X < num411)
											{
												npc.velocity.X = npc.velocity.X + num410;
												if (npc.velocity.X < 0f && num411 > 0f)
												{
													npc.velocity.X = npc.velocity.X + num410;
												}
											}
											else if (npc.velocity.X > num411)
											{
												npc.velocity.X = npc.velocity.X - num410;
												if (npc.velocity.X > 0f && num411 < 0f)
												{
													npc.velocity.X = npc.velocity.X - num410;
												}
											}
											if (npc.velocity.Y < num412)
											{
												npc.velocity.Y = npc.velocity.Y + num410;
												if (npc.velocity.Y < 0f && num412 > 0f)
												{
													npc.velocity.Y = npc.velocity.Y + num410;
												}
											}
											else if (npc.velocity.Y > num412)
											{
												npc.velocity.Y = npc.velocity.Y - num410;
												if (npc.velocity.Y > 0f && num412 < 0f)
												{
													npc.velocity.Y = npc.velocity.Y - num410;
												}
											}
											vector43 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											num411 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector43.X;
											num412 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector43.Y;
											npc.rotation = (float)Math.Atan2((double)num412, (double)num411) - 1.57f;
											if (Main.netMode != 1)
											{
												npc.localAI[1] += 1f;
												if ((double)npc.life < (double)npc.lifeMax * 0.75)
												{
													npc.localAI[1] += 0.5f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.5)
												{
													npc.localAI[1] += 0.75f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.25)
												{
													npc.localAI[1] += 1f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.1)
												{
													npc.localAI[1] += 1.5f;
												}
												if (Main.expertMode)
												{
													npc.localAI[1] += 1.5f;
												}
												if (npc.localAI[1] > 180f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
												{
													npc.localAI[1] = 0f;
													float num414 = 9f;
													int num415 = 36; //18
													int num416 = 100;
													if (Main.expertMode)
													{
														num415 = 34; //17
													}
													num413 = (float)Math.Sqrt((double)(num411 * num411 + num412 * num412));
													num413 = num414 / num413;
													num411 *= num413;
													num412 *= num413;
													vector43.X += num411 * 15f;
													vector43.Y += num412 * 15f;
													int num417 = Projectile.NewProjectile(vector43.X, vector43.Y, num411, num412, num416, num415, 0f, Main.myPlayer, 0f, 0f);
												}
											}
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 180f)
											{
												npc.ai[1] = 0f;
												npc.ai[2] = 0f;
												npc.ai[3] = 0f;
												npc.TargetClosest(true);
												npc.netUpdate = true;
												return;
											}
										}
									}
									if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
									{
										npc.TargetClosest(true);
									}
									bool dead3 = Main.player[npc.target].dead;
									float num418 = npc.position.X + (float)(npc.width / 2) - Main.player[npc.target].position.X - (float)(Main.player[npc.target].width / 2);
									float num419 = npc.position.Y + (float)npc.height - 59f - Main.player[npc.target].position.Y - (float)(Main.player[npc.target].height / 2);
									float num420 = (float)Math.Atan2((double)num419, (double)num418) + 1.57f;
									if (num420 < 0f)
									{
										num420 += 6.283f;
									}
									else if ((double)num420 > 6.283)
									{
										num420 -= 6.283f;
									}
									float num421 = 0.15f;
									if (npc.rotation < num420)
									{
										if ((double)(num420 - npc.rotation) > 3.1415)
										{
											npc.rotation -= num421;
										}
										else
										{
											npc.rotation += num421;
										}
									}
									else if (npc.rotation > num420)
									{
										if ((double)(npc.rotation - num420) > 3.1415)
										{
											npc.rotation += num421;
										}
										else
										{
											npc.rotation -= num421;
										}
									}
									if (npc.rotation > num420 - num421 && npc.rotation < num420 + num421)
									{
										npc.rotation = num420;
									}
									if (npc.rotation < 0f)
									{
										npc.rotation += 6.283f;
									}
									else if ((double)npc.rotation > 6.283)
									{
										npc.rotation -= 6.283f;
									}
									if (npc.rotation > num420 - num421 && npc.rotation < num420 + num421)
									{
										npc.rotation = num420;
									}
									if (Main.rand.Next(5) == 0)
									{
										int num422 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
										Dust var_9_15364_cp_0_cp_0 = Main.dust[num422];
										var_9_15364_cp_0_cp_0.velocity.X = var_9_15364_cp_0_cp_0.velocity.X * 0.5f;
										Dust var_9_15388_cp_0_cp_0 = Main.dust[num422];
										var_9_15388_cp_0_cp_0.velocity.Y = var_9_15388_cp_0_cp_0.velocity.Y * 0.1f;
									}
									if (Main.netMode != 1 && !Main.dayTime && !dead3 && npc.timeLeft < 10)
									{
										int num;
										for (int num423 = 0; num423 < 200; num423 = num + 1)
										{
											if (num423 != npc.whoAmI && Main.npc[num423].active && (Main.npc[num423].type == 125 || Main.npc[num423].type == 126) && Main.npc[num423].timeLeft - 1 > npc.timeLeft)
											{
												npc.timeLeft = Main.npc[num423].timeLeft - 1;
											}
											num = num423;
										}
									}
									if (Main.dayTime | dead3)
									{
										npc.velocity.Y = npc.velocity.Y - 0.04f;
										if (npc.timeLeft > 10)
										{
											npc.timeLeft = 10;
											return;
										}
									}
									else if (npc.ai[0] == 0f)
									{
										if (npc.ai[1] == 0f)
										{
											npc.TargetClosest(true);
											float num424 = 12f;
											float num425 = 0.4f;
											int num426 = 1;
											if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
											{
												num426 = -1;
											}
											Vector2 vector44 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num427 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num426 * 400) - vector44.X;
											float num428 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector44.Y;
											float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
											num429 = num424 / num429;
											num427 *= num429;
											num428 *= num429;
											if (npc.velocity.X < num427)
											{
												npc.velocity.X = npc.velocity.X + num425;
												if (npc.velocity.X < 0f && num427 > 0f)
												{
													npc.velocity.X = npc.velocity.X + num425;
												}
											}
											else if (npc.velocity.X > num427)
											{
												npc.velocity.X = npc.velocity.X - num425;
												if (npc.velocity.X > 0f && num427 < 0f)
												{
													npc.velocity.X = npc.velocity.X - num425;
												}
											}
											if (npc.velocity.Y < num428)
											{
												npc.velocity.Y = npc.velocity.Y + num425;
												if (npc.velocity.Y < 0f && num428 > 0f)
												{
													npc.velocity.Y = npc.velocity.Y + num425;
												}
											}
											else if (npc.velocity.Y > num428)
											{
												npc.velocity.Y = npc.velocity.Y - num425;
												if (npc.velocity.Y > 0f && num428 < 0f)
												{
													npc.velocity.Y = npc.velocity.Y - num425;
												}
											}
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 600f)
											{
												npc.ai[1] = 1f;
												npc.ai[2] = 0f;
												npc.ai[3] = 0f;
												npc.target = 255;
												npc.netUpdate = true;
											}
											else
											{
												if (!Main.player[npc.target].dead)
												{
													npc.ai[3] += 1f;
													if (Main.expertMode && (double)npc.life < (double)npc.lifeMax * 0.8)
													{
														npc.ai[3] += 0.6f;
													}
												}
											}
										}
										else if (npc.ai[1] == 1f)
										{
											npc.rotation = num420;
											float num434 = 13f;
											if (Main.expertMode)
											{
												if ((double)npc.life < (double)npc.lifeMax * 0.9)
												{
													num434 += 0.5f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.8)
												{
													num434 += 0.5f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.7)
												{
													num434 += 0.55f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.6)
												{
													num434 += 0.6f;
												}
												if ((double)npc.life < (double)npc.lifeMax * 0.5)
												{
													num434 += 0.65f;
												}
											}
											Vector2 vector45 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num435 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector45.X;
											float num436 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector45.Y;
											float num437 = (float)Math.Sqrt((double)(num435 * num435 + num436 * num436));
											num437 = num434 / num437;
											npc.velocity.X = num435 * num437;
											npc.velocity.Y = num436 * num437;
											npc.ai[1] = 2f;
										}
										else if (npc.ai[1] == 2f)
										{
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 8f)
											{
												npc.velocity.X = npc.velocity.X * 0.9f;
												npc.velocity.Y = npc.velocity.Y * 0.9f;
												if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
												{
													npc.velocity.X = 0f;
												}
												if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
												{
													npc.velocity.Y = 0f;
												}
											}
											else
											{
												npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
											}
											if (npc.ai[2] >= 42f)
											{
												npc.ai[3] += 1f;
												npc.ai[2] = 0f;
												npc.target = 255;
												npc.rotation = num420;
												if (npc.ai[3] >= 10f)
												{
													npc.ai[1] = 0f;
													npc.ai[3] = 0f;
												}
												else
												{
													npc.ai[1] = 1f;
												}
											}
										}
										if ((double)npc.life < (double)npc.lifeMax * 0.4)
										{
											npc.ai[0] = 1f;
											npc.ai[1] = 0f;
											npc.ai[2] = 0f;
											npc.ai[3] = 0f;
											npc.netUpdate = true;
											return;
										}
									}
									else if (npc.ai[0] == 1f || npc.ai[0] == 2f)
									{
										if (npc.ai[0] == 1f)
										{
											npc.ai[2] += 0.005f;
											if ((double)npc.ai[2] > 0.5)
											{
												npc.ai[2] = 0.5f;
											}
										}
										else
										{
											npc.ai[2] -= 0.005f;
											if (npc.ai[2] < 0f)
											{
												npc.ai[2] = 0f;
											}
										}
										npc.rotation += npc.ai[2];
										npc.ai[1] += 1f;
										if (npc.ai[1] == 100f)
										{
											npc.ai[0] += 1f;
											npc.ai[1] = 0f;
											if (npc.ai[0] == 3f)
											{
												npc.ai[2] = 0f;
											}
											else
											{
												Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1, 1f, 0f);
												int num;
												for (int num438 = 0; num438 < 2; num438 = num + 1)
												{
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
													Gore.NewGore(npc.position, new Vector2((float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
													num = num438;
												}
												for (int num439 = 0; num439 < 20; num439 = num + 1)
												{
													Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
													num = num439;
												}
												Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
											}
										}
										Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)Main.rand.Next(-30, 31) * 0.2f, (float)Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
										npc.velocity.X = npc.velocity.X * 0.98f;
										npc.velocity.Y = npc.velocity.Y * 0.98f;
										if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
										{
											npc.velocity.X = 0f;
										}
										if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
										{
											npc.velocity.Y = 0f;
											return;
										}
									}
									else
									{
										npc.HitSound = SoundID.NPCHit4;
										npc.damage = (int)((double)npc.defDamage * 1.5);
										npc.defense = npc.defDefense + 18;
										if (npc.ai[1] == 0f)
										{
											float num440 = 4f;
											float num441 = 0.1f;
											int num442 = 1;
											if (npc.position.X + (float)(npc.width / 2) < Main.player[npc.target].position.X + (float)Main.player[npc.target].width)
											{
												num442 = -1;
											}
											Vector2 vector46 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
											float num443 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) + (float)(num442 * 180) - vector46.X;
											float num444 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector46.Y;
											float num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
											if (Main.expertMode)
											{
												if (num445 > 300f)
												{
													num440 += 0.5f;
												}
												if (num445 > 400f)
												{
													num440 += 0.5f;
												}
												if (num445 > 500f)
												{
													num440 += 0.55f;
												}
												if (num445 > 600f)
												{
													num440 += 0.55f;
												}
												if (num445 > 700f)
												{
													num440 += 0.6f;
												}
												if (num445 > 800f)
												{
													num440 += 0.6f;
												}
											}
											num445 = num440 / num445;
											num443 *= num445;
											num444 *= num445;
											if (npc.velocity.X < num443)
											{
												npc.velocity.X = npc.velocity.X + num441;
												if (npc.velocity.X < 0f && num443 > 0f)
												{
													npc.velocity.X = npc.velocity.X + num441;
												}
											}
											else if (npc.velocity.X > num443)
											{
												npc.velocity.X = npc.velocity.X - num441;
												if (npc.velocity.X > 0f && num443 < 0f)
												{
													npc.velocity.X = npc.velocity.X - num441;
												}
											}
											if (npc.velocity.Y < num444)
											{
												npc.velocity.Y = npc.velocity.Y + num441;
												if (npc.velocity.Y < 0f && num444 > 0f)
												{
													npc.velocity.Y = npc.velocity.Y + num441;
												}
											}
											else if (npc.velocity.Y > num444)
											{
												npc.velocity.Y = npc.velocity.Y - num441;
												if (npc.velocity.Y > 0f && num444 < 0f)
												{
													npc.velocity.Y = npc.velocity.Y - num441;
												}
											}
											npc.ai[2] += 1f;
											if (npc.ai[2] >= 400f)
											{
												npc.ai[1] = 1f;
												npc.ai[2] = 0f;
												npc.ai[3] = 0f;
												npc.target = 255;
												npc.netUpdate = true;
											}
											if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
											{
												npc.localAI[2] += 1f;
												if (npc.localAI[2] > 22f)
												{
													npc.localAI[2] = 0f;
													Main.PlaySound(SoundID.Item34, npc.position);
												}
												if (Main.netMode != 1)
												{
													npc.localAI[1] += 1f;
													if ((double)npc.life < (double)npc.lifeMax * 0.75)
													{
														npc.localAI[1] += 1f;
													}
													if ((double)npc.life < (double)npc.lifeMax * 0.5)
													{
														npc.localAI[1] += 1f;
													}
													if ((double)npc.life < (double)npc.lifeMax * 0.25)
													{
														npc.localAI[1] += 1f;
													}
													if ((double)npc.life < (double)npc.lifeMax * 0.1)
													{
														npc.localAI[1] += 2f;
													}
													if (npc.localAI[1] > 2f)
													{
														npc.localAI[1] = 0f;
														float num446 = 6f;
														int num447 = 60; //30
														if (Main.expertMode)
														{
															num447 = 54; //27
														}
														int num448 = 101;
														vector46 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
														num443 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector46.X;
														num444 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector46.Y;
														num445 = (float)Math.Sqrt((double)(num443 * num443 + num444 * num444));
														num445 = num446 / num445;
														num443 *= num445;
														num444 *= num445;
														num444 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num443 += (float)Main.rand.Next(-40, 41) * 0.01f;
														num444 += npc.velocity.Y * 0.5f;
														num443 += npc.velocity.X * 0.5f;
														vector46.X -= num443 * 1f;
														vector46.Y -= num444 * 1f;
														int num449 = Projectile.NewProjectile(vector46.X, vector46.Y, num443, num444, num448, num447, 0f, Main.myPlayer, 0f, 0f);
														return;
													}
												}
											}
										}
										else
										{
											if (npc.ai[1] == 1f)
											{
												Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0, 1f, 0f);
												npc.rotation = num420;
												float num450 = 14f;
												if (Main.expertMode)
												{
													num450 += 2.5f;
												}
												Vector2 vector47 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
												float num451 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector47.X;
												float num452 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector47.Y;
												float num453 = (float)Math.Sqrt((double)(num451 * num451 + num452 * num452));
												num453 = num450 / num453;
												npc.velocity.X = num451 * num453;
												npc.velocity.Y = num452 * num453;
												npc.ai[1] = 2f;
												return;
											}
											if (npc.ai[1] == 2f)
											{
												npc.ai[2] += 1f;
												if (Main.expertMode)
												{
													npc.ai[2] += 0.5f;
												}
												if (npc.ai[2] >= 50f)
												{
													npc.velocity.X = npc.velocity.X * 0.93f;
													npc.velocity.Y = npc.velocity.Y * 0.93f;
													if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1)
													{
														npc.velocity.X = 0f;
													}
													if ((double)npc.velocity.Y > -0.1 && (double)npc.velocity.Y < 0.1)
													{
														npc.velocity.Y = 0f;
													}
												}
												else
												{
													npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
												}
												if (npc.ai[2] >= 80f)
												{
													npc.ai[3] += 1f;
													npc.ai[2] = 0f;
													npc.target = 255;
													npc.rotation = num420;
													if (npc.ai[3] >= 6f)
													{
														npc.ai[1] = 0f;
														npc.ai[3] = 0f;
														return;
													}
													npc.ai[1] = 1f;
													return;
												}
											}
										}
										
									}
									if (attackTime >= 60f)
												{
													attackTime = 0f;
													Vector2 vector40 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
													float num385 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector40.X;
													float num386 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector40.Y;
														float num389 = 9f;
														int num390 = 40; //20
														int num391 = 83;
														if (Main.expertMode)
														{
															num389 = 10.5f;
															num390 = 38; //19
														}
														float num387 = (float)Math.Sqrt((double)(num385 * num385 + num386 * num386));
														num387 = num389 / num387;
														num385 *= num387;
														num386 *= num387;
														num385 += (float)Main.rand.Next(-40, 41) * 0.08f;
														num386 += (float)Main.rand.Next(-40, 41) * 0.08f;
														vector40.X += num385 * 15f;
														vector40.Y += num386 * 15f;
													Projectile.NewProjectile(vector40.X, vector40.Y, num385, num386, num391, num390, 0f, Main.myPlayer, 0f, 0f);
													npc.ai[3] = 0f;
													Vector2 vector44 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
													float num427 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector44.X;
													float num428 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector44.Y;
													if (Main.netMode != 1)
													{
														float num430 = 8f;
														int num431 = 50; //25
														int num432 = 96;
														if (Main.expertMode)
														{
															num430 = 9f;
															num431 = 44; //22
														}
														float num429 = (float)Math.Sqrt((double)(num427 * num427 + num428 * num428));
														num429 = num430 / num429;
														num427 *= num429;
														num428 *= num429;
														num427 += (float)Main.rand.Next(-40, 41) * 0.05f;
														num428 += (float)Main.rand.Next(-40, 41) * 0.05f;
														vector44.X += num427 * 4f;
														vector44.Y += num428 * 4f;
														Projectile.NewProjectile(vector44.X, vector44.Y, num427, num428, num432, num431, 0f, Main.myPlayer, 0f, 0f);
													}
												}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 2; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void NPCLoot() {
			if (Timer < 3600) {
				int playerCount;
				for (playerCount = 0; playerCount < 255; playerCount++) {
					if (Main.player[playerCount].active) {
						Player target = Main.player[playerCount];
						target.KillMe(PlayerDeathReason.ByCustomReason(target.name + " was a BAD BOI CHEATER!?!?!?!?!?"), 9999, 0, false);
					}
				}
			}

		}
	}
}