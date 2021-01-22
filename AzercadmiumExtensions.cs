using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Azercadmium
{
    public static class AzercadmiumExtensions
    {
        public static Mod mod = Azercadmium.Mod;

        #region Item

        #region Tooltips
        public static void ChangeItemName(this List<TooltipLine> tooltips, string newName = null, Color? newColor = null)
        {
            foreach (TooltipLine t in tooltips)
            {
                if (t.Name == "ItemName" && t.mod == "Terraria")
                {
                    if (newColor != null)
                        t.overrideColor = (Color)newColor;
                    if (!string.IsNullOrEmpty(newName))
                        t.text = newName;
                }
            }
        }

        public static void DevastationText(this List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(mod, "Devastation", "Devastation");
            foreach (TooltipLine t in tooltips)
            {
                if (t.Name == "Expert" && t.mod == "Terraria")
                {
                    tooltips.Insert(tooltips.IndexOf(t) + 1, line);
                    return;
                }
                if (t.Name == "SpecialPrice" && t.mod == "Terraria")
                {
                    tooltips.Insert(tooltips.IndexOf(t) + 1, line);
                    return;
                }
                if (t.Name == "Price" && t.mod == "Terraria")
                {
                    tooltips.Insert(tooltips.IndexOf(t) + 1, line);
                    return;
                }
            }
            tooltips.Add(line);
        }
        #endregion

        #endregion

        #region Player
        public static AzercadmiumPlayer AzercadmiumPlayer(this Player player) => player.GetModPlayer<AzercadmiumPlayer>();
        #endregion

        #region Projectile
        public static void UpdateOldPos(this Projectile projectile)
        {
            projectile.oldPos[0] = projectile.position;
            for (int i = (projectile.oldPos.Length - 1); i > 0; i--)
                projectile.oldPos[i] = projectile.oldPos[i - 1];
        }

        public static bool TargetClosestNPC(this Projectile projectile, ref int targetWhoAmI, bool useMinionTarget = false, bool SeethroughWalls = false)
        {
            Player player = Main.player[projectile.owner];
            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;

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
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = SeethroughWalls || Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
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
            return foundTarget;
        }
        #endregion
    }
}