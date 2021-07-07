using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Underworld
{
	public class MoltenBlowpipe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Lights regular and wooden seeds ablaze");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 21;
			item.useTime = 21;
			item.damage = 37;
			item.width = 36;
			item.height = 8;
			item.knockBack = 2f;
			item.shoot = ProjectileID.Seed;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Dart;
			item.UseSound = SoundID.Item17;
			item.autoReuse = true;
			item.rare = ItemRarityID.Orange;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(6, -4);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			if (type == ProjectileID.Seed || type == ModContent.ProjectileType<Projectiles.Wood.WoodenSeed>())
				type =  ModContent.ProjectileType<Projectiles.Underworld.MoltenSeed>();
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.SetResult(this); 
			recipe.AddRecipe(); 
		}
	}
}