using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Azercadmium.Items.Slime;

namespace Azercadmium.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Braycoe : ModNPC
	{
		public override string Texture => "Azercadmium/NPCs/TownNPCs/Braycoe";
		private static bool impression = false;
		private static int shopNum = 1;
		public override bool Autoload(ref string name)
		{
			name = "Slime Master";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Master");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			if (NPC.downedMoonlord)
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 600;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 50;
			NPCID.Sets.AttackAverageChance[npc.type] = 50;
			}
			else if (Main.hardMode)
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 550;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 75;
			NPCID.Sets.AttackAverageChance[npc.type] = 40;
			}
			else
			{
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			}
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.HitSound = SoundID.NPCHit1;
			npc.scale = 1f;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide;
			if (NPC.downedMoonlord) {
			npc.damage = 98;
			npc.defense = 1000;
			npc.lifeMax = 2500;
			npc.knockBackResist = 0.3f;
			}
			else if (Main.hardMode) {
			npc.damage = 44;
			npc.defense = 55;
			npc.lifeMax = 750;
			npc.knockBackResist = 0.4f;
			}
			else {
			npc.damage = 11;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.5f;
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (Main.dayTime && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].active) {
				if (NPC.downedSlimeKing)
				return true;
			}
			return false;
		}
		public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
		public override string TownNPCName()
		{
			return "Braycoe";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("No, I will not turn into a green slime for you.");
			chat.Add("I can turn into any slime, name one and I could do it.");
			chat.Add("You won the lottery! No, not really.", 0.001);
			chat.Add("Can my house be a bit bigger? Oh, never mind...");
			chat.Add("Destroy the dark power of this world!");
			chat.Add("Get stronger and I will sell stronger items and reveal more of my power.");
			chat.Add("Lemonade Tea is an excellent drink!");
			chat.Add("If you think about it, blackberries are just very small grapes.");
			chat.Add("Have you happened to see any Azercadmium Ore anywhere? No?");
			chat.Add("Have you ever heard of a Starlite Crystal..? Never mind.");
			chat.Add("Yes, being a slime is fun.");
			chat.Add("Have you seen my slimebender anywhere?");
			chat.Add("If you get your hands on Azercadmium, you would probably be one of the greatest terrarians of all time. Or a cheater.");
			chat.Add("No, I don't care that I break the fourth wall sometimes!");
			chat.Add("I miss the good old days, when it was actually fun to develop Azercadmium.", 0.1f);
			chat.Add("Azercadmium's slowly disappearing, you know.", 0.1f);
			chat.Add("What..?", 0.5);
			chat.Add("What?", 0.5);
			chat.Add("What.", 0.5);
			if (AzercadmiumWorld.devastation)
				chat.Add("Devastation mode is very WIP, I hope you like it so far.", 2);
			if (Main.raining)
				chat.Add("Hey, since I generate slime a lot faster while its raining, I'll sell gel to you for a discount price! Buy some now!", 6);
		    if (NPC.downedSlimeKing == true)
				chat.Add("That King Slime is such a loser, thanks for breaking him into hundreds of normal size slimes.");
			if (Main.hardMode && !NPC.downedMechBossAny)
				chat.Add("Early hardmode getting the best of you?", 2);
			if (NPC.downedMoonlord)
				chat.Add("You defeated the Moon Lord? It appears you have broken the Moon Seal, and new things will happen in your world. Of course, that is for a future update.", 1.5);
			return chat;
		}
		int Timer;
		public override void AI() {
			Timer++;
			if (NPC.downedMoonlord && Timer % 10 == 0 && npc.life < npc.lifeMax)
				npc.life += 1;
			if (npc.life > npc.lifeMax)
				npc.life = npc.lifeMax;
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			switch (shopNum) {
                case 1:
                    button = Language.GetTextValue("LegacyInterface.28");
                    break;
                case 2:
                    button = "Challenge";
                    break;
            }
			button2 = "Cycle Options";
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			if (firstButton)
			{
				if (shopNum == 1)
				shop = true;
				else if (shopNum == 2) {
					WeightedRandom<string> challenge = new WeightedRandom<string>();
					challenge.Add("You are clearly not ready.");
					challenge.Add("I don't care if you slayed several cosmic beings!");
					challenge.Add("Come back later.");
					challenge.Add("Nah.");
					challenge.Add("Go wait for V1.0 to release.");
					challenge.Add("Nope.");
					challenge.Add("Convince me to bring back the harp subclass first.");
					challenge.Add("Go away.");
					challenge.Add("Are you kidding me?");
					challenge.Add("Make developing Azercadmium fun again.");
					Main.npcChatText = challenge;
				}
			}
			else {
				shopNum += 1;
				if (shopNum > 2)
					shopNum = 1;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.Gel);
			if (Main.raining)
				shop.item[nextSlot].shopCustomPrice = 1;
			else
				shop.item[nextSlot].shopCustomPrice = 3;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<SlimySeed>());
			shop.item[nextSlot].shopCustomPrice = 5;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("DeliciousGelatin"));
			shop.item[nextSlot].shopCustomPrice = 2000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("CheckeredFlag"));
			shop.item[nextSlot].shopCustomPrice = 250000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Slime.GiantGelCluster>());
			shop.item[nextSlot].shopCustomPrice = 250000;
			nextSlot++;
			if (Main.hardMode == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.Developer.Braycoe.LemonadeTea>());
				shop.item[nextSlot].shopCustomPrice = 2500;
			    nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			if (NPC.downedMoonlord)
			{
			damage = 169;
			knockback = 4f;
			}
			else if (Main.hardMode)
			{
			damage = 44;
			knockback = 3f;
			}
			else
			{
			damage = 8;
			knockback = 2f;
			}
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			if (NPC.downedMoonlord)
			{
			cooldown = 8;
			randExtraCooldown = 6;
			}
			else if (Main.hardMode)
			{
			cooldown = 10;
			randExtraCooldown = 5;
			}
			else
			{
			cooldown = 12;
			randExtraCooldown = 5;
			}
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("Slimeball");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			if (NPC.downedMoonlord)
			{
			multiplier = 12f;
			randomOffset = 4f;
			}
			else if (Main.hardMode)
			{
			multiplier = 11f;
			randomOffset = 3f;
			}
			else
			{
			multiplier = 10f;
			randomOffset = 2f;
			}
		}
	}
}