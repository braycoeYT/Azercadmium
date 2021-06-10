using Azercadmium.Aaa;
using Azercadmium.Projectiles.Devastation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium
{
	public class AzercadmiumPlayer : ModPlayer
	{	
		
		public bool ZoneOblivion;
		public bool ZoneMicrobiome;
		public bool MarblePet;
		public bool UpgradeMeatball;
		public bool SlimyCore;
		public bool BraycoeSlimePet;
		public bool CyanixLong;
		public bool gemstoneSpikes;
		public bool gemstoneManaBullet;
		public bool gemstoneRain;
		public bool empressSpikes;
		public bool darkstarFall;
		public bool hurtHeal;
		public bool redJavelance;
		public bool electricField;
		public bool eyeCandy;
		public bool hyperCell;
		public bool magentiteBonus;
		public bool bloodVial;
		public bool cyanixShort;
		public bool cytocellPet;
		public bool mineralExpert;
		public bool xenicAcid;
		public bool xenicExpert;
		public bool gemstoneMelee;
		public bool gemstoneRanged;
		public bool gemstoneMagic;
		public bool gemstoneSummon;
		public bool trueMelee15;
		public bool empressExpert;
		public bool meteorMelee;
		public bool stealthPotion;
		public bool slimyOoze;
		public bool dirtboi;
		public bool outofBreath;
		public bool shroomed;
		public bool webdriver;
		public bool artifactofFire;
		public bool KinoiteRover;
		public bool gooeySetBonus;
		public bool extraNeonSlimyCore;
		public bool titanFragment;
		int numberShot = 0;
		public int upgradeHearts;
		public int upgradeStars;
		public int playerTimer;
		public int healHurt;
		public int javelinPenetration;
		public int hurtCounter;
		public override void ResetEffects()
		{
			MarblePet = false;
			UpgradeMeatball = false;
			SlimyCore = false;
			BraycoeSlimePet = false;
			CyanixLong = false;
			gemstoneSpikes = false;
			gemstoneRanged = false;
			gemstoneManaBullet = false;
			gemstoneRain = false;
			empressSpikes = false;
			darkstarFall = false;
			hurtHeal = false;
			redJavelance = false;
			electricField = false;
			eyeCandy = false;
			hyperCell = false;
			magentiteBonus = false;
			bloodVial = false;
			cytocellPet = false;
			mineralExpert = false;
			xenicAcid = false;
			xenicExpert = false;
			gemstoneMelee = false;
			gemstoneMagic = false;
			gemstoneSummon = false;
			trueMelee15 = false;
			empressExpert = false;
			meteorMelee = false;
			stealthPotion = false;
			slimyOoze = false;
			dirtboi = false;
			outofBreath = false;
			shroomed = false;
			webdriver = false;
			artifactofFire = false;
			KinoiteRover = false;
			gooeySetBonus = false;
			extraNeonSlimyCore = false;
			titanFragment = false;
			player.statLifeMax2 += upgradeHearts * 25;
			player.statManaMax2 += upgradeStars * 50;
			healHurt = 0;
			javelinPenetration = 0;
		}
		public override void UpdateDead() {
			xenicAcid = false;
			slimyOoze = false;
			outofBreath = false;
			shroomed = false;
			hurtCounter = 0;
			playerTimer = 0;
		}
		int badRegenTimer;
		public override void UpdateBadLifeRegen() {
			badRegenTimer++;
			if (xenicAcid) {
				if (player.lifeRegen > 0 && !xenicExpert) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				if (!xenicExpert)
				if (mineralExpert)
				player.lifeRegen -= 12;
				else
				player.lifeRegen -= 16;

				if (xenicExpert && badRegenTimer % 10 == 0)
				{
					player.statLife += 1;
					player.HealEffect(1, true);
				}
			}
			if (slimyOoze) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 4;
			}
			if (outofBreath) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 12;
			}
			if (shroomed) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 8;
			}
			if (healHurt > 0) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 120 * healHurt;
			}
		}
		public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			if (xenicAcid) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 193, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.5f;
				b *= 0.1f;
				fullBright = true;
			}
			if (slimyOoze) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, mod.DustType("SlimyOozeDust"), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.5f;
				b *= 0.1f;
				fullBright = true;
			}
			if (shroomed) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 17, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.1f;
				g *= 0.1f;
				b *= 0.5f;
				fullBright = true;
			}
		}
		public override TagCompound Save()
		{
			return new TagCompound {
		{"upgradeHearts", upgradeHearts},
		{"upgradeStars", upgradeStars},
	};
		}
		public override void Load(TagCompound tag)
		{
			upgradeHearts = tag.GetInt("upgradeHearts");
			upgradeStars = tag.GetInt("upgradeStars");
		}
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
			Item item = new Item();
			item.SetDefaults(mod.ItemType("EyeoftheCosmos"));
			items.Add(item);
			/*item = new Item();
			item.SetDefaults(ItemID.Seed);
			item.stack = 500;
			items.Add(item);*/
		}
		public override void UpdateBiomes()
		{
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneSkyHeight)
			ZoneMicrobiome = AzercadmiumWorld.microbiomeTiles > 140;
			else
			ZoneMicrobiome = AzercadmiumWorld.microbiomeTiles > 200;
			if (ZoneMicrobiome)
			{
				//player.AddBuff(mod.BuffType(""), 5, true);
			}
		}
		public override void PreUpdate() {
			if (artifactofFire && player.velocity != new Vector2(0, 0) && Main.GameUpdateCount % 5 == 0) {
				Projectile.NewProjectile(player.Center, new Vector2(0, 0), ModContent.ProjectileType<FlameTrailEyeFriendly>(), 13, 0.5f, Main.myPlayer);
			}
		}
		public override bool CustomBiomesMatch(Player other) 
		{
			AzercadmiumPlayer modOther = other.GetModPlayer<AzercadmiumPlayer>();
			return ZoneMicrobiome == modOther.ZoneMicrobiome;
		}
		
		public override void CopyCustomBiomesTo(Player other)
		{
			AzercadmiumPlayer modOther = other.GetModPlayer<AzercadmiumPlayer>();
			modOther.ZoneMicrobiome = ZoneMicrobiome;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = ZoneMicrobiome;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			ZoneMicrobiome = flags[0];
		}

		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneMicrobiome)
			{
				return mod.GetTexture("MicrobiomeMapBackground");
			}
			return null;
		}
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if ((Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneDirtLayerHeight || Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].ZoneRockLayerHeight) && Main.rand.NextFloat() < .05f)
				caughtType = mod.ItemType("LabyrinthFish");
			if (Main.player[(int)Player.FindClosest(player.position, player.width, player.height)].GetModPlayer<TAZPlayer>().ZoneEmberGlades) {
				if (player.cratePotion) {
					if (liquidType == 1 && Main.rand.NextFloat() < .1f && NPC.downedMechBossAny && worldLayer == 4)
						caughtType = mod.ItemType("EmberCrate");
				}
				else {
					if (liquidType == 1 && Main.rand.NextFloat() < .05f && NPC.downedMechBossAny && worldLayer == 4)
						caughtType = mod.ItemType("EmberCrate");
				}
			}
		}
		public override void OnHitAnything(float x, float y, Entity victim)
		{
			if (gemstoneManaBullet)
			{
				if (Main.rand.Next(5) == 0)
				Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-4, -2), mod.ProjectileType("ManaSpike"), 40, 2, Main.myPlayer);
			}
			if (hyperCell)
				player.AddBuff(mod.BuffType("CellBoost"), 60, false);
		}
		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (stealthPotion && Main.rand.NextFloat() < .04f) {
				quiet = true;
				damage = 0;
				player.NinjaDodge();
				return false;
			}
			return true;
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
			hurtCounter++;
			if (extraNeonSlimyCore) {
				if (damage > 19)
				{
					Projectile.NewProjectile(player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<GiantSlimeSpikeFriendly>(), 5, 1, Main.myPlayer);
					Projectile.NewProjectile(player.Center + new Vector2(50, 0), new Vector2(0, 0), ModContent.ProjectileType<GiantSlimeSpikeFriendly>(), 5, 1, Main.myPlayer);
					Projectile.NewProjectile(player.Center + new Vector2(0, 100), new Vector2(0, 0), ModContent.ProjectileType<GiantSlimeSpikeFriendly>(), 5, 1, Main.myPlayer);
					Projectile.NewProjectile(player.Center + new Vector2(0, -100), new Vector2(0, 0), ModContent.ProjectileType<GiantSlimeSpikeFriendly>(), 5, 1, Main.myPlayer);
				}
			}
		}
		public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			numberShot += 1;
			if (gemstoneRanged && item.ranged == true)
            {
				if (numberShot % 5 == 0)
                {
					Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 25, mod.ProjectileType("GemstoneHeal"), 100, 10, Main.myPlayer);
				}
            }
			if (player.HeldItem.type == ItemID.Blowpipe)
			{
				player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			}
			if (player.HeldItem.type == ItemID.Blowgun)
			{
				player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			}
			return true;
        }
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if (xenicExpert && Main.rand.NextFloat() < .25f) {
				target.AddBuff(mod.BuffType("XenicAcid"), 60 * Main.rand.Next(3, 11), false);
			}
			if (bloodVial && Main.rand.NextFloat() < .08f && target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if (xenicExpert && Main.rand.NextFloat() < .25f) {
				target.AddBuff(mod.BuffType("XenicAcid"), 60 * Main.rand.Next(3, 11), false);
			}
			if (bloodVial && Main.rand.NextFloat() < .08f && target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvp(Item item, Player target, int damage, bool crit) {
			if (bloodVial && Main.rand.NextFloat() < .08f) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit) {
			if (bloodVial && Main.rand.NextFloat() < .08f) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void PostUpdateBuffs() {
			/*if (player.HasBuff(BuffID.ChaosState) && NPC.CountNPCS(ModContent.NPCType<NPCs.Minibosses.XenicAcidpumper>()) > 0)
			player.KillMe(PlayerDeathReason.ByCustomReason(player.name + "'s mind melted."), 9999, 0, false);
			if (gemstoneMagic)
			{
				if (player.statLife / 4 < player.statLifeMax2)
					player.manaCost -= 0.75f;
			}*/
			if (Main.GameUpdateCount % 180 == 90 && player.ownedProjectileCounts[ProjectileType<Projectiles.Titan.TitanFragment>()] < 5)
				Projectile.NewProjectile(player.position, new Vector2(), ProjectileType<Projectiles.Titan.TitanFragment>(), 30, 1f, Main.myPlayer);
		}
		public override void PreUpdateBuffs() {
			/*if (webdriver) {
				if (player.ownedProjectileCounts[ProjectileType<Projectiles.Other.Webdriver.BlueWebdriverRectangle>()] < 1)
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("BlueWebdriverRectangle"), (int)(125 * player.minionDamage), 2f, Main.myPlayer);
				if (player.ownedProjectileCounts[ProjectileType<Projectiles.Other.Webdriver.RedWebdriverRectangle>()] < 1)
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("RedWebdriverRectangle"), (int)(125 * player.minionDamage), 2f, Main.myPlayer);
			}*/
		}
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {	
			if (trueMelee15)
			damage += (int)(damage * .15f);
		}
	}
}