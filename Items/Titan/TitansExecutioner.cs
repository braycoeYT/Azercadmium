using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Titan
{
	public class TitansExecutioner : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Titan's Executioner");
			Tooltip.SetDefault("Hitting enemies spawns floating Titan's Executioners to dash into enemies");
		}
		public override void SetDefaults() {
			item.damage = 76;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4.4f;
			item.value = Item.sellPrice(0, 5, 45, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			Projectile.NewProjectile(player.position, new Vector2(0, 10).RotatedByRandom(2*Math.PI), ModContent.ProjectileType<Projectiles.Titan.TitansExecutionerPassive>(), item.damage, item.knockBack, Main.myPlayer);
		}
	}
}