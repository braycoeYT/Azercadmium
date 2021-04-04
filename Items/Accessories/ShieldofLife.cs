using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Accessories
{
    public class ShieldofLife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shield of Life");
            Tooltip.SetDefault("Increases life by 50\nGreatly increases life regen\nEnemies burn when nearby");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Lime;
            item.defense = 12;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 50;
            player.lifeRegen *= 2;
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Cave.LifeCrystalShield>());
            recipe.AddIngredient(ItemID.ChlorophyteBar, 32);
            recipe.AddIngredient(ItemID.LifeFruit, 10);
            recipe.AddIngredient(ItemID.Stinger, 50);
            recipe.AddIngredient(ItemID.JungleSpores, 20);
            recipe.AddIngredient(ItemID.Vine, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}