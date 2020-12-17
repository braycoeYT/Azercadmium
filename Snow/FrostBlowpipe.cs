using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items.Snow
{
	public class FrostBlowpipe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Uses seed shots as ammo\nWhile in your inventory, the following enemies will drop Icy Seedshots:\nIce Slime, Spiked Ice Slime, Icy Discus");
		}
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Blowpipe);
			item.damage = 10; //9, mod 12
			item.knockBack = 3f; //3.5
			item.shootSpeed = 10f; //11
			item.useTime = 39; //45
			item.useAnimation = 39; //45
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(mod.BuffType("OutOfBreath"), item.useTime, false);
			return true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(0, -5);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowBlock, 6);
			recipe.AddIngredient(ItemID.IceBlock, 11);
			recipe.AddIngredient(mod.ItemType("CryoCrystal"), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}