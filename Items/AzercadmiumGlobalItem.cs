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
			if (GetInstance<AzercadmiumConfig>().vanillaSeed) {
				if (item.type == ItemID.GrassSeeds) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes\nBecause of the sharpness of the seed, it has a chance to deal an extra 2 damage to enemies (shown in dark green)");
					tooltips.Add(line);
				}
				if (item.type == ItemID.JungleGrassSeeds) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes\nBecause of the sharpness of the seed, it has a chance to deal an extra 2 damage to enemies (shown in dark green)\nHas a chance to poison enemies");
					tooltips.Add(line);
				}
				if (item.type == ItemID.MushroomGrassSeeds) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes\nBecause of the sharpness of the seed, it has a chance to deal an extra 2 damage to enemies (shown in dark green)\nHas a chance to shroomify enemies");
					tooltips.Add(line);
				}
				if (item.type == ItemID.CorruptSeeds) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes\nPierces enemies 5 times");
					tooltips.Add(line);
				}
				if (item.type == ItemID.CrimsonSeeds) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes\nPierces enemies 4 times");
					tooltips.Add(line);
				}
				if (item.type == ItemID.PumpkinSeed) {
					TooltipLine line = new TooltipLine(mod, "Tooltip#0", "For use with blowpipes");
					tooltips.Add(line);
				}
			}
		}
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PoisonDart)
				item.damage = 4;
			if (item.type == ItemID.Blowpipe)
				item.damage = 10;
			if (item.type == ItemID.Blowgun)
				item.damage = 29;
			if (item.type == ItemID.BoneArrow)
				item.damage = 10;
			if (item.type == ItemID.CookedMarshmallow)
				item.buffTime = 7200;
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
			if (GetInstance<AzercadmiumConfig>().vanillaSeed) {
				if (item.type == ItemID.GrassSeeds) {
					item.damage = 7;
					item.ranged = true;
					item.knockBack = 0f;
					item.shoot = ProjectileType<Projectiles.Other.Blowpipes.GrassSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.JungleGrassSeeds) {
					item.damage = 7;
					item.ranged = true;
					item.knockBack = 0f;
					item.shoot = ProjectileType<Projectiles.Jungle.JungleGrassSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.MushroomGrassSeeds) {
					item.damage = 7;
					item.ranged = true;
					item.knockBack = 0f;
					item.shoot = ProjectileType<Projectiles.GlowingMushroom.MushroomGrassSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.CorruptSeeds) {
					item.damage = 12;
					item.ranged = true;
					item.knockBack = 0f;
					item.shoot = ProjectileType<Projectiles.Corruption.CorruptSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.CrimsonSeeds) {
					item.damage = 14;
					item.ranged = true;
					item.knockBack = 0f;
					item.shoot = ProjectileType<Projectiles.Crimson.CrimsonSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.PumpkinSeed) {
					item.damage = 12;
					item.ranged = true;
					item.knockBack = 2f;
					item.shoot = ProjectileType<Projectiles.Pumpkin.PumpkinSeed>();
					item.shootSpeed = 0f;
					item.ammo = AmmoID.Dart;
					item.maxStack = 999;
				}
				if (item.type == ItemID.Coal) {
					item.maxStack = 999;
				}
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
				player.npcTypeNoAggro[mod.NPCType("StarpackSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("LivingMarshmellow")] = true;
				player.npcTypeNoAggro[mod.NPCType("RoastedLivingMarshmellow")] = true;
				player.npcTypeNoAggro[mod.NPCType("DirtSlime")] = true;
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