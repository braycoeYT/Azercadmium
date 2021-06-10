using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.NPCs;
using Azercadmium.Projectiles;
using Azercadmium.Aaa;

namespace Azercadmium.Aaa
{
    public static class TAZExtensions
    {
        public static int[] GetAsArray(this int num) => new int[] { num };

        public static bool Contains(this int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public static TAZPlayer ModPlayer(this Player player) => player.GetModPlayer<TAZPlayer>();

        public static TAZGNPC GNPC(this NPC npc) => npc.GetGlobalNPC<TAZGNPC>();

        public static Vector3 ToVector3(this Vector2 vector) => new Vector3(vector.X, vector.Y, 0);

        public static Color ToColor(this Vector3 vector) => new Color(vector.X, vector.Y, vector.Z);

        public static Color ToColor(this Vector4 vector) => new Color(vector.X, vector.Y, vector.Z, vector.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="checkPlayer">chestType of 0</param>
        /// <param name="checkPiggyBank">chestType of 1</param>
        /// <param name="checkSafe">chestType of 2</param>
        /// <param name="checkDefendersForge">chestType of 3</param>
        /// <param name="checkAmmoSlotsFirst">whether to check the ammo slots first when going through a player's inventory</param>
        /// <param name="check">what item types to check for</param>
        /// <returns></returns>
        public static (int index, int chestType) HasItem2(this Player player, int check, bool checkPlayer = true, bool checkPiggyBank = false, bool checkSafe = false, bool checkDefendersForge = false, bool checkAmmoSlotsFirst = true)
        {
            if (checkPlayer)
            {
                if (checkAmmoSlotsFirst)
                {
                    for (int i = 50; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return (i, 0);
                        }
                    }
                    for (int i = 0; i < 50; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return (i, 0);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return (i, 0);
                        }
                    }
                }
            }
            if (checkPiggyBank)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank.item[i];
                    if (item.type == check)
                    {
                        return (i, 1);
                    }
                }
            }
            if (checkSafe)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank2.item[i];
                    if (item.type == check)
                    {
                        return (i, 2);
                    }
                }
            }
            if (checkDefendersForge)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank3.item[i];
                    if (item.type == check)
                    {
                        return (i, 3);
                    }
                }
            }
            return (-1, -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="checkPlayer">chestType of 0</param>
        /// <param name="checkPiggyBank">chestType of 1</param>
        /// <param name="checkSafe">chestType of 2</param>
        /// <param name="checkDefendersForge">chestType of 3</param>
        /// <param name="checkAmmoSlotsFirst">whether to check the ammo slots first when going through a player's inventory</param>
        /// <param name="check">what item types to check for</param>
        /// <returns></returns>
        public static (int index, int chestType) HasItem2(this Player player, int[] check, bool checkPlayer = true, bool checkPiggyBank = false, bool checkSafe = false, bool checkDefendersForge = false, bool checkAmmoSlotsFirst = true)
        {
            if (checkPlayer)
            {
                if (checkAmmoSlotsFirst)
                {
                    for (int i = 50; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return (i, 0);
                            }
                        }
                    }
                    for (int i = 0; i < 50; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return (i, 0);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return (i, 0);
                            }
                        }
                    }
                }
            }
            if (checkPiggyBank)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return (i, 1);
                        }
                    }
                }
            }
            if (checkSafe)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank2.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return (i, 2);
                        }
                    }
                }
            }
            if (checkDefendersForge)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank3.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return (i, 3);
                        }
                    }
                }
            }
            return (-1, -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="checkPlayer">chestType of 0</param>
        /// <param name="checkPiggyBank">chestType of 1</param>
        /// <param name="checkSafe">chestType of 2</param>
        /// <param name="checkDefendersForge">chestType of 3</param>
        /// <param name="checkAmmoSlotsFirst">whether to check the ammo slots first when going through a player's inventory</param>
        /// <param name="check">what item types to check for</param>
        /// <returns></returns>
        public static Item HasItem3(this Player player, int check, bool checkPlayer = true, bool checkPiggyBank = false, bool checkSafe = false, bool checkDefendersForge = false, bool checkAmmoSlotsFirst = true)
        {
            if (checkPlayer)
            {
                if (checkAmmoSlotsFirst)
                {
                    for (int i = 50; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return item;
                        }
                    }
                    for (int i = 0; i < 50; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return item;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        if (item.type == check)
                        {
                            return item;
                        }
                    }
                }
            }
            if (checkPiggyBank)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank.item[i];
                    if (item.type == check)
                    {
                        return item;
                    }
                }
            }
            if (checkSafe)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank2.item[i];
                    if (item.type == check)
                    {
                        return item;
                    }
                }
            }
            if (checkDefendersForge)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank3.item[i];
                    if (item.type == check)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="checkPlayer">chestType of 0</param>
        /// <param name="checkPiggyBank">chestType of 1</param>
        /// <param name="checkSafe">chestType of 2</param>
        /// <param name="checkDefendersForge">chestType of 3</param>
        /// <param name="checkAmmoSlotsFirst">whether to check the ammo slots first when going through a player's inventory</param>
        /// <param name="check">what item types to check for</param>
        /// <returns></returns>
        public static Item HasItem3(this Player player, int[] check, bool checkPlayer = true, bool checkPiggyBank = false, bool checkSafe = false, bool checkDefendersForge = false, bool checkAmmoSlotsFirst = true)
        {
            if (checkPlayer)
            {
                if (checkAmmoSlotsFirst)
                {
                    for (int i = 50; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return item;
                            }
                        }
                    }
                    for (int i = 0; i < 50; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return item;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 58; i++)
                    {
                        Item item = player.inventory[i];
                        for (int j = 0; j < check.Length; j++)
                        {
                            if (item.type == check[j])
                            {
                                return item;
                            }
                        }
                    }
                }
            }
            if (checkPiggyBank)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return item;
                        }
                    }
                }
            }
            if (checkSafe)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank2.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return item;
                        }
                    }
                }
            }
            if (checkDefendersForge)
            {
                for (int i = 0; i < 40; i++)
                {
                    Item item = player.bank3.item[i];
                    for (int j = 0; j < check.Length; j++)
                    {
                        if (item.type == check[j])
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }

        public static Item GetFirstTileItem(this Player player)
        {
            for (int i = 0; i < Main.maxInventory; i++)
            {
                Item item = player.inventory[i];
                if (item.createTile >= TileID.Dirt)
                {
                    return item;
                }
            }
            return null;
        }

        public static Item GetFirstTileItem(this Player player, int tilePlaceType)
        {
            for (int i = 0; i < Main.maxInventory; i++)
            {
                Item item = player.inventory[i];
                if (item.createTile == tilePlaceType)
                {
                    return item;
                }
            }
            return null;
        }

        public static Item GetFirstTileItem(this Player player, bool[] tileArray)
        {
            for (int i = 0; i < Main.maxInventory; i++)
            {
                Item item = player.inventory[i];
                if (item.createTile > TileID.Dirt && tileArray[item.createTile])
                {
                    return item;
                }
            }
            return null;
        }

        public static void PetActiveCheck(this Projectile projectile, Player player, ref bool petBuff)
        {
            if (!player.active)
            {
                projectile.active = false;
                return;
            }
            if (player.dead)
                petBuff = false;
            if (petBuff)
                projectile.timeLeft = 2;
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

        public static void UpdateRotDependingOnOldPos(this Projectile projectile)
        {
            projectile.oldRot[0] = projectile.velocity.ToRotation();
            for (int i = 1; i < ProjectileID.Sets.TrailCacheLength[projectile.type]; i++)
            {
                projectile.oldRot[i] = (projectile.oldPos[i] - projectile.oldPos[i - 1]).ToRotation();
            }
        }

        /// <summary>
        /// Updates <see cref="Projectile.oldPos"/>, <see cref="Projectile.oldRot"/>, and <see cref="Projectile.oldSpriteDirection"/>
        /// </summary>
        /// <param name="projectile">The projectile</param>
        public static void UpdateAllOldVariables(this Projectile projectile)
        {
            if (Azercadmium.GameWorldRunning)
            {
                int amount = ProjectileID.Sets.TrailCacheLength[projectile.type];
                projectile.oldPos[0] = projectile.position;
                for (int i = amount - 1; i > 0; i--)
                    projectile.oldPos[i] = projectile.oldPos[i - 1];

                projectile.oldRot[0] = projectile.rotation;
                for (int i = amount - 1; i > 0; i--)
                    projectile.oldRot[i] = projectile.oldRot[i - 1];

                projectile.oldSpriteDirection[0] = projectile.spriteDirection;
                for (int i = amount - 1; i > 0; i--)
                    projectile.oldSpriteDirection[i] = projectile.oldSpriteDirection[i - 1];
            }
        }

        public static TAZPGlobal Taz(this Projectile projectile) => projectile.GetGlobalProjectile<TAZPGlobal>();

        public static void SendGlobalData(this Projectile projectile, BinaryWriter b) => projectile.GetGlobalProjectile<TAZPGlobal>().Send(b);

        public static void ReciveGlobalData(this Projectile projectile, BinaryReader r) => projectile.GetGlobalProjectile<TAZPGlobal>().Receive(r);

        public static void UpdateOldPos(this NPC npc)
        {
            if (Azercadmium.GameWorldRunning)
            {
                npc.oldPos[0] = npc.position;
                for (int i = npc.oldPos.Length - 1; i > 0; i--)
                {
                    npc.oldPos[i] = npc.oldPos[i - 1];
                }
            }
        }

        public static void UpdateOldCenter(this NPC npc)
        {
            if (Azercadmium.GameWorldRunning)
            {
                npc.oldPos[0] = npc.Center;
                for (int i = npc.oldPos.Length - 1; i > 0; i--)
                {
                    npc.oldPos[i] = npc.oldPos[i - 1];
                }
            }
        }

        public static void CenterizeOldPos(this NPC npc)
        {
            for (int i = 0; i < npc.oldPos.Length; i += 1)
            {
                if (npc.oldPos[i] == Vector2.Zero)
                {
                    npc.oldPos[i] = npc.Center;
                }
            }
        }

        public static void UpdateOldRot(this NPC npc)
        {
            if (Azercadmium.GameWorldRunning)
            {
                npc.oldRot[0] = npc.rotation;
                for (int i = (npc.oldRot.Length - 1); i > 0; i--)
                    npc.oldRot[i] = npc.oldRot[i - 1];
            }
        }

        /// <summary>
        /// Updates <see cref="NPC.oldPos"/>, and <see cref="NPC.oldRot"/>
        /// </summary>
        /// <param name="npc">The projectile</param>
        public static void UpdateAllOldVariables(this NPC npc)
        {
            if (Azercadmium.GameWorldRunning)
            {
                int amount = NPCID.Sets.TrailCacheLength[npc.type];
                npc.oldPos[0] = npc.position;
                for (int i = amount - 1; i > 0; i--)
                    npc.oldPos[i] = npc.oldPos[i - 1];

                npc.oldRot[0] = npc.rotation;
                for (int i = amount - 1; i > 0; i--)
                    npc.oldRot[i] = npc.oldRot[i - 1];
            }
        }

        public static void AnyPreHardmodeBar(this ModRecipe recipe, int amount = 1) => recipe.AddRecipeGroup("Azercadmium:AnyPHBar", amount);

        public static void AnyGems(this ModRecipe recipe, int amount = 1) => recipe.AddRecipeGroup("Azercadmium:AnyGem", amount);

        public static void AnyShadowScale(this ModRecipe recipe, int amount = 1) => recipe.AddRecipeGroup("Azercadmium:AnyShadowScale", amount);

        public static void AnyWood(this ModRecipe recipe, int amount = 1) => recipe.AddRecipeGroup("Wood", amount);

        public static void AnyIronBar(this ModRecipe recipe, int amount = 1) => recipe.AddRecipeGroup("IronBar", amount);
    }
}