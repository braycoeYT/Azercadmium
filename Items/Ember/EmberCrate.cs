﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class EmberCrate : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldenCrate);
            item.SetShopValues(6, Item.buyPrice(gold: 8));
            item.createTile = ModContent.TileType<Tiles.Ember.EmberCrate>();
        }

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            if (Azercadmium.DownedAllMechBosses)
            {
                if (Main.rand.NextBool())
                {
                    int[] options = new int[]
                        {
                            ItemID.HotlineFishingHook,
                            ItemID.LavaCharm,
                            ModContent.ItemType<RevenantShield>(),
                            ModContent.ItemType<HellKey>(),
                        };
                    player.QuickSpawnItem(options[Main.rand.Next(options.Length)]);
                }
            }
            player.QuickSpawnItem(ModContent.ItemType<EmberGlobber>(), Main.rand.Next(4, 12));
            player.QuickSpawnItem(ItemID.HellstoneBar, Main.rand.Next(4, 12));
            int rand = Main.rand.Next(4);
            if (rand < 2 || rand > 2) player.QuickSpawnItem(ModContent.ItemType<BurntStinger>(), Main.rand.Next(1, 6));
            if (rand < 1 || rand > 1) player.QuickSpawnItem(ModContent.ItemType<SparkingBatFoot>(), Main.rand.Next(1, 6));
            if (rand == 1 || rand == 2) player.QuickSpawnItem(ModContent.ItemType<SparkingBatFoot>(), Main.rand.Next(1, 6));
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 10));
        }
    }
}