using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Bats
{
	public class Batsaber : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Absolutely worth it\nRight click to shoot a baseball with a 20 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 8;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.6f;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 1200);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 8, mod.ProjectileType("Baseball"), item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
	}
}