using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			if (GetInstance<AzercadmiumConfig>().pearlwoodBuff) {
				if (item.type == ItemID.PearlwoodBow)
					item.damage = 29;
				if (item.type == ItemID.PearlwoodHelmet)
					item.defense = 8;
				if (item.type == ItemID.PearlwoodBreastplate)
					item.defense = 9;
				if (item.type == ItemID.PearlwoodGreaves)
					item.defense = 9;
				if (item.type == ItemID.PearlwoodHammer)
					item.hammer = 80;
				if (item.type == ItemID.PearlwoodSword)
					item.damage = 46;
			}
		}
		public override void UpdateEquip(Item item, Player player)
		{
			if (item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings) {
				player.rangedCrit += 5;
				player.meleeSpeed -= 0.06f;
			}
		}
		public override string IsArmorSet(Item head, Item body, Item legs) {
			if (head.type == ItemID.PearlwoodHelmet && body.type == ItemID.PearlwoodBreastplate && legs.type == ItemID.PearlwoodGreaves)
				return "Pearlwood";
			return "";
		}
		public override void UpdateArmorSet(Player player, string set) {
			if (GetInstance<AzercadmiumConfig>().pearlwoodBuff && set == "Pearlwood") {
				player.setBonus = "+3 Defense, +5% all damage, and +20 max mana";
				player.statDefense += 2;
				player.allDamage += 0.05f;
				player.statManaMax2 += 20;			
			}
		}
		public override void UpdateAccessory(Item item, Player player, bool hideVisual)
		{
			if (item.type == ItemID.RoyalGel || item.type == mod.ItemType("MonarchalGel"))
			{
				player.npcTypeNoAggro[mod.NPCType("BoneSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("MechanicalSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("StarfurrySlime")] = true;
			}
		}
		public override void RightClick(Item item, Player player) {
			if (item.type == ItemID.FloatingIslandFishingCrate) {
				if (Main.rand.NextFloat() < .25f)
				player.QuickSpawnItem(mod.ItemType("Starfrenzy"));
			}
		}
		static int useItemCount;
		public override void UseStyle(Item item, Player player)
		{
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			useItemCount++;
			if (p.meteorMelee && item.melee && useItemCount % 120 == 0) {
				Vector2 pos = Main.MouseWorld;
				pos.Y = player.position.Y - 400;
				Projectile.NewProjectile(pos, new Vector2(Main.rand.NextFloat(-2, 2), 10), ProjectileID.FallingStar, 40, 2, Main.myPlayer);
			}
		}
	}
}