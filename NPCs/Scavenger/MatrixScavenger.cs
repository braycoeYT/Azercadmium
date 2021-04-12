using Microsoft.Xna.Framework;
using System;
using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Scavenger
{
	[AutoloadBossHead]
	public class MatrixScavenger : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Matrix Scavenger");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults() {
			npc.width = 120;
			npc.height = 140;
			npc.damage = 54;
			npc.defense = 45;
			npc.lifeMax = 45000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 120000;
			npc.boss = true;
			npc.lavaImmune = true;
			Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			if (azercadmiumMusic != null) 
				music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/Reactor");
			else 
				music = MusicID.Boss5;
			for (int k = 0; k < npc.buffImmune.Length; k++) {
				npc.buffImmune[k] = true;
			}
			npc.buffImmune[BuffID.Ichor] = false;
			npc.buffImmune[BuffID.CursedInferno] = false;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = 60000;
			npc.damage = 81;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 80000;
				npc.damage = 122;
			}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 6; i++) {
				int dustType = mod.DustType("MatrixScavengerYellowDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		int Timer;
		int animationTimer;
		int flee;
		int attack;
		int attackTimer;
		int subattack;
		bool attackDone = true;
		Vector2 landingPos;
		Vector2 targetPos;
		Vector2 attackPos;
		public override void AI() {
			Player target = Main.player[npc.target];
			npc.TargetClosest(true);
			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 3)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 162;
			Lighting.AddLight(npc.Center, Color.DarkGoldenrod.ToVector3() * 1f);
			npc.direction = 1;
			npc.rotation = 0;
			targetPos = Main.player[npc.target].Center;
			Timer++;
			npc.velocity.X = 0;
			npc.velocity.Y = 0;
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
			if (Main.dayTime)
			{
				npc.active = false;
				Color messageColor = Color.DarkSlateGray;
				string chat = "C:Terraria/Azercadmium/NPCs/Scavenger/MatrixScavenger failed with 1 error: Overheat Warning (daytime #00=6)";
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
				}
				else if (Main.netMode == NetmodeID.SinglePlayer)
				{
					Main.NewText(Language.GetTextValue(chat), messageColor);
				}
			}
			int phase = 1;
			float hpFlag = 0.55f;
			if (Main.expertMode)
				hpFlag = 0.6f;
			if (AzercadmiumWorld.devastation)
				hpFlag = 0.65f;
			float hpFlag2 = 0.25f;
			if (Main.expertMode)
				hpFlag2 = 0.3f;
			if (AzercadmiumWorld.devastation)
				hpFlag2 = 0.35f;
			float hpFlag3 = 0.1f;
			if (Main.expertMode)
				hpFlag3 = 0.15f;
			if (AzercadmiumWorld.devastation)
				hpFlag3 = 0.2f;
			float hpFlag4 = 0.06f;
			if (Main.expertMode)
				hpFlag4 = 0.08f;
			if (AzercadmiumWorld.devastation)
				hpFlag4 = 0.1f;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag))
				phase = 2;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag2))
				phase = 3;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag3))
				phase = 4;
			if ((double)(npc.life) < (double)(npc.lifeMax * hpFlag4))
				phase = 5;
			if (Timer % 90 == 0)
				Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (4 + phase / 10), ProjectileID.DeathLaser, 22 + phase, 2f, Main.myPlayer);
			if (Timer % 200 == 0 && attack != 3)
			{
				if (!(Main.player[npc.target].statLife < 1)) {
					if (Main.rand.NextBool())
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 400);
					else
						landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(-400, -200);
					if (Main.rand.NextBool())
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 400);
					else
						landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-400, -200);
					Projectile.NewProjectile(landingPos + new Vector2(0, 0), new Vector2(0, 0), mod.ProjectileType("MatrixScavengerTarget"), 0, 0f, Main.myPlayer);
				}
			}
			if ((Timer % 200 == 60 && !Main.expertMode) || (Timer % 200 == 45 && Main.expertMode) && attack != 3)
			{
				npc.Center = landingPos;
				int minionMax = 10;
				if (Main.expertMode) minionMax = 15;
				if (AzercadmiumWorld.devastation) minionMax = 20;
				if (NPC.CountNPCS(ModContent.NPCType<SpacetimeForager>()) < minionMax)
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("SpacetimeForager"));
			}
			if (attackDone) {
				attackTimer = 0;
				attackDone = false;
				int attackMax = 4;
				if (phase >= 2) attackMax = 5;
				if (phase >= 3) attackMax = 6;
				attack = Main.rand.Next(0, attackMax);
				subattack = Main.rand.Next(0, 2);
				npc.velocity = new Vector2(0, 0);
				//attack = 3;
			}
			if (attack == 0) {
				if (attackTimer == 0)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (7 + phase), mod.ProjectileType("SpacetimeCore"), 16 + phase, 0f, Main.myPlayer, 0f, 0f);
				attackTimer++;
				if (attackTimer % 200 == 0)
					attackDone = true;
			}
			if (attack == 1) {
				attackTimer++;
				if (attackTimer == 0 || attackTimer == 30 || attackTimer == 60 || attackTimer == 90)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (4 + phase / 10), ProjectileID.DeathLaser, 14 + phase, 2f, Main.myPlayer);
				if (attackTimer == 120 && phase >= 2)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (4 + phase / 10), ProjectileID.DeathLaser, 14 + phase, 2f, Main.myPlayer);
				if (attackTimer == 150 && phase >= 3)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (4 + phase / 10), ProjectileID.DeathLaser, 14 + phase, 2f, Main.myPlayer);
				if (attackTimer == 180 && phase >= 4)
					Projectile.NewProjectile(npc.Center, npc.DirectionTo(targetPos) * (4 + phase / 10), ProjectileID.DeathLaser, 14 + phase, 2f, Main.myPlayer);
				if (attackTimer % 200 == 0)
					attackDone = true;
			}
			if (attack == 2) {
				attackTimer++;
				if (attackTimer % 200 == 60) {
					Projectile.NewProjectile(new Vector2(target.position.X, target.position.Y - 400), new Vector2(0, 7 + phase), mod.ProjectileType("MatrixFlame"), 18 + phase, 2f, Main.myPlayer);
				}
				if (attackTimer % 200 == 120) {
					Projectile.NewProjectile(new Vector2(target.position.X + target.velocity.X * -30, target.position.Y - 400), new Vector2(0, 7 + phase), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(target.position.X + target.velocity.X * 30, target.position.Y - 400), new Vector2(0, 7 + phase), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
				}
				if (attackTimer % 200 == 180) {
					Projectile.NewProjectile(new Vector2(target.position.X + target.velocity.X * -60, target.position.Y - 400), new Vector2(0, 7 + phase), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(target.position.X + target.velocity.X * 60, target.position.Y - 400), new Vector2(0, 7 + phase), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
				}
				if (attackTimer % 200 == 0)
					attackDone = true;
			}
			if (attack == 3) {
				attackTimer++;
				npc.Center = new Vector2(npc.Center.X, target.Center.Y - 10);
				if (attackTimer == 1) {
					if (npc.position.X > target.position.X)
						subattack = 0;
					else
						subattack = 1;
				}
				float distance = npc.position.X - target.position.X;
				if (subattack == 0)
				{
					if (distance < 240) {  //Math.Abs(distance)
						npc.position.X += 240 - distance; //distance
					}
					else if (distance > 400) {
						npc.position.X += 400 - distance; //distance
					}
					else
						npc.velocity.X = 0;
				}
				else if (subattack == 1)
				{
					if (distance > -360) {  //Math.Abs(distance)
						npc.position.X += -360 - distance; //distance
					}
					else if (distance < -560) {
						npc.position.X += -560 - distance; //distance
					}
					else
						npc.velocity.X = 0;
				}
				
				if (attackTimer % (30 - phase * 2) == 0) {
					Projectile.NewProjectile(npc.Center, new Vector2(-7 - phase, 0), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
					Projectile.NewProjectile(npc.Center, new Vector2(7 + phase, 0), mod.ProjectileType("MatrixFlame"), 16 + phase, 2f, Main.myPlayer);
				}
				if (attackTimer % 200 == 0)
					attackDone = true;
			}
			if (attack == 4) {
				attackTimer++;
				if (attackTimer % 20 == 0) {
					Projectile.NewProjectile(new Vector2(target.position.X + Main.rand.Next(-600, 600), target.position.Y - 600), new Vector2(Main.rand.NextFloat(-1.4f, 1.4f), 2f), mod.ProjectileType("MatrixBlast"), 18 + phase, 2f, Main.myPlayer);
				}
				if (attackTimer % 200 == 0)
					attackDone = true;
			}
			if (attack == 5) {
				attackTimer++;
				if (attackTimer == 1) {
					attackPos = target.position;
					Projectile.NewProjectile(new Vector2(attackPos.X, attackPos.Y), new Vector2(0, 0), mod.ProjectileType("MatrixBlastTrailPath"), 0, 0f, Main.myPlayer);
				}
				if (attackTimer == 91) {
					Projectile.NewProjectile(new Vector2(attackPos.X - 200, attackPos.Y - 600), new Vector2(0, 2.75f), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X + 200, attackPos.Y - 600), new Vector2(0, 2.75f), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X - 200, attackPos.Y + 600), new Vector2(0, -2.75f), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X + 200, attackPos.Y + 600), new Vector2(0, -2.75f), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X + 600, attackPos.Y + 200), new Vector2(-2.75f, 0), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X + 600, attackPos.Y - 200), new Vector2(-2.75f, 0), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X - 600, attackPos.Y + 200), new Vector2(2.75f, 0), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(attackPos.X - 600, attackPos.Y - 200), new Vector2(2.75f, 0), mod.ProjectileType("MatrixBlast"), 19 + phase, 0f, Main.myPlayer);
				}
				if (attackTimer % 100 == 0)
					attackDone = true;
			}
		}
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.GreaterHealingPotion;
		}
		public override void NPCLoot() {
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), mod.ItemType("ScavengerBag"));
			else {
				Item.NewItem(npc.getRect(), mod.ItemType("SoulofByte"), Main.rand.Next(20, 40));
				Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Darkron.DarkronBar>(), Main.rand.Next(15, 31));
			}
			AzercadmiumWorld.downedScavenger = true;
		}
	}
}