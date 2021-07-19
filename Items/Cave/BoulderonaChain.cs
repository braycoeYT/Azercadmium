using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class BoulderonaChain : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Boulderona chain");
			Tooltip.SetDefault("Pinky may cry\nStriking the ground produces a shockwave\nRight click for a more powerful attack, but you lose the ability to attack for a few seconds");
		}
		public override void SetDefaults() {
			item.width = 42;
			item.height = 38;
			item.value = Item.sellPrice(0, 0, 5);
			item.rare = ItemRarityID.Blue;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 45;
			item.useTime = 45;
			item.knockBack = 9f;
			item.damage = 23;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Cave.BoulderonaChain>();
			item.shootSpeed = 9f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}
		public override bool AltFunctionUse(Player player) {
            return true;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (player.altFunctionUse == 2) {
				damage *= 6;
				speedX *= 4;
				speedY *= 4;
				knockBack *= 3;
				player.AddBuff(ModContent.BuffType<Buffs.Debuffs.WornOut>(), 600);
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GrapplingHook);
			recipe.AddIngredient(ItemID.Boulder);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}