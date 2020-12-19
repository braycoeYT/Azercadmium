using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Scavenger
{
	public class MatrixMachinegun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rapidly fires matrix blasts with a medium inaccuracy");
		}
		public override void SetDefaults() {
			item.damage = 49;
			item.magic = true;
			item.width = 72;
			item.height = 26;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1.4f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = mod.ProjectileType("MatrixBlastFriendlyMagic");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 3;
			item.UseSound = SoundID.Item91;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-20, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(mod.ItemType("SoulofByte"), 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}