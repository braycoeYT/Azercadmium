using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs
{
	public class AzercadmiumGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool xenicAcid;
		public bool slimyOoze;
		public bool shroomed;
		public static int dirtballBoss = -1;
		public static int droneBoss = -1;
		public static int titanBoss = -1;
		public override void ResetEffects(NPC npc) {
			xenicAcid = false;
			slimyOoze = false;
			shroomed = false;
		}
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
			if (player.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome && player.ZoneSkyHeight) {
				spawnRate = (int)((double)spawnRate * 0.25);
				maxSpawns = (int)((float)maxSpawns * 2f);
			}
			if (player.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome) {
				spawnRate = (int)((double)spawnRate * 0.5);
				maxSpawns = (int)((float)maxSpawns * 2f);
			}
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if (type == NPCID.ArmsDealer) {
				if (NPC.downedBoss2) {
					if (Main.hardMode || !Main.dayTime) {
						shop.item[nextSlot].SetDefaults(ItemType<Items.Crimson.BloodiedArrow>());
						nextSlot++;
					}
				}
			}
			if (type == NPCID.Dryad) {
				shop.item[nextSlot].SetDefaults(ItemID.Seed);
				shop.item[nextSlot].shopCustomPrice = 3;
				nextSlot++;
			}
			if (type == NPCID.WitchDoctor) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("Vineshot"));
				shop.item[nextSlot].shopCustomPrice = 8;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.PoisonDart);
				shop.item[nextSlot].shopCustomPrice = 10;
				nextSlot++;
			}
			if (type == NPCID.Cyborg) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("Batsaber"));
				shop.item[nextSlot].shopCustomPrice = Item.buyPrice(1, 0, 0, 0);
				nextSlot++;
			}
			/*if ((type == ModContent.NPCType<Engineer>() || type == NPCID.GoblinTinkerer) && AzercadmiumWorld.devastation) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<DevastatedRemote>());
				shop.item[nextSlot].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
				nextSlot++;
			}*/
		}
		public override void SetDefaults(NPC npc) {
			if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer || npc.type == NPCID.TheDestroyerBody || npc.type == NPCID.TheDestroyerTail || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight || npc.type == NPCID.GolemHead || npc.type == NPCID.GolemHeadFree || npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore || npc.type == NPCID.MoonLordFreeEye || npc.type == NPCID.MoonLordHand || npc.type == NPCID.MoonLordHead) {
				npc.buffImmune[mod.BuffType("Sick")] = true;
			}
			if (npc.boss == false)
				npc.buffImmune[mod.BuffType("LoberaSoulslash")] = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (xenicAcid) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 50;
				if (damage < 25) {
					damage = 25;
				}
			}
			if (slimyOoze) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 4;
				if (damage < 1) {
					damage = 1;
				}
			}
			if (shroomed) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
				if (damage < 1) {
					damage = 1;
				}
				Lighting.AddLight(npc.Center, new Vector3(0.63f, 0.69f, 2.39f));
			}
		}
		public override void DrawEffects(NPC npc, ref Color drawColor) {
			if (xenicAcid) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 107, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
			if (slimyOoze) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("SlimyOozeDust"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
			if (shroomed) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 17, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
		}
		int Timer;
		bool prevNoGrav;
		public override void AI(NPC npc) {
			if (Timer == 0)
				prevNoGrav = npc.noGravity;
			if (GetInstance<AzercadmiumConfig>().nebulaAttack && npc.type == NPCID.LunarTowerNebula) {
				Timer++;
				if ((Main.expertMode == true && Timer % 300 == 0) || (!Main.expertMode && Timer % 360 == 0))
					Projectile.NewProjectile(npc.Center, new Vector2(Main.rand.NextFloat(-2, 3), -20), ProjectileID.NebulaSphere, 37, 1f);
			}
			int projectileCount;
			for (projectileCount = 0; projectileCount < Main.maxProjectiles; projectileCount++) {
				if (Main.projectile[projectileCount].active && Main.projectile[projectileCount].type == ProjectileType<Projectiles.Titan.TitansEnergizer>()) {
					if (Vector2.Distance(npc.Center, Main.projectile[projectileCount].Center) < 120 && !npc.boss && !npc.townNPC && npc.type != NPCID.TargetDummy) {
						npc.noGravity = true;
						if (npc.Center.X > Main.projectile[projectileCount].Center.X && npc.velocity.X > -15)
							npc.velocity.X -= 3;
						if (npc.Center.X < Main.projectile[projectileCount].Center.X && npc.velocity.X < 15)
							npc.velocity.X += 3;
						if (npc.Center.Y > Main.projectile[projectileCount].Center.Y && npc.velocity.Y > -15)
							npc.velocity.Y -= 3;
						if (npc.Center.Y < Main.projectile[projectileCount].Center.Y && npc.velocity.Y < 15)
							npc.velocity.Y += 3;
					}
					else npc.noGravity = prevNoGrav;
				}
				else npc.noGravity = prevNoGrav;
			}
		}
		public override void NPCLoot(NPC npc) {
			if (TAZWorld.emberGladesTileCount > 140 && Main.hardMode && NPC.downedMechBossAny)
				if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
					if (Main.rand.NextFloat() < .005f)
						if (npc.life > 5 && npc.friendly == false && npc.boss == false && npc.type != NPCID.BlueSlime)
							Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Ember.HellKey>());
			/*if (AzercadmiumWorld.microbiomeTiles > 140 && Main.hardMode) {
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight) {
					if (Main.expertMode) {
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .33f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
					else {
						if (npc.type != NPCID.BlueSlime && npc.type != NPCID.SlimeSpiked)
							if (Main.rand.NextFloat() < .2f)
								Item.NewItem(npc.getRect(), ItemID.SoulofNight);
					}
				}
			}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<AzercadmiumPlayer>().mineralExpert) {
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticSoul"));
			}
			if (npc.lifeMax > 1 && npc.damage > 0 && npc.value > 0 && Main.rand.NextFloat() < .05f) {
				int month = DateTime.Now.Month;
				int day = DateTime.Now.Day;
				if (month == 12 && day > 14)
					Item.NewItem(npc.getRect(), mod.ItemType("RedPresent"));
			}*/
			if (NPC.downedPlantBoss && (npc.type == NPCID.IceSlime || npc.type == NPCID.SandSlime || npc.type == NPCID.JungleSlime || npc.type == NPCID.SpikedJungleSlime || npc.type == NPCID.SpikedIceSlime || npc.type == NPCID.LavaSlime || npc.type == NPCID.DungeonSlime || npc.type == NPCID.UmbrellaSlime)) {
				Item.NewItem(npc.getRect(), mod.ItemType("ElementalGoop"), Main.rand.Next(1, 4));
			}
			if (NPC.downedPlantBoss && (npc.type == NPCID.RainbowSlime || npc.type == NPCID.Pinky)) {
				Item.NewItem(npc.getRect(), mod.ItemType("ElementalGoop"), Main.rand.Next(20, 51));
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && Main.hardMode && Main.rand.NextFloat() < .2f) {
				Item.NewItem(npc.getRect(), mod.ItemType("Electrolight"));
			}
			if ((Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHoly || Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight) && Main.hardMode && Main.rand.NextFloat() < .005f) {
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Hallow.SunProtection>());
			}
			if (npc.type == NPCID.Derpling || npc.type == NPCID.GiantTortoise || npc.type == NPCID.GiantFlyingFox || npc.type == NPCID.AngryTrapper || npc.type == NPCID.Arapaima) {
				if (Main.rand.NextFloat() < .01f)
					Item.NewItem(npc.getRect(), mod.ItemType("VenomousPill"));
			}
			if (npc.type == NPCID.JungleBat || npc.type == NPCID.CaveBat || npc.type == NPCID.IceBat) {
				if (Main.rand.NextFloat() < .005f)
					Item.NewItem(npc.getRect(), mod.ItemType("BatBasher"));
			}
			if (npc.type == NPCID.EyeofCthulhu) {
				//if (Main.rand.NextFloat() < .25f)
				//Item.NewItem(npc.getRect(), mod.ItemType("OpticBlowpipe"));
				if (WorldGen.crimson)
				Item.NewItem(npc.getRect(), ItemType<Items.Crimson.BloodiedArrow>(), Main.rand.Next(20, 51));
				//Item.NewItem(npc.getRect(), ItemType<Items.Microbiome.TwistedMembraneOre>(), Main.rand.Next(30, 88));
			}
			if (npc.type == NPCID.KingSlime) {
				Item.NewItem(npc.getRect(), ItemType<Items.Slime.SlimyCore>(), Main.rand.Next(8, 12));
			}
			if (npc.type == NPCID.WallofFlesh) {
				if (Main.rand.NextFloat() < .5f)
					if (Main.rand.Next(2) == 0)
						Item.NewItem(npc.getRect(), ItemType<Items.Other.Blowpipes.FamiliarFoamDartPistol>());
					else
						Item.NewItem(npc.getRect(), ItemType<Items.Underworld.HungeringJavelin>());
			}
			if (npc.type == NPCID.Plantera) {
				Item.NewItem(npc.getRect(), ItemType<Items.Plantera.PlanteraTooth>(), Main.rand.Next(1, 5));
				if (Main.rand.Next(3) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Plantera.BloomofLife>());
			}
			if (npc.type == NPCID.Golem) {
				if (Main.rand.NextFloat() < .2f)
					Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Lihzahrd.LihzahrdLance>());
			}
			if (npc.type == NPCID.DukeFishron) {
				if (Main.rand.NextFloat() < .15f)
					Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Duke.OceanPiercer>());
			}
			if (npc.type == NPCID.MossHornet) {
				if (Main.rand.Next(2) == 0)
					Item.NewItem(npc.getRect(), ItemID.Stinger, Main.rand.Next(1, 4));
				if (Main.rand.Next(10) == 0)
					Item.NewItem(npc.getRect(), ItemID.Vine);
			}
			if (npc.type == NPCID.WallofFlesh) {
				if (Main.rand.Next(2) == 0)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshBlowpipe"));
				else
					Item.NewItem(npc.getRect(), mod.ItemType("HungeringJavelance"), 4);
			}
			if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall) {
				if (Main.rand.NextFloat() < .12f)
					Item.NewItem(npc.getRect(), mod.ItemType("BloodySpiderLeg"));
			}
			if (npc.type == NPCID.SeekerHead) {
				Item.NewItem(npc.getRect(), ItemID.RottenChunk, Main.rand.Next(1, 3));
				Item.NewItem(npc.getRect(), ItemID.WormTooth, Main.rand.Next(3, 9));
			}
			if (npc.type == NPCID.Necromancer || npc.type == NPCID.NecromancerArmored || npc.type == NPCID.DungeonSpirit) {
				if (Main.rand.NextFloat() < .005f)
					Item.NewItem(npc.getRect(), mod.ItemType("GhastlySwinger"));
			}
			if (npc.type == NPCID.GoblinSorcerer) {
				if (Main.rand.Next(20) == 0)
					Item.NewItem(npc.getRect(), ItemType<Items.Goblins.ChaosCaster>());
			}
			if (npc.type == NPCID.BoneSerpentHead) {
				if (NPC.downedBoss3)
				Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(3) + 1);
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && npc.type == NPCID.Harpy && Main.rand.Next(75) == 0 && NPC.downedBoss2) {
				Item.NewItem(npc.getRect(), ItemType<Items.Sky.GlazingStar>());
			}
			/*//blowpipes:
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("FrostBlowpipe")))
				if (npc.type == NPCID.IceSlime || npc.type == NPCID.SpikedIceSlime || npc.type == mod.NPCType("IcyDiscus")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("IcySeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("WoodenBlowpipe")))
				if (npc.type == -3 || npc.type == NPCID.BlueSlime) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("PinkyBlowpipe")))
				if (npc.type == -4) {
					Item.NewItem(npc.getRect(), mod.ItemType("PinkySeedshot"), Main.rand.Next(30, 51));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("SlimyBlowpipe")))
				if (npc.type == NPCID.BlueSlime || npc.type == -7 || npc.type == NPCID.SlimeSpiked) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("SlimySeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("DirtyBlowpipe")))
				if (npc.type == mod.NPCType("DirtSlime")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("EaterOfSeeds")))
				if (npc.type == NPCID.EaterofSouls || npc.type == NPCID.LittleEater || npc.type == NPCID.BigEater || npc.type == NPCID.DevourerHead || npc.type == mod.NPCType("CorruptDiscus")) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("CorruptSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("BloodyBlowpipe")))
				if (npc.type == NPCID.BloodCrawler || npc.type == NPCID.BloodCrawlerWall || npc.type == mod.NPCType("VeinTunnelerHead") || npc.type == NPCID.FaceMonster || npc.type == NPCID.Crimera || npc.type == NPCID.LittleCrimera || npc.type == NPCID.BigCrimera) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("CrimtaneSeedshot"), Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("OpticBlowpipe")))
				if (npc.type == NPCID.CataractEye || npc.type == NPCID.CataractEye2 || npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship || npc.type == NPCID.DialatedEye || npc.type == NPCID.DialatedEye2 || npc.type == NPCID.GreenEye || npc.type == NPCID.GreenEye2 || npc.type == NPCID.PurpleEye || npc.type == NPCID.PurpleEye2 || npc.type == NPCID.SleepyEye || npc.type == NPCID.SleepyEye2) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), ItemID.Seed, Main.rand.Next(1, 3));
				}
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].HasItem(mod.ItemType("FleshBlowtube")))
				if (npc.type == NPCID.Demon || npc.type == NPCID.FireImp || npc.type == NPCID.LavaSlime) {
					if (Main.rand.NextFloat() < .5f)
					Item.NewItem(npc.getRect(), mod.ItemType("FleshSeedshot"), Main.rand.Next(1, 3));
				}*/
		}
		public override void SetupTravelShop(int[] shop, ref int nextSlot) {
			if (Main.rand.Next(0, 5) == 0) {
                shop[nextSlot] = mod.ItemType("IronfistMedal");
                nextSlot++;
            }
			if (Main.hardMode && Main.rand.NextFloat() < .2f) {
				shop[nextSlot] = ItemType<Items.Other.Flails.StickyHand>();
                nextSlot++;
			}
		}
	}
}