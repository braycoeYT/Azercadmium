using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.NPCs.Slimes
{
	public class MechanicalSlime : ModNPC
	{
		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 7;
		}
        public override void SetDefaults() {
			npc.width = 38;
			npc.height = 18;
			npc.damage = 67;
			npc.defense = 25;
			npc.lifeMax = 293;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 4, 50);
			npc.aiStyle = 1;
			npc.knockBackResist = 0.6f;
			//animationType = 1;
			npc.alpha = 50;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = 542;
            npc.damage = 129;
        }
		int Timer;
		int animationTimer;
		public override void AI() {
			if (Main.player[npc.target].statLife < 1)
				npc.TargetClosest(true);
			Player target = Main.player[npc.target];
			Vector2 target2 = target.position;
			target2.X += Main.rand.Next(-60, 60);
			target2.Y += Main.rand.Next(-60, 60);
			Timer++;
			if (Timer % 180 == 0)
				Projectile.NewProjectile(npc.Center, (npc.DirectionTo(target2)) * 8, ProjectileID.PinkLaser, 34, 1f, Main.myPlayer);
			if (Timer % 10 == 0)
				animationTimer++;
			if (animationTimer > 6)
				animationTimer = 0;
			npc.frame.Y = animationTimer * 26;
			npc.spriteDirection = npc.direction;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedMechBossAny)
				return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
			return 0f;
        }
		public override void NPCLoot() {
			if (NPC.downedPlantBoss)
				Item.NewItem(npc.getRect(), mod.ItemType("ElementalGel"), Main.rand.Next(1, 3));
		}
	}
}