using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Azercadmium.UI;
using Terraria.Localization;
using Azercadmium.Aaa;

namespace Azercadmium.Items.Ember
{
    public class CinderCedarBow : ModItem
    {
        private string GetMode(Player player) => player.ModPlayer().cinderCedarBowMode > 0 ? "Mode: Dual Shot" : "Mode: Single Shot";

        public override void SetStaticDefaults()
        { //I didn't import it right so UI died
            DisplayName.SetDefault("Cinder Cedar Bow");
            Tooltip.SetDefault("The two strings allow for multiple arrows to be used, but it increases use time\nLeft click to shoot one arrow, and right click to shoot two arrows\nMakes all arrows inflict Charred");
            HotbarUI.instances.Add(new HotbarUI(ModContent.GetTexture("Azercadmium/UI/CinderCedarHotbarUI"), "CinderCedarBow:ToggleModes", "Toggle Modes", delegate(Player player)
            {
                player.ModPlayer().cinderCedarBowMode = player.ModPlayer().cinderCedarBowMode > 0 ? 0 : 1;
                if (player.ModPlayer().cinderCedarBowMode == 0)
                {
                    Main.NewText(Language.GetTextValue("Mods.Azercadmium.ItemTooltipExtra.CinderCedarSingleAnnouncement"), new Color(255, 255, 10));
                }
                else
                {
                    Main.NewText(Language.GetTextValue("Mods.Azercadmium.ItemTooltipExtra.CinderCedarDualAnnouncement"), new Color(255, 255, 10));
                }
            }, 1f));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.ranged = true;
            item.damage = 51;
            item.knockBack = 6.66f;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 12;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item5;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(gold: 2, silver: 27);
            item.autoReuse = true;
            item.noMelee = true;
        }
        public override bool AltFunctionUse(Player player) {
            return true;
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
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 34;
                item.useAnimation = 34;
                item.shootSpeed = 12.12f;
            }
            else
            {
                item.useTime = 19;
                item.useAnimation = 19;
                item.shootSpeed = 11.11f;
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4, 0);
        }

        //public override void ModifyTooltips(List<TooltipLine> tooltips) => tooltips.Add(new TooltipLine(mod, "BowMode", Language.GetTextValue(GetMode(Main.LocalPlayer))));

        public override void HoldItem(Player player)
        {
            player.ModPlayer().charredProj = true;
            HotbarUI.instances[HotbarUI.GetIndex("CinderCedarBow:ToggleModes")].active = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 34;
                item.useAnimation = 34;
                Vector2 velocity = new Vector2(speedX, speedY);
                int p = Projectile.NewProjectile(position + new Vector2(0, 10).RotatedBy(velocity.ToRotation() + MathHelper.Pi), velocity, type, damage, knockBack, player.whoAmI);
                Main.projectile[p].noDropItem = true;
                Projectile.NewProjectile(position + new Vector2(0, 10).RotatedBy(velocity.ToRotation()), velocity, type, damage, knockBack, player.whoAmI);
                return false;
            }
            else {
                item.useTime = 19;
                item.useAnimation = 19;
            }
            return true;
        }
    }
}