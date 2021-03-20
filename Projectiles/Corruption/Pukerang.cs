using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Projectiles.Corruption
{
	public class Pukerang : ModProjectile
	{
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pukerang");
        }
		public override void SetDefaults() {
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.timeLeft = 9999;
		}
		int Timer;
		public override void AI() {
			float distanceFromTarget = 100f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					float between = Vector2.Distance(npc.Center, projectile.Center);
					bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
					bool inRange = between < distanceFromTarget;
					bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
					bool closeThroughWall = between < 100f;
					if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall) && npc.life > 0 && npc.type != NPCID.TargetDummy && npc.friendly == false) {
						distanceFromTarget = between;
						targetCenter = npc.Center;
						foundTarget = true;
					}
				}
			}
			Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 10;
			if (foundTarget) {
				Timer++;
				if (Timer % 20 == 0)
				Projectile.NewProjectile(projectile.Center, projDir, ProjectileID.CursedFlameFriendly, projectile.damage, projectile.knockBack / 4, Main.myPlayer);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.CursedInferno, Main.rand.Next(4, 11) * 60);
		}
		public override void OnHitPvp(Player target, int damage, bool crit) {
			target.AddBuff(BuffID.CursedInferno, Main.rand.Next(4, 11) * 60);
		}
	}   
}