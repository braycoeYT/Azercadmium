using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium
{
    public static class AzercadmiumUtils
    {
        public static bool ConsumeAmmo(Player player, int type, out int ammoTypeUsed, int removeAmount = 1)
        {
            // Checks ammo / coin slots first
            for (int i = 0; i < 8; i++)
            {
                int _i = i + 50; // The real inventory slot
                Item item = player.inventory[_i];
                if (item.ammo == type && item.stack > 0)
                {
                    if (item.consumable)
                        item.stack -= removeAmount;
                    ammoTypeUsed = item.type;
                    return true;
                }
            }
            for (int i = 0; i < Main.realInventory; i++)
            {
                Item item = player.inventory[i];
                if (item.ammo == type && item.stack > 0)
                {
                    if (item.consumable)
                        item.stack -= removeAmount;
                    ammoTypeUsed = item.type;
                    return true;
                }
            }
            ammoTypeUsed = 0;
            return false;
        }

        public static bool UseAmmo(Player player, int type, int removeAmount = 1)
        {
            // Checks ammo / coin slots first
            for (int i = 0; i < 8; i++)
            {
                int _i = i + 50; // The real inventory slot
                Item item = player.inventory[_i];
                if (item.ammo == type && item.stack > 0)
                {
                    if (item.consumable)
                        item.stack -= removeAmount;
                    return true;
                }
            }
            for (int i = 0; i < Main.realInventory; i++)
            {
                Item item = player.inventory[i];
                if (item.ammo == type && item.stack > 0)
                {
                    if (item.consumable)
                        item.stack -= removeAmount;
                    return true;
                }
            }
            return false;
        }

        public static bool BossAlive() {
			for (int i = 0; i < Main.maxNPCs; i++) {
				if (Main.npc[i].active && (Main.npc[i].boss || Main.npc[i].type == NPCID.EaterofWorldsHead)) {
					return true;
				}
            }
			return false;
        }
    }
}