using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Guns
{
    public class TheAvalanche : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Left click to fire snowballs, and right click to fire sand\n33% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 10);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 11;
            item.useTime = 11;
            item.damage = 220;
            item.width = 54;
            item.height = 26;
            item.knockBack = 0f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 13f;
            item.noMelee = true;
            item.ranged = true;
            item.UseSound = SoundID.Item11;
            item.rare = 10;
            item.autoReuse = true;
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.NextBool(3))
                return false;
            return true;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) => false;

        public override bool CanUseItem(Player player)
        {
            Vector2 shootDirection = Vector2.Normalize(Main.MouseWorld - player.position);
            int useAmount = 1;
            if (ConsumeAmmo(player))
                useAmount = 0;
            if (player.altFunctionUse == 2)
            {
                if (ModUtils.Player.UseAmmo(player, AmmoID.Sand, out int ammoTypeUsed, useAmount))
                {
                    int shoot = ProjectileID.SandBallGun;
                    if (ammoTypeUsed == ItemID.PearlsandBlock)
                        shoot = ProjectileID.PearlSandBallGun;
                    else if (ammoTypeUsed == ItemID.EbonsandBlock)
                        shoot = ProjectileID.EbonsandBallGun;
                    else if (ammoTypeUsed == ItemID.CrimsandBlock)
                        shoot = ProjectileID.CrimsandBallGun;

                    float decreasedShootSpeed = item.shootSpeed * 0.55f;
                    Vector2 perturbedSpeed = shootDirection.RotatedByRandom(MathHelper.ToRadians(5)) * decreasedShootSpeed;
                    Projectile.NewProjectile(player.MountedCenter, perturbedSpeed, shoot, item.damage, item.knockBack, player.whoAmI);
                    return true;
                }
            }
            else if (ModUtils.Player.UseAmmo(player, AmmoID.Snowball, useAmount))
            {
                Vector2 perturbedSpeed = shootDirection.RotatedByRandom(MathHelper.ToRadians(5)) * item.shootSpeed;
                Projectile.NewProjectile(player.MountedCenter, perturbedSpeed, ProjectileID.SnowBallFriendly, item.damage, item.knockBack, player.whoAmI);
                return true;
            }
            return false;
        }
        public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sandgun);
            recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddIngredient(ItemID.FragmentVortex, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}