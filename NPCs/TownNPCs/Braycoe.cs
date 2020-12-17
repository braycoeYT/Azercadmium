using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			if (!impression) {
				chat.Add("No, I will not turn into a green slime for you.");
				chat.Add("I can turn into any slime, name one and I could do it.");
				chat.Add("You won the lottery! No, not really.", 0.001);
				chat.Add("Can my house be a bit bigger? Oh, never mind...");
				chat.Add("Oh, you want me to defend you now. Do you want me to bake cookies too?");
				chat.Add("Destroy the dark power of this world!");
				chat.Add("Get stronger and I will sell stronger items and reveal more of my power.");
				chat.Add("Lemonade Tea is an excellent drink!");
				chat.Add("If you think about it, blackberries are just very small grapes.");
				chat.Add("Have you happened to see any Azercadmium Ore anywhere? No?");
				chat.Add("Have you ever heard of a Starlite Crystal..? Never mind.");
				chat.Add("Yes, being a slime is fun.");
				chat.Add("Have you seen my slimebender anywhere?");
				if (AzercadmiumWorld.devastation)
					chat.Add("Devastation mode is very WIP, I hope you like it so far.");
				if (Main.raining)
					chat.Add("Hey, since I generate slime a lot faster while its raining, I'll sell gel to you for a discount price! Buy some now!", 2);
			    if (NPC.downedSlimeKing == true)
					chat.Add("That King Slime is such a loser, thanks for breaking him into hundreds of normal size slimes.");
				if (Main.hardMode && !NPC.downedMechBossAny)
					chat.Add("Early hardmode getting the best of you?", 2);
				if (NPC.downedMoonlord)
					chat.Add("You defeated the Moon Lord? It appears you have broken the Moon Seal, and new things will happen in your world. Of course, that is for a future update.", 1.5);
			}
			else {
				chat.Add("Braycoe: I am Braycoe, the slime shapeshifter and owner of Azercadmium.");
				chat.Add("Forest: A nice lovely place full of lovely creatures, also known as slimes.");
				chat.Add("Corruption: A nasty place with even nastier enemies.");
				chat.Add("Crimson: If you love blood and gore, the Crimson is the place for you.");
				chat.Add("Snow: A beautiful wonderland that is sadly extremely ignored and weak against other biomes.");
				chat.Add("Desert: A dry, dry, land with a giant hole filled with peculiar bugs.");
				chat.Add("Jungle: A wet forest filled with life, and very annoying life at that.");
				chat.Add("Dungeon: I guess it is a spooky place, I don't have much to say about it.");
				chat.Add("Ocean: A pretty empty place, unless you have certain mods enabled. Also, it's a pretty calm place too.");
				chat.Add("Underworld: I like to get out of that hecking place as soon as possible.");
				if (AzercadmiumWorld.downedDirtball) chat.Add("Dirtball: The most glorious and well known Azercadmium boss. I didn't know we could get so attached to a ball of dirt.");
				if (NPC.downedSlimeKing) chat.Add("King Slime: A gigaslime that I don't really like since he claims to be a king over some of us slimes, but has no political power whatsoever.");
				if (NPC.downedBoss1) chat.Add("Eye of Cthulhu: A certain someone's giant organ which for some reason ignores gravity, and loves to jumpscare terrarians.");
				if (AzercadmiumWorld.downedDiscus) chat.Add("Ancient Desert Discus: An ancient machine which had lead a failed expedition of Terraria.");
			}
			return chat;
		}
		int Timer;
		public override void AI()
		{
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
                    button = "Impressions";
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
					WeightedRandom<string> impressions = new WeightedRandom<string>();
					impressions.Add("Braycoe: I am Braycoe, the slime shapeshifter and owner of Azercadmium.");
					impressions.Add("Forest: A nice lovely place full of lovely creatures, also known as slimes.");
					impressions.Add("Corruption: A nasty place with even nastier enemies.");
					impressions.Add("Crimson: If you love blood and gore, the Crimson is the place for you.");
					impressions.Add("Snow: A beautiful wonderland that is extremely fragile.");
					impressions.Add("Desert: A dry, dry, land with a giant hole filled with peculiar bugs.");
					impressions.Add("Jungle: A wet forest filled with life, and very annoying life at that.");
					impressions.Add("Dungeon: I guess it is a spooky place, I don't have much to say about it.");
					impressions.Add("Ocean: A pretty empty place, unless you have certain mods enabled. Also, it's a pretty calm place too.");
					impressions.Add("Underworld: I like to get out of that hecking place as soon as possible.");
					if (AzercadmiumWorld.downedDirtball) impressions.Add("Dirtball: The most glorious and well known Azercadmium boss. I didn't know we could get so attached to a ball of dirt.");
					if (NPC.downedSlimeKing) impressions.Add("King Slime: A gigaslime that I don't really like since he claims to be a king over some of us slimes, but has no political power whatsoever.");
					if (NPC.downedBoss1) impressions.Add("Eye of Cthulhu: A certain someone's giant organ which for some reason ignores gravity, and loves to jumpscare terrarians.");
					if (AzercadmiumWorld.downedDiscus) impressions.Add("Ancient Desert Discus: An ancient machine which had lead a failed expedition of Terraria.");
					if (NPC.downedBoss2 && !WorldGen.crimson) impressions.Add("Eater of Worlds: The original worm boss. Also, he is similar to a hydra, don't cut too many body segments out.");
					if (NPC.downedBoss2 && WorldGen.crimson) impressions.Add("Brain of Cthulhu: Yet another certain someone's giant floating organ. Luckily the creepers it summons don't make you go 'Aw man'.");
					if (NPC.downedBoss3) impressions.Add("Skeletron: A giant floating head that must have drank a lot of milk. He likes to torture elderly people.");
					if (Main.hardMode) impressions.Add("Wall of Flesh: I do wonder how many creatures it took to make sometimes. Also, a very scary beast that traps you in that unpleasant biome.");
					if (Main.hardMode) impressions.Add("Hallow: A very sparkly and wonderous world, which will consume you if you are not careful!");
					if (Main.hardMode) impressions.Add("Souls: I see much farming in your future, at least they look pretty.");
					if (NPC.downedMechBoss1) impressions.Add("The Destroyer: Big worm, V2.0... He is relatively weak since his probes drop hearts.");
					if (NPC.downedMechBoss2) impressions.Add("The Twins: Twice the fun of the original boss, now with lasers and green fire!");
					if (NPC.downedMechBoss3) impressions.Add("Skeletron Prime: A teeth grinding killing machine. Maybe it is just stressed?");
					if (AzercadmiumWorld.downedScavenger) impressions.Add("Computer Virus: Many rumors of the plague's origin have been going around recently. Some people believe that it existed since the beginning of time.");
					if (NPC.downedPlantBoss) impressions.Add("Plantera: A very angry plant because you killed and ate its brethren. Maybe I'm thinking too hard on this one?");
					if (AzercadmiumWorld.downedEmpress) impressions.Add("Empress Slime: One of the most powerful slimes, and puts King Slime to shame. A truly worthy leader of the slimes!");
					if (NPC.downedGolemBoss) impressions.Add("Golem: An extraordinarily weak machine, and an ugly one at that. What were they thinking?");
					if (NPC.downedAncientCultist) impressions.Add("Lunatic Cultist: I've always wondered... Lunatic because he is related to the stars, or lunatic because he is mentally insane? Probably both.");
					if (NPC.downedTowerSolar) impressions.Add("Solar Pillar: A very high temperature pillar, and the hardest one at that. Not the crawltipedes!");
					if (NPC.downedTowerVortex) impressions.Add("Vortex Pillar: Probably the zappiest pillar of them all. Watch out for those storm divers who want to distort you.");
					if (NPC.downedTowerNebula) impressions.Add("Nebula Pillar: I like the colors, though the enemies are kind of annoying. Obstruction!");
					if (NPC.downedTowerStardust) impressions.Add("Stardust Pillar: The easiest pillar of them all, just farm the stardust cells. Also they have a pretty nice color theme.");
					if (NPC.downedMoonlord) impressions.Add("Moon Lord: The man of the moon himself. Some cosmic beings had created a moon seal that caused some creatures to be trapped in time until the Moon Lord was revived and killed.");
					Main.npcChatText = impressions;
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
			shop.item[nextSlot].SetDefaults(mod.ItemType("SlimySeedshot"));
			shop.item[nextSlot].shopCustomPrice = 5;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("DeliciousGelatin"));
			shop.item[nextSlot].shopCustomPrice = 2000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("CheckeredFlag"));
			shop.item[nextSlot].shopCustomPrice = 250000;
			nextSlot++;
			if (Main.hardMode == true)
			{
				shop.item[nextSlot].SetDefaults(ItemType<Items.Braycoe.LemonadeTea>());
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