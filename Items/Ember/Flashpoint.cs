using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace Azercadmium.Items.Ember
{
    public class Flashpoint : ModItem
    {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("'Get the flash you need in a dash at Flashpoint!'\nCasts ember sparks that shoot at blinding speeds that face towards your cursor every 1.5 seconds");
        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 40;
            item.magic = true;
            item.damage = 68;
            item.knockBack = 3.6f;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ModContent.ProjectileType<Projectiles.Ember.FlashpointProj>();
            item.shootSpeed = 20f;
            item.mana = 6;
            item.autoReuse = true;
            item.rare = ItemRarityID.Orange;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(mod.ItemType("CinderCedar"), 11);
            recipe.AddIngredient(ModContent.ItemType<BurntStinger>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SparkingBatFoot>());
            recipe.AddIngredient(ItemID.SoulofFright, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}