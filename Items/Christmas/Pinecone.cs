using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Christmas
{
	public class Pinecone : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes");
        }
		public override void SetDefaults() {
			item.damage = 12;
			item.ranged = true;
			item.width = 32;
			item.height = 34;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.White;
			item.shoot = ProjectileType<Projectiles.Christmas.Pinecone>();
			item.shootSpeed = 0f;
			item.ammo = AmmoID.Dart;
		}
	}
}