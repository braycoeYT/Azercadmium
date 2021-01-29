using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Empress
{
	[AutoloadBossHead]
	public class EmpressSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Empress Slime");
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults()
		{
			npc.width = 158;
			npc.height = 172;
			npc.damage = 61;
			npc.defense = 41;
			npc.lifeMax = 35000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 16, 0, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = 1; //51 original
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.netAlways = true;
			Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			if (azercadmiumMusic != null) 
				music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/ImitationalAcrophobia");
			else 
				music = MusicID.Boss2;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Poisoned] = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 48000 + numPlayers * 8000;
			npc.damage = 120;
        }
		public override void OnHitPlayer(Player player, int damage, bool crit) {
			if (Main.rand.NextBool(2))
				player.AddBuff(BuffID.Venom, 200, true);
		}
		public override void HitEffect(int hitDirection, double damage)
        {
			if (npc.lifeMax / 2 < npc.life)
			{
				if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Empress.RoyalMotherSlime>(), 0, npc.whoAmI);
			}
			else
			{
				if (Main.rand.Next(30) == 0)
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Empress.RoyalSlimer>(), 0, npc.whoAmI);
			}

			for (int i = 0; i < 10; i++)
			{
				int dustType = 266;
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
		int jumpMode = 0;
		int jumpTimer = 0;
		int jumpTimer2 = 0;
		//int jumpTimer3 = 0;
		int jumpDir;
		bool attackDone = true;
		Vector2 targetPos;

		public override void AI()
		{
			npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Timer++;

			//start of jump ai
			if (jumpMode == 0)
			{
				npc.noGravity = false;
				npc.noTileCollide = false;
				if (npc.lifeMax / 2 > npc.life)
				jumpTimer2 = 7;
				else
				jumpTimer2 = 6;
				if (Main.expertMode)
				jumpTimer2 += 2;
				jumpTimer++;
				if (jumpTimer > 240)
					jumpMode = 1;
				//jumpTimer3 = 0;
			}
			if (jumpMode == 1)
			{
				npc.noGravity = false;
				npc.noTileCollide = false;
				if (target.position.X > npc.position.X)
				jumpDir = 0;
				else
				jumpDir = 1;
				jumpMode = 2;
			}
			if (jumpMode == 2)
			{
				jumpTimer++;
				if (jumpTimer % 30 == 0)
				jumpTimer2 += 1;
				npc.noGravity = true;
				npc.noTileCollide = true;
				if (jumpDir == 0)
					npc.velocity.X = jumpTimer2;
				else
					npc.velocity.X = jumpTimer2 * -1;
				if (npc.position.Y < target.position.Y - 150 && Math.Abs(npc.position.X - target.position.X) < 10)
				jumpMode = 3;
				if (npc.position.X > target.position.X)
					jumpDir = 1;
				else
					jumpDir = 0;
				/*if (jumpDir == 0)
				{
					npc.velocity.X = jumpTimer2;
					if (npc.position.X > target.position.X - 5 && npc.position.Y < target.position.Y)
					jumpMode = 3;
				}
				if (jumpDir == 1)
				{
					npc.velocity.X = jumpTimer2 * -1;
					if (npc.position.X < target.position.X + 5 && npc.position.Y < target.position.Y)
					jumpMode = 3;
				}*/
				if (npc.position.Y < target.position.Y - 400)
					npc.position.Y = target.position.Y - 400;
				if (npc.lifeMax / 2 > npc.life && Main.expertMode)
				npc.velocity.Y = -10;
				else if (npc.lifeMax / 2 > npc.life || Main.expertMode)
				npc.velocity.Y = -8;
				else
				npc.velocity.Y = -7;
			}
			if (jumpMode == 3)
			{
				npc.noGravity = false;
				if (npc.position.Y < target.position.Y)
					npc.noTileCollide = true;
				else
					npc.noTileCollide = false;
				npc.velocity.X = 0;
				npc.velocity.Y = 8;
				//jumpTimer3++;
				if (npc.collideY || npc.position.Y > target.position.Y + 600)
				jumpMode = 4;
			}
			if (jumpMode == 4)
			{
				jumpDir = 0;
				jumpTimer = 0;
				jumpTimer2 = 0;
				//jumpTimer3 = 0;
				jumpMode = 0;
				Main.PlaySound(SoundID.Item62);
				if (Main.expertMode)
				{
					for (float rotation = 0; rotation < 360;)
					{
						rotation += 30;
						Projectile.NewProjectile(npc.Center, new Vector2(0, 5).RotatedBy((Math.PI / 180) * rotation, default), mod.ProjectileType("EmpressSpike"), 35, 1f, Main.myPlayer);
					}
				}
			}
			//end of jump ai
			if (npc.lifeMax / 2 > npc.life)
			{
				if (Main.expertMode)
				{
					int healSpeed = (int)(npc.life / 400);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
				else
				{
					int healSpeed = (int)(npc.life / 500);
					if (healSpeed != 0)
					{
						if (Timer % healSpeed == 0)
						{
							npc.life += 1;
							if (npc.life > npc.lifeMax)
								npc.life = npc.lifeMax;
						}
					}
					else
						npc.life += 1;
				}
			}
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
			
			
			targetPos = Main.player[npc.target].Center;

			if (Main.expertMode)
			{
				if (Timer % 400 == 0)
				{
					float numberNPC = Main.rand.Next(3, 6);
					for (int i = 0; i < numberNPC; i++)
					{
						Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
					}
				}
			}
			else
			{
				if (Timer % 520 == 0)
				{
					float numberNPC = Main.rand.Next(2, 5);
					for (int i = 0; i < numberNPC; i++)
					{
						Main.PlaySound(SoundID.NPCHit8.WithPitchVariance(2f));
						NPC.NewNPC((int)npc.position.X + Main.rand.Next(-50, 50), (int)npc.position.Y + Main.rand.Next(-50, 50), mod.NPCType("SlimeLarva"));
					}
				}
			}
			if (Main.expertMode)
			{
				if (attackDone)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = Main.rand.Next(3, 7);
					attackNum = 0;
				}
				if (npc.lifeMax / 2 < npc.life)
				{
					if (attack == 1 && Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("EmpressGlob"), 24, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 120 == 0)
					{
						float numberProjectiles = Main.rand.Next(5, 10);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 32, 2, Main.myPlayer);
							if (attackMax < attackNum)
								attackDone = true;
							attackNum += 1;
						}
					}
				}
				else
				{
					if (attack == 1 && Timer % 50 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 5, mod.ProjectileType("EmpressGlob"), 25, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 100 == 0)
					{
						float numberProjectiles = Main.rand.Next(6, 11);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(1, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 33, 2, Main.myPlayer);
							if (attackMax < attackNum)
								attackDone = true;
							attackNum += 1;
						}
					}
				}
			}
			else
			{
				if (attackDone)
				{
					attack = Main.rand.Next(1, 3);
					attackDone = false;
					attackMax = Main.rand.Next(3, 6);
					attackNum = 0;
				}
				if (npc.lifeMax / 2 < npc.life)
				{
					if (attack == 1 && Timer % 70 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 3, mod.ProjectileType("EmpressGlob"), 29, 10, Main.myPlayer);
						if (attackMax < attackNum)
						attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 140 == 0)
					{
						float numberProjectiles = Main.rand.Next(5, 10);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 38, 2, Main.myPlayer);
							if (attackMax < attackNum)
							attackDone = true;
							attackNum += 1;
						}
					}
				}
				else
				{
					if (attack == 1 && Timer % 60 == 0)
					{
						Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * 4, mod.ProjectileType("EmpressGlob"), 29, 10, Main.myPlayer);
						if (attackMax < attackNum)
							attackDone = true;
						attackNum += 1;
					}
					if (attack == 2 && Timer % 120 == 0)
					{
						float numberProjectiles = Main.rand.Next(6, 11);
						for (int i = 0; i < numberProjectiles; i++)
						{
							Projectile.NewProjectile(npc.Center, new Vector2(0, 8).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("EmpressOrb"), 38, 2, Main.myPlayer);
							if (attackMax < attackNum)
								attackDone = true;
							attackNum += 1;
						}
					}
				}
			}
			if (Timer % 4 == 0)
				animationTimer++;
			if (animationTimer > 5)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 178;
		}
		public override void NPCLoot() {
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), mod.ItemType("EmpressBag"));
			else {
				int ran = Main.rand.Next(1, 7);
				if (ran == 1) Item.NewItem(npc.getRect(), mod.ItemType("EmpressYolk"));
				if (ran == 2) Item.NewItem(npc.getRect(), mod.ItemType("EmpressBleeders"));
				if (ran == 3) Item.NewItem(npc.getRect(), mod.ItemType("Egg"));
				if (ran == 4) Item.NewItem(npc.getRect(), mod.ItemType("EmpressShuriken"));
				if (ran == 5) Item.NewItem(npc.getRect(), mod.ItemType("Eggspray"));
				if (ran == 6) Item.NewItem(npc.getRect(), mod.ItemType("EmpressTears"));
				Item.NewItem(npc.getRect(), mod.ItemType("EmpressShard"), Main.rand.Next(9, 15));
				Item.NewItem(npc.getRect(), mod.ItemType("ElementalGel"), Main.rand.Next(30, 61));
			}
			AzercadmiumWorld.downedEmpress = true;
		}
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.GreaterHealingPotion;
		}
	}
}