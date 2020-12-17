using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Bats
{
	public class OnettBat : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The Onett Bat has a 4% chance of dealing extra damage to enemies (represented by a Smash! and a forest green number)\nRight click to always hit a Smash! attack with a 10 second cooldown");
		}
		public override void SetDefaults() {
			item.damage = 71;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 46;
			item.useAnimation = 46;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7.1f;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if ((Main.rand.NextFloat() < .04f || player.altFunctionUse == 2)) {
				int smashDamage = damage + Main.rand.Next(-10, 11);
				if (smashDamage < 1) smashDamage = 1;
				if (target.type != NPCID.TargetDummy)
				if (target.life > damage + 10) target.life -= smashDamage;
				CombatText.NewText(target.getRect(), Color.ForestGreen, smashDamage);
				CombatText.NewText(target.getRect(), Color.ForestGreen, "Smash!");
				Main.PlaySound(SoundID.Shatter);
				if (target.life < 1)
					target.life = 1;
			}
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			if ((Main.rand.NextFloat() < .04f || player.altFunctionUse == 2)) {
				int smashDamage = damage + Main.rand.Next(-10, 11);
				if (smashDamage < 1) smashDamage = 1;
				if (target.statLife > damage + 10) target.statLife -= smashDamage;
				CombatText.NewText(target.getRect(), Color.ForestGreen, smashDamage);
				CombatText.NewText(target.getRect(), Color.ForestGreen, "Smash!");
				Main.PlaySound(SoundID.Shatter);
			}
		}
		public override bool AltFunctionUse(Player player) {
			return !player.HasBuff(mod.BuffType("BatCooldown"));
		}
		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2 && !player.HasBuff(mod.BuffType("BatCooldown"))) {
				player.AddBuff(mod.BuffType("BatCooldown"), 600);
				
			}
			return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 12);
			recipe.AddIngredient(ItemID.AdamantiteBar, 6);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 12);
			recipe.AddIngredient(ItemID.TitaniumBar, 6);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}