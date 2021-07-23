using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Projectiles.Jelly
{
	public class MiniJelly : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mini Jelly");
			Main.projFrames[projectile.type] = 3;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			projectile.width = 30;
			projectile.height = 30;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return false;
		}
		public override bool MinionContactDamage() {
			return false;
		}
		int Timer = Main.rand.Next(0, 120);
		int target = 0;
		int mode;
		int modeTimer;
		int wait;
		Vector2 important;
		public override void AI() {
			Timer++;
			Player player = Main.player[projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.MiniJelly>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.MiniJelly>()))
			{
				projectile.timeLeft = 2;
			}
			#endregion

			#region General behavior
			Vector2 idlePosition = player.Center + new Vector2(Main.rand.Next(-240, 240), Main.rand.Next(-240, 240));
			//special
			idlePosition.Y -= 100;

			float minionPositionOffsetX = 0f;//(10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX;
			
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
							target = i;
						}
					}
				}
			}
			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			float speed = 8f;
			float inertia = 10f;
			if (foundTarget)
			{
				if (distanceFromTarget > 40f) {
					Vector2 direction = idlePosition - projectile.Center; //targetCenter --> idlePosition
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				if (distanceToIdlePosition > 600f) {
					speed = 16f;
					inertia = 20f;
				}
				else {
					speed = 8f;
					inertia = 10f;
				}
				if (distanceToIdlePosition > 20f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					projectile.velocity.X = Main.rand.NextFloat(-1, 1);
					projectile.velocity.Y = Main.rand.NextFloat(-1, 1);
				}
			}
            #endregion

            #region Projectile
			//Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 140;
			//if (Timer % 120 == 0 && foundTarget)
			//Projectile.NewProjectile(projectile.Center, projDir, ProjectileType<MiniJellyLaser>(), projectile.damage, projectile.knockBack / 3, Main.myPlayer, target);

			#endregion

            #region Animation and visuals
            projectile.rotation = projectile.velocity.X * 0.05f;

			int frameSpeed = 5;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed) {
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type]) {
					projectile.frame = 0;
				}
			}

			projectile.spriteDirection = player.direction;
            //Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 0.78f);
            #endregion

            #region Teleport
			if (foundTarget) {
				projectile.velocity = new Vector2(0, 0);
				if (Main.npc[target].Center.X < projectile.Center.X) projectile.direction = 0;
				else projectile.direction = 1;
				if (mode == 0) {
					projectile.alpha += 15;
					if (projectile.alpha >= 255)
						mode = 1;
				}
				else if (mode == 1) {
					important = Main.npc[target].Center + new Vector2(0, 200).RotatedByRandom(2);
					mode = 2;
				}
				else if (mode == 2) {
					projectile.Center = important;
					projectile.alpha -= 51;
					if (projectile.alpha <= 0)
						mode = 3;
				}
				else if (mode == 3) {
					projectile.Center = important;
					Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 140;
					Projectile.NewProjectile(projectile.Center, projDir, ProjectileType<MiniJellyLaser>(), projectile.damage, projectile.knockBack / 3, Main.myPlayer, target, wait);
					mode = 4;
				}
				else if (mode == 4) {
					modeTimer++;
					if (modeTimer >= wait) {
						modeTimer = 0;
						mode = 0;
						wait -= 10;
					}
				}
			}
			else {
				mode = 0;
				projectile.alpha = 0;
				wait = 60;
			}
            #endregion
        }
    }
}