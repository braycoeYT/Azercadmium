using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Swords
{
	public class Lobera : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Hits will slash the enemy's soul, causing their defense to be halved\nUsage of the sword rains tropical orbs from the sky");
		}
		public override void SetDefaults() {
			item.damage = 101;
			item.melee = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 7.1f;
			item.value = Item.sellPrice(0, 18, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item93;
			item.autoReuse = true;
			item.useTurn = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("LoberaArk");
			item.shootSpeed = 15f;
			item.channel = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.direction == 0)
				position.X -= 6;
			else
				position.X += 6;
			return true;
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, mod.DustType("LoberaDust"));
				dust.noGravity = true;
				dust.scale = 1f;
			}
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.PixieDust, 30);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}