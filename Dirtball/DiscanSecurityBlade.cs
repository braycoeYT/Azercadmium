using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DiscanSecurityBlade : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A melee weapon used by some prototype discuses\nEvery third swing releases an electric bolt");
		}
		public override void SetDefaults() {
			item.damage = 23;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.6f;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("ElectricBoltPassive");
			item.shootSpeed = 15f;
		}
		int shootNum;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootNum++;
			knockBack *= 0.5f;
			if (shootNum % 3 == 0)
				Main.PlaySound(new LegacySoundStyle(2, 96, Terraria.Audio.SoundType.Sound), player.position);
			return shootNum % 3 == 0;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, DustID.Electric);
				dust.noGravity = true;
				dust.scale = 0.5f;
			}
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OvergrownHilt"));
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