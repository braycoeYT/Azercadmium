using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Azercadmium.Items.Ember
{
    public class CinderCedarJavelin : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.ranged = true;
            item.damage = 39;
            item.knockBack = 3f;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<Projectiles.Ember.CinderCedarJavelin>();
            item.shootSpeed = 13f;
            item.autoReuse = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(gold: 2, silver: 27);
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 15);
            recipe.AddIngredient(ModContent.ItemType<Darkron.DarkronBar>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}