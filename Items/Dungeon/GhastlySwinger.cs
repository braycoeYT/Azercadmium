using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dungeon
{
	public class GhastlySwinger : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Right click to shoot a lost soul with a 10 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 97;
			item.melee = true;
			item.width = 36;
			item.height = 38;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.6f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.useTurn = true;
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 600);
				
				Projectile.NewProjectile(player.position, Vector2.Normalize((Main.MouseWorld - new Vector2(0, 0)) - player.Center) * 8, ProjectileID.LostSoulFriendly, item.damage, item.knockBack / 2, Main.myPlayer);
			}
			return true;
		}
	}
}