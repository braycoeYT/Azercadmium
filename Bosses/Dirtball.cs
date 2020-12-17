using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Bosses
{
	[AutoloadBossHead]
	public class Dirtball : ModNPC
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dirtball");
			Main.npcFrameCount[npc.type] = 7;
		}
        public override void SetDefaults() {
			npc.width = 150;
			npc.height = 144;
			npc.damage = 10;
			npc.defense = 1;
			npc.lifeMax = 590;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath9;
			npc.value = Item.buyPrice(0, 0, 75, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[mod.BuffType("Sick")] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.lavaImmune = true;
			animationType = NPCID.Drippler;
			if (Main.expertMode)
				npc.scale = 1.75f;
			else
				npc.scale = 1.5f;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 890;
            npc.damage = 23;
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.scale > 0.5f)
				npc.life = npc.lifeMax;
			npc.scale -= 0.01f;
			if (damage > 10)
			npc.scale -= 0.01f;
			if (damage > 20)
			npc.scale -= 0.01f;
			if (damage > 40)
			npc.scale -= 0.01f;
			if (damage > 60)
			npc.scale -= 0.01f;
			if (damage > 100)
			npc.scale -= 0.01f;
			if (damage > 160)
			npc.scale -= 0.01f;
			if (npc.scale < 0.5f)
				npc.scale = 0.5f;
			if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Dirtball.DirtyDiscus>(), 0, npc.whoAmI);
			if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Dirtball.DirtyDiscus>(), 0, npc.whoAmI);
			for (int i = 0; i < 10; i++) {
				int dustType = 0;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int Timer;
		int animationTimer;
		int flee = 0;
		int attack = 0;
		int attackMax = 0;
		int attackNum = 0;
		bool attackDone = true;
		bool chat1 = !AzercadmiumWorld.downedDirtball;
		bool chat2 = !AzercadmiumWorld.downedDirtball;
		Vector2 targetPlayer;
		public override void AI() {
			Timer++;
			if (npc.scale > 0.5f)
				npc.life = npc.lifeMax;
			npc.TargetClosest(true);
			npc.width = (int)(110 * npc.scale);
			npc.height = (int)(138 * npc.scale);
			if (chat1) {
				Color messageColor = Color.SaddleBrown;
				string chat = "Dirtball's gigantic mud shell renders it undamageable! There must be a way to shrink its size...";
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
			if (chat2 && Timer > 300 && ((Main.expertMode && npc.scale < 1.7f) || (!Main.expertMode && npc.scale < 1.45f)))
			{
				Color messageColor = Color.SaddleBrown;
				string chat = "It seems that hitting Dirtball shakes some of its mud off.";
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
			npc.velocity = Vector2.Normalize(npc.Center - Main.player[npc.target].Center) * (float)(-3.75f + npc.scale);
			
			npc.TargetClosest(true);
			targetPlayer = Main.player[npc.target].Center;
			
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
            }
			if (Main.expertMode)
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = 3;
					attackNum = 0;
				}
				
				if (attack == 1)
				{
					if (Timer % 120 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 3, mod.ProjectileType("DirtBall"), 4, 10, Main.myPlayer);
						if (attackMax < attackNum + 1)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
				if (attack == 2)
				{
					if (Timer % 24 == 0)
					{
						Projectile.NewProjectile(targetPlayer.X + Main.rand.Next(-600, 601), targetPlayer.Y - 500, 0, 6f, mod.ProjectileType("DirtTile"), 7, 1f, Main.myPlayer);
						if (attackMax * 6 < attackNum)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
			}
			else
			{
				if (attackDone == true)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = 3;
					attackNum = 0;
				}
				
				if (attack == 1)
				{
					if (Timer % 150 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPlayer) * 3, mod.ProjectileType("DirtBall"), 3, 10, Main.myPlayer);
						if (attackMax < attackNum + 1)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
				if (attack == 2)
				{
					if (Timer % 30 == 0)
					{
						Projectile.NewProjectile(targetPlayer.X + Main.rand.Next(-600, 601), targetPlayer.Y - 500, 0, 5.5f, mod.ProjectileType("DirtTile"), 6, 1f, Main.myPlayer);
						if (attackMax * 4 < attackNum)
						{
							attackDone = true;
						}
						attackNum += 1;
					}
				}
			}
			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 164;
		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("DirtballBag"));
			}
		    else
			{
			int ran = Main.rand.Next(1, 7);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("BrokenDirtballCopperShortsword"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("DirtyDiscus"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("DirtyBlowpipw"));
			if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("DirtyPistol"));
			if (ran == 5) Item.NewItem(npc.getRect(), mod.ItemType("DirtYoyo"));
			if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("DirtBow"));
			
			ran = Main.rand.Next(1, 4);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("EarthmightHelm"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("EarthmightBreastplate"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("EarthmightLeggings"));

			ran = Main.rand.Next(1, 4);
			if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("OvergrownHilt"));
			if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("OvergrownHandgunFragment"));
			if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("OvergrownElectricalComponent"));
			
			Item.NewItem(npc.getRect(), ItemID.CopperBar, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.DirtBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.MudBlock, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Gel, 1 + Main.rand.Next(5));
			Item.NewItem(npc.getRect(), ItemID.Lens, 1 + Main.rand.Next(1));
			
			if (Main.rand.NextFloat() < .5f)
			Item.NewItem(npc.getRect(), mod.ItemType("DirtyMedal"));

			if (Main.rand.NextFloat() < .25f)
			Item.NewItem(npc.getRect(), ItemID.DirtRod);

			if (Main.rand.NextFloat() < .12f)
			Item.NewItem(npc.getRect(), mod.ItemType("CreepyBlob"));
			}
			
			AzercadmiumWorld.downedDirtball = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!AzercadmiumWorld.downedDirtball && Main.dayTime)
			    return 0.00015f;
			return 0f;
        }
	}
}