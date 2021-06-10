using Azercadmium.Aaa;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class EmberHorn : ModItem
    {
        private static Vector2 TPPosition;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Horn");
            Tooltip.SetDefault("Teleports you to the Ember Glades");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MagicMirror);
            item.useTime = 150;
            item.useAnimation = 150;
            item.SetShopValues(8, Item.sellPrice(gold: 6, silver: 66));
        }

        public override bool CanUseItem(Player player)
        {
            TPPosition = TAZPlayer.GetEmberGladesTeleportPosition();
            return (TPPosition - player.position).Length() < 1000 ? false : TPPosition != Vector2.Zero;
        }

        public override void UseStyle(Player player)
        {
            Dust.NewDust(player.Bottom + new Vector2((float)Math.Sin(player.itemAnimation * 0.157f) * 24f, 0), 2, 2, DustID.SolarFlare, 0, -8);
            if (player.itemAnimation == player.itemAnimationMax / 2)
            {
                if ((TPPosition - player.position).Length() < 1000 && player.itemAnimation > 2)
                {
                    player.itemAnimation = 0;
                    return;
                }
                player.teleporting = true;
                for (int i = 0; i < 30; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.Fire);
                }
                if (Main.myPlayer == player.whoAmI)
                {
                    player.Teleport(TPPosition, -2);
                }
                for (int i = 0; i < 40; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.Fire);
                }
                for (int i = 0; i < 10; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, 270);
                }
            }
            else
            {
            }
            if (player.itemAnimation > player.itemAnimationMax / 2)
            {
                Dust.NewDust(TPPosition + new Vector2((float)Math.Sin(player.itemAnimation * 0.157f) * 24f, 48), 2, 2, DustID.SolarFlare, 0, -8);
            }
        }
    }
}