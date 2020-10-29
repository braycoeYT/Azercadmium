using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DiscanSecurityElectrifier : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A magic weapon used by a constantly overheating scrapped model of discus\nEvery third shot fires a bolt that explodes into electricity");
		}
		public override void SetDefaults() {
			item.damage = 26;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1.2f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.Green;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ElectricBoltPassive");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.mana = 13;
			item.UseSound = SoundID.Item91;
		}
		int shootNum;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootNum++;
			if (shootNum % 3 == 0)
				type = mod.ProjectileType("ElectricBoltPassiveExplode");
			return true;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 0);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OvergrownHandgunFragment"));
			recipe.AddIngredient(mod.ItemType("BrokenDiscus"), 8);
			recipe.AddIngredient(mod.ItemType("Electroid"));
			recipe.AddIngredient(ItemID.HellstoneBar);
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}