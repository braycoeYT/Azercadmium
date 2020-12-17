using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.OtherGuns
{
	public class PragmaticShotgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Every shot fires a volley of bullets and an onyx blast");
		}
		public override void SetDefaults()  {
			item.value = Item.sellPrice(0, 13, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 54;
			item.useTime = 54;
			item.damage = 294;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.1f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
			item.noMelee = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 255);
                }
            }
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-11, 0);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 125f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(speedX * 0.9), (int)(speedY * 0.9), ProjectileID.BlackBolt, damage, knockBack, Main.myPlayer);
			return false;
		}
		
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .65f)
            return false;
			else
			return true;
        }
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster);
			recipe.AddIngredient(ItemID.TacticalShotgun);
			recipe.AddIngredient(mod.ItemType("InfectedOnyx"), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}