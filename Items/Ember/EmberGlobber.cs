using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Azercadmium.Projectiles.Ember;

namespace Azercadmium.Items.Ember
{
    public class EmberGlobber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ember Globber");
            Tooltip.SetDefault("Spreads the Ember Glades to some blocks");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bomb);
            item.maxStack = 999;
            item.SetShopValues(5, Item.buyPrice(copper: 66));
            item.shoot = ModContent.ProjectileType<EmberGlobberProjectile>();
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;
    }
}