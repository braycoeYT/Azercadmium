using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Dirtball
{
	public class DiscanSecurityHandgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A ranged weapon used by an abandoned model of discus\nEvery third shot is an electric bolt that does 150% damage");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.damage = 21;
			item.width = 26;
			item.height = 24;
			item.knockBack = 2f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 30f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Green;
		}
		int shootNum;
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootNum++;
			if (shootNum % 3 == 0) {
				type = mod.ProjectileType("ElectricBoltPassive");
				damage = (int)(damage * 1.5f);
				Main.PlaySound(new LegacySoundStyle(2, 96, Terraria.Audio.SoundType.Sound), player.position);
			}
			return true;
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
			recipe.AddIngredient(mod.ItemType("OvergrownHandgunFragment"));
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}