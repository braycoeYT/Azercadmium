using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Items.Other.Swords
{
	public class Giygaclaw : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It appears to be a claw of a mentally unstable alien\nLeeches life and mana on hit\nHaving low health or an emotional buff/debuff causes the Giygaclaw to deal one damage and not leech anything");
		}
		public override void SetDefaults() {
			item.damage = 319;
			item.melee = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1.1f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit) {
			if ((player.statLife < player.statLifeMax / 7) || (player.HasBuff(BuffID.Calm) || player.HasBuff(BuffID.Rage) || player.HasBuff(BuffID.Tipsy) || player.HasBuff(BuffID.Warmth) || player.HasBuff(BuffID.Wrath) || player.HasBuff(BuffID.Panic) || player.HasBuff(BuffID.Campfire) || player.HasBuff(BuffID.Sunflower) || player.HasBuff(BuffID.Darkness) || player.HasBuff(BuffID.Blackout) || player.HasBuff(BuffID.Silenced) || player.HasBuff(BuffID.Confused) || player.HasBuff(BuffID.Cursed) || player.HasBuff(BuffID.Weak) || player.HasBuff(BuffID.Horrified) || player.HasBuff(BuffID.ChaosState) || player.HasBuff(BuffID.Suffocation) || player.HasBuff(BuffID.Lovestruck)))
				damage = 0;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (!((player.statLife < player.statLifeMax / 7) || (player.HasBuff(BuffID.Calm) || player.HasBuff(BuffID.Rage) || player.HasBuff(BuffID.Tipsy) || player.HasBuff(BuffID.Warmth) || player.HasBuff(BuffID.Wrath) || player.HasBuff(BuffID.Panic) || player.HasBuff(BuffID.Campfire) || player.HasBuff(BuffID.Sunflower) || player.HasBuff(BuffID.Darkness) || player.HasBuff(BuffID.Blackout) || player.HasBuff(BuffID.Silenced) || player.HasBuff(BuffID.Confused) || player.HasBuff(BuffID.Cursed) || player.HasBuff(BuffID.Weak) || player.HasBuff(BuffID.Horrified) || player.HasBuff(BuffID.ChaosState) || player.HasBuff(BuffID.Suffocation) || player.HasBuff(BuffID.Lovestruck))))
			if (target.type != NPCID.TargetDummy && damage > 0) {
				player.statLife += 1;
				player.HealEffect(1, true);
				player.statMana += 1;
				player.ManaEffect(1);
			}
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod); //add osmium
			recipe.AddIngredient(ItemID.FetidBaghnakhs);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}