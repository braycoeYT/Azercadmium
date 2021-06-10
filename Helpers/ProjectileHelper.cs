using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace Azercadmium.Helpers
{
    public static class ProjectileHelper
    {
        public static int TargetClosestNPC(this Projectile projectile, int oldTargetWhoAmI = -1, bool useMinionTarget = false, bool seethroughWalls = false)
        {
            Player player = Main.player[projectile.owner];
            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;
            int targetWhoAmI = oldTargetWhoAmI;

            if (useMinionTarget && player.active)
            {
                if (player.HasMinionAttackTargetNPC)
                {
                    NPC npc = Main.npc[player.MinionAttackTargetNPC];
                    float between = Vector2.Distance(npc.Center, projectile.Center);
                    if (between < 2000f)
                    {
                        distanceFromTarget = between;
                        targetCenter = npc.Center;
                        foundTarget = true;
                        targetWhoAmI = npc.whoAmI;
                    }
                }
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = seethroughWalls || Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        bool closeThroughWall = between < 100f;
                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                            targetWhoAmI = npc.whoAmI;
                        }
                    }
                }
            }
            if (targetWhoAmI != -1)
            {
                if (!Main.npc[targetWhoAmI].active || Main.npc[targetWhoAmI].friendly || Main.npc[targetWhoAmI].townNPC || Main.npc[targetWhoAmI].lifeMax <= 5)
                    targetWhoAmI = -1;
            }

            return targetWhoAmI;
        }

        public static void UpdateOldPos(this Projectile projectile)
        {
            projectile.oldPos[0] = projectile.position;
            for (int i = projectile.oldPos.Length - 1; i > 0; i--)
            {
                projectile.oldPos[i] = projectile.oldPos[i - 1];
            }
        }

        public static void UpdateOldCenter(this Projectile projectile)
        {
            projectile.oldPos[0] = projectile.Center;
            for (int i = projectile.oldPos.Length - 1; i > 0; i--)
            {
                projectile.oldPos[i] = projectile.oldPos[i - 1];
            }
        }

        public static void CenterizeOldPos(this Projectile projectile)
        {
            for (int i = 0; i < projectile.oldPos.Length; i += 1)
            {
                if (projectile.oldPos[i] == Vector2.Zero)
                {
                    projectile.oldPos[i] = projectile.Center;
                }
            }
        }

        public static void UpdateOldRot(this Projectile projectile)
        {
            projectile.oldRot[0] = projectile.rotation;
            for (int i = (projectile.oldRot.Length - 1); i > 0; i--)
                projectile.oldRot[i] = projectile.oldRot[i - 1];
        }

        public static bool ProjectileCollisionWithOtherProjectiles(this Projectile projectile, float speed)
        {
            bool flag = false;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile other = Main.projectile[i];
                if (other.active && other.type == projectile.type && other.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - other.Center).X) < projectile.width && Math.Abs((projectile.Center - other.Center).Y) < projectile.height)
                {
                    projectile.velocity += Vector2.Normalize(projectile.Center - other.Center) * speed;
                    flag = true;
                }
            }
            return flag;
        }

        public static bool ProjectileCollisionWithOtherProjectiles(this Projectile projectile, float speed, int type)
        {
            bool flag = false;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile other = Main.projectile[i];
                if (other.active && other.type == type && other.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - other.Center).X) < projectile.width && Math.Abs((projectile.Center - other.Center).Y) < projectile.height)
                {
                    projectile.velocity += Vector2.Normalize(projectile.Center - other.Center) * speed;
                    flag = true;
                }
            }
            return flag;
        }

        public static bool ProjectileCollisionWithOtherProjectiles(this Projectile projectile, float speed, int[] types)
        {
            bool flag = false;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                Projectile other = Main.projectile[i];
                for (int j = 0; j < types.Length; j++)
                {
                    if (other.active && other.type == types[j] && other.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - other.Center).X) < projectile.width && Math.Abs((projectile.Center - other.Center).Y) < projectile.height)
                    {
                        projectile.velocity += Vector2.Normalize(projectile.Center - other.Center) * speed;
                        flag = true;
                    }
                }
            }
            return flag;
        }
        public static bool ProjectileCollisionWithOtherProjectile(this Projectile projectile, Projectile otherProjectile, float speed)
        {
            if (otherProjectile.active && otherProjectile.type == projectile.type && otherProjectile.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - otherProjectile.Center).X) < projectile.width && Math.Abs((projectile.Center - otherProjectile.Center).Y) < projectile.height)
            {
                projectile.velocity += Vector2.Normalize(projectile.Center - otherProjectile.Center) * speed;
                return true;
            }
            return false;
        }
        public static bool ProjectileCollisionWithOtherProjectile(this Projectile projectile, Projectile otherProjectile, float speed, int type)
        {
            if (otherProjectile.active && otherProjectile.type == type && otherProjectile.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - otherProjectile.Center).X) < projectile.width && Math.Abs((projectile.Center - otherProjectile.Center).Y) < projectile.height)
            {
                projectile.velocity += Vector2.Normalize(projectile.Center - otherProjectile.Center) * speed;
                return true;
            }
            return false;
        }
        public static bool ProjectileCollisionWithOtherProjectile(this Projectile projectile, Projectile otherProjectile, float speed, int[] types)
        {
            for (int j = 0; j < types.Length; j++)
            {
                if (otherProjectile.active && otherProjectile.type == types[j] && otherProjectile.whoAmI != projectile.whoAmI && Math.Abs((projectile.Center - otherProjectile.Center).X) < projectile.width && Math.Abs((projectile.Center - otherProjectile.Center).Y) < projectile.height)
                {
                    projectile.velocity += Vector2.Normalize(projectile.Center - otherProjectile.Center) * speed;
                    return true;
                }
            }

            return false;
        }
    }
}