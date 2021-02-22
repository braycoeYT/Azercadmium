using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Goblins
{
	public class ChaosCaster : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Casts a chaos ball that breaks into 3 shards on impact\nChaos Ball Shards do not collide with tiles");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 0, 54, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 23;
			item.useTime = 23;
			item.damage = 22;
			item.width = 28;
			item.height = 30;
			item.knockBack = 3.4f;
			item.shoot = ModContent.ProjectileType<Projectiles.Goblins.ChaosBallFriendly>();
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Green;
			item.mana = 9;
			item.UseSound = SoundID.Item116;
		}
	}
}