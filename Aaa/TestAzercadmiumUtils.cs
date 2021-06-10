using System;
using Terraria;
using Microsoft.Xna.Framework;

namespace Azercadmium.Aaa
{
    [Obsolete("Replaced with TAZUtils")]
    public static class TestAzercadmiumUtils
    {
        /// <summary>
        /// Adjusts a velocity depending on gravity
        /// </summary>
        /// <param name="velocity">The current velocity</param>
        /// <param name="gravity">The pulling force per time</param>
        /// <param name="time">the amount of time it takes</param>
        /// <returns>The adjusted velocity</returns>
        public static Vector2 AdjustToGravity(Vector2 velocity, float gravity, float time)
        {
            velocity.X /= time;
            velocity.Y = velocity.Y / time - 0.5f * gravity * time;
            return velocity;
        }

        public static NPC NearestNPC(Vector2 position, float maxDist)
        {
            NPC nearest = null;
            float dist = maxDist;
            for (int j = 0; j < Main.npc.Length; j++)
            {
                if (Main.npc[j].CanBeChasedBy())
                {
                    float num3 = Main.npc[j].width / 2 + Main.npc[j].height / 2;
                    if (Vector2.Distance(position, Main.npc[j].Center) < dist + num3)
                    {
                        dist = Vector2.Distance(position, Main.npc[j].Center);
                        nearest = Main.npc[j];
                    }
                }
            }
            return nearest;
        }

        public static NPC MinionTarget(this Vector2 position, float maxDist, Player player)
        {
            return player.whoAmI < 0 || player.whoAmI > 255 || player.MinionAttackTargetNPC < 0 || player.MinionAttackTargetNPC > Main.maxNPCs
                ? NearestNPC(position, maxDist)
                : player.HasMinionAttackTargetNPC ? Main.npc[player.MinionAttackTargetNPC] :
                NearestNPC(position, maxDist);
        }

        public static void MoveTowards(this Projectile projectile, Vector2 position, float speedX, float speedY, float maxSpeed)
        {
            if (projectile.Center.X > position.X)
                projectile.velocity.X -= speedX;
            else
            {
                projectile.velocity.X += speedX;
            }
            if (projectile.Center.Y < position.Y)
                projectile.velocity.Y += speedY;
            else
            {
                projectile.velocity.Y -= speedY;
            }
            if (projectile.velocity.Length() > maxSpeed)
                projectile.velocity = Vector2.Normalize(projectile.velocity) * maxSpeed;
        }

        public static void MoveTowards(this Projectile projectile, Vector2 position, float speed, float maxSpeed)
        {
            if (projectile.Center.X > position.X)
                projectile.velocity.X -= speed;
            else
            {
                projectile.velocity.X += speed;
            }
            if (projectile.Center.Y < position.Y)
                projectile.velocity.Y += speed;
            else
            {
                projectile.velocity.Y -= speed;
            }
            if (projectile.velocity.Length() > maxSpeed)
                projectile.velocity = Vector2.Normalize(projectile.velocity) * maxSpeed;
        }
    }
}