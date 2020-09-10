using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Azercadmium.Tiles
{
	public class AzercadmiumGlobalItem : GlobalItem
	{
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
			if (item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings) {
				TooltipLine line = new TooltipLine(mod, "Tooltip#0", "Increases ranged critcal strike chance by 5\nIncreases melee speed by 6%");
            tooltips.Add(line);
			}
		}
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PoisonDart)
				item.damage = 4;
			if (item.type == ItemID.Blowpipe)
				item.damage = 10;
			if (item.type == ItemID.Blowgun)
				item.damage = 34;
			if (item.type == ItemID.BoneArrow)
				item.damage = 10;
		}
		public override void UpdateEquip(Item item, Player player)
		{
			if (item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings) {
				player.rangedCrit += 5;
				player.meleeSpeed -= 0.06f;
			}
		}
		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			if (item.type == ItemID.RoyalGel || item.type == mod.ItemType("MonarchalGel"))
			{
				player.npcTypeNoAggro[mod.NPCType("BoneSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("EctojeweloSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("FleshySlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("MechanicalSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("SilvervoidSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("StarfurrySlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("VilespitSlime")] = true;
			}
		}
		public override void RightClick(Item item, Player player) {
			if (item.type == ItemID.FloatingIslandFishingCrate) {
				if (Main.rand.NextFloat() < .25f)
				player.QuickSpawnItem(mod.ItemType("Starfrenzy"));
			}
		}
		static int useItemCount;
		public override bool UseItem(Item item, Player player)
		{
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			useItemCount++;
			if (p.meteorMelee && item.melee && useItemCount % 3 == 0) {
				Vector2 pos = Main.MouseWorld;
				pos.Y = player.position.Y - 400;
				Projectile.NewProjectile(pos, new Vector2(Main.rand.NextFloat(-2, 2), 10), ProjectileID.FallingStar, 40, 2, Main.myPlayer);
			}
			return true;
		}
		public override void AddRecipes()
		{
			/*RecipeFinder finder = new RecipeFinder();
			finder.SetResult(ItemID.MeteorHelmet);
			Recipe recipe2 = finder.FindExactRecipe();
			if (recipe2 != null)
			{
				RecipeEditor editor = new RecipeEditor(recipe2);
				editor.AddIngredient(ItemID.FallenStar, 5);
			}*/
		}
	}
}