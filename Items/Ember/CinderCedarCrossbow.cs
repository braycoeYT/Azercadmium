using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Ember
{
    public class CinderCedarCrossbow : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cinder Cedar Crossbow");
        }
        public override void SetDefaults() {
            item.width = 20;
            item.height = 36;
            item.ranged = true;
            item.damage = 41;
            item.knockBack = 5.5f;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 12f;
            item.useTime = 12;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item5;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(gold: 2, silver: 27);
            item.autoReuse = true;
            item.noMelee = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>(), 3);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Darkron.DarkronBar>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(6, 0);
        }
    }
}