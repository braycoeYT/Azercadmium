using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Scavenger
{
	public class SpacetimeForager : ModNPC
	{
		public override void SetStaticDefaults()  {
			DisplayName.SetDefault("Spacetime Forager");
			Main.npcFrameCount[npc.type] = 6;
		}
        public override void SetDefaults() {
			npc.value = 0;
			npc.width = 40;
			npc.height = 50;
			npc.damage = 41;
			npc.defense = 9;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = 300;
			npc.damage = 73;
			if (AzercadmiumWorld.devastation) {
				npc.lifeMax = 400;
				npc.damage = 90;
			}
		}
		public override void HitEffect(int hitDirection, double damage) {
			for (int i = 0; i < 4; i++) {
				int dustType = mod.DustType("MatrixScavengerDust");
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
			if (npc.life <= 0 && AzercadmiumWorld.devastation)
				Projectile.NewProjectile(npc.Center, new Vector2(0, 0), mod.ProjectileType("SpacetimeCore"), 14, 0f, Main.myPlayer, 0f, 0f);
		}
		int Timer;
		int flee;
		int animationTimer;
		bool start = true;
		Vector2 landingPos;
		public override void AI() {
			npc.TargetClosest(true);
			if (Timer % 6 == 0)
				animationTimer++;
			if (animationTimer > 5)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 62;
			npc.direction = 1;
			Timer++;
			npc.velocity.X = 0;
			npc.velocity.Y = 0;
			if (Main.player[npc.target].statLife < 1) {
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1) {
					if (flee == 0)
						flee++;
				}
			}
			if (flee >= 1) {
				flee++;
				npc.noTileCollide = true;
				npc.velocity.Y = 7f;
				if (flee >= 450)
					npc.active = false;
			}
			if (start) {
				if (Main.rand.NextBool())
					landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 400);
				else
					landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(-400, -200);
				if (Main.rand.NextBool()) 
					landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 400);
				else
					landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-400, -200);
				start = false;
			}
			if (Timer % 180 == 0) {
				if (AzercadmiumWorld.devastation)
					Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), mod.ProjectileType("MatrixBlast"), 20, 2f, Main.myPlayer);
				else
					Projectile.NewProjectile(npc.Center, new Vector2(0, 4).RotatedByRandom(MathHelper.TwoPi), ProjectileID.DeathLaser, 20, 2f, Main.myPlayer);
			}
			if (Timer % 200 == 0 && !(Main.player[npc.target].statLife < 1))
				npc.position = landingPos;
			if ((Timer % 200 == 140 && !Main.expertMode) || (Timer % 200 == 155 && Main.expertMode)) {
				if (Main.rand.NextBool())
					landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(200, 400);
				else
					landingPos.X = Main.player[npc.target].Center.X + Main.rand.Next(-400, -200);
				if (Main.rand.NextBool()) 
					landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(200, 400);
				else
					landingPos.Y = Main.player[npc.target].Center.Y + Main.rand.Next(-400, -200);
				Projectile.NewProjectile(landingPos + new Vector2(16, 18), new Vector2(0, 0), mod.ProjectileType("SpacetimeForagerTarget"), 0, 0f, Main.myPlayer);
			}
		}
	}
}