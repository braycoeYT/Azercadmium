using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Cave
{
	public class BatBasher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a batball that confuses enemies with a 15 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 12;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.2f;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 900);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 11, mod.ProjectileType("Batball"), item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
	}
}