using Azercadmium.Aaa;
using Azercadmium.Prefixes;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Items
{
	public class AzercadmiumGlobalItem : GlobalItem
	{
		public static Item GetItem(int type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }

        public static Item GetItem(short type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }

        public static void AddDeveloperLine(List<TooltipLine> tooltips)
        {
            string text = Language.GetTextValue("Mods.Azercadmium.CommonText.DeveloperItem");
            TooltipLine developer = new TooltipLine(Azercadmium.Instance, "Developer", text) { overrideColor = new Color(255, 0, 0) };
            int index = tooltips.FindIndex(t => t.Name.Equals("ItemName") && t.mod.Equals("Terraria"));
            if (index != -1)
            {
                tooltips.Insert(index + 1, developer);
                return;
            }
            tooltips.Add(developer);
        }

        public static void AddDevastationLine(List<TooltipLine> tooltips)
        {
            string text = Language.GetTextValue("Mods.Azercadmium.CommonText.Devastation");
            TooltipLine devastation = new TooltipLine(Azercadmium.Instance, "Devastation", text);
            int index = tooltips.FindIndex(t => t.Name.Equals("SpecialPrice") && t.mod.Equals("Terraria"));
            if (index != -1)
            {
                tooltips.Insert(index, devastation);
                return;
            }
            index = tooltips.FindIndex(t => t.Name.Equals("Price") && t.mod.Equals("Terraria"));
            if (index != -1)
            {
                tooltips.Insert(index, devastation);
                return;
            }
            tooltips.Add(devastation);
        }

        public static void TileDefaults(Item item, int createTile, int style = 0, int maxStack = 999, int width = 14, int height = 14)
        {
            item.createTile = createTile;
            item.placeStyle = style;
            item.width = width;
            item.height = height;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = maxStack;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
        }
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
			if (item.type == ItemID.DaedalusStormbow && GetInstance<AzercadmiumConfig>().daedalusNerf) {
				TooltipLine line = new TooltipLine(mod, "Tooltip#0", "Nerfed by Azercadmium, can be disabled in the config");
				tooltips.Add(line);
			}
			if (item.type == ItemID.BandofRegeneration || item.type == ItemID.CharmofMyths) {
				TooltipLine line = new TooltipLine(mod, "Tooltip#0", "Increases the power of Regeneration Potions");
				tooltips.Add(line);
			}
			if (item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs) {
				TooltipLine line = new TooltipLine(mod, "Tooltip#0", "Increases the power of Magic Power potions");
				tooltips.Add(line);
			}
			if (item.type == ItemID.ManaRegenerationBand) {
				TooltipLine line = new TooltipLine(mod, "Tooltip#0", "Increases the power of Magic Regeneration potions");
				tooltips.Add(line);
			}
			/*if (GetInstance<AzercadmiumConfig>().vanillaSeedAmmo) {
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
			}*/
		}
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.Blowpipe)
				item.damage = 10;
			if (item.type == ItemID.Blowgun)
				item.damage = 29;
			if (item.type == ItemID.PoisonDart)
				item.damage = 7;
			if (item.type == ItemID.BoneArrow)
				item.damage = 10;
			if (item.type == ItemID.CookedMarshmallow)
				item.buffTime = 7200;
			if (item.type == ItemID.Coal) 
				item.maxStack = 999;
			if (item.type == ItemID.SnowGlobe) 
				item.maxStack = 999;
			if (item.type == ItemID.LaserDrill)
				item.pick = 220;
			if (item.type == ItemID.FlareGun)
				item.damage = 12;
			if (item.type == ItemID.Flare || item.type == ItemID.BlueFlare)
				item.damage = 7;
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
			if (GetInstance<AzercadmiumConfig>().daedalusNerf && item.type == ItemID.DaedalusStormbow) {
				item.damage = 29;
				item.useTime = 38;
				item.useAnimation = 38;
			}
			/*if (GetInstance<AzercadmiumConfig>().vanillaSeedAmmo) {
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
			}*/
			if (GetInstance<AzercadmiumConfig>().itemAuto) {
				if (item.type == ItemID.IceSickle || item.type == ItemID.WaterGun || item.type == ItemID.TrueNightsEdge || item.type == ItemID.TrueExcalibur)
					item.autoReuse = true;
			}
		}
		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (item.damage > 1 && !item.accessory && item.notAmmo == true && GetInstance<AzercadmiumConfig>().azercadmiumPrefixes) {
				if (Main.rand.Next(25) == 0)
					return ModContent.PrefixType<Rough>();
				if (Main.rand.Next(30) == 0)
					return ModContent.PrefixType<Blessed>();
				if (Main.rand.Next(30) == 0)
					return ModContent.PrefixType<Cursed>();
				if (item.knockBack > 0) {
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Epic>();
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Odd>();
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Egotistical>();
					if (Main.rand.Next(75) == 0)
						return ModContent.PrefixType<Exotic>();
				}
				if (item.melee) {
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Tremendous>();
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Atomic>();
				}
				if (item.ranged) {
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Wasted>();
					if (Main.rand.Next(30) == 0)
						return ModContent.PrefixType<Empowered>();
				}
			}
			return -1;
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
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (item.type == ItemID.RoyalGel || item.type == mod.ItemType("MonarchalGel")) {
				player.npcTypeNoAggro[mod.NPCType("BoneSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("MechanicalSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("StarpackSlime")] = true;
				player.npcTypeNoAggro[mod.NPCType("LivingMarshmellow")] = true;
				player.npcTypeNoAggro[mod.NPCType("RoastedLivingMarshmellow")] = true;
				player.npcTypeNoAggro[mod.NPCType("DirtSlime")] = true;
			}
			if (item.type == ItemID.BandofRegeneration || item.type == ItemID.CharmofMyths) {
				p.bandofRegen = true;
			}
			if (item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs) {
				p.bandofStarpower = true;
			}
			if (item.type == ItemID.ManaRegenerationBand) {
				p.bandofMagicRegen = true;
			}
		}
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "present") {
				if (Main.rand.NextFloat() < .25f) {
					float rand = Main.rand.NextFloat();
			if (rand < .1f)
				player.QuickSpawnItem(ItemID.CandyCaneBlock, Main.rand.Next(20, 50));
			else if (rand < .2f)
				player.QuickSpawnItem(ItemID.GreenCandyCaneBlock, Main.rand.Next(20, 50));
			else if (rand < .23f)
				player.QuickSpawnItem(ItemID.ChristmasPudding);
			else if (rand < .26f)
				player.QuickSpawnItem(ItemID.SugarCookie);
			else if (rand < .29f)
				player.QuickSpawnItem(ItemID.GingerbreadCookie);
			else if (rand < .3f)
				player.QuickSpawnItem(ItemID.DogWhistle);
			else if (rand < .4f)
				player.QuickSpawnItem(ItemID.PineTreeBlock, Main.rand.Next(20, 50));
			else if (rand < .45f)
				player.QuickSpawnItem(ItemID.Coal);
			else if (rand < .456f)
				player.QuickSpawnItem(ItemID.CandyCaneSword);
			else if (rand < .462f)
				player.QuickSpawnItem(1917);
			else if (rand < .468f)
				player.QuickSpawnItem(ItemID.FruitcakeChakram);
			else if (rand < .474f)
				player.QuickSpawnItem(ItemID.HandWarmer);
			else if (rand < .48f)
				player.QuickSpawnItem(ItemID.Toolbox);
			else if (rand < .57f)
				player.QuickSpawnItem(ItemID.Holly);
			else if (rand < .64f)
				player.QuickSpawnItem(ItemID.StarAnise, Main.rand.Next(20, 41));
			else if (rand < .65f)
				player.QuickSpawnItem(mod.ItemType("RedPivot"));
			else if (rand < .66f)
				player.QuickSpawnItem(mod.ItemType("GreenPivot"));
			else if (rand < .68f)
				player.QuickSpawnItem(ItemID.ReindeerAntlers);
			else if (rand < .69f)
				player.QuickSpawnItem(ItemID.SnowHat);
			else if (rand < .7f)
				player.QuickSpawnItem(ItemID.UglySweater);
			else if (rand < .71f) {
				player.QuickSpawnItem(ItemID.RedRyder);
				player.QuickSpawnItem(ItemID.MusketBall, Main.rand.Next(30, 61));
			}
			else if (rand < .77f)
				player.QuickSpawnItem(mod.ItemType("Pinecone"), Main.rand.Next(30, 61));
			else if (rand < .83f)
				player.QuickSpawnItem(ItemID.Eggnog, Main.rand.Next(1, 4));
			else if (rand < .84f)
				player.QuickSpawnItem(mod.ItemType("CandyCaneCrusher"));
			else if (rand < .85f)
				player.QuickSpawnItem(mod.ItemType("CandyCanePike"));
			else if (rand < .9f)
				player.QuickSpawnItem(mod.ItemType("Smore"), Main.rand.Next(1, 4));
			else if (rand < .901f)
				player.QuickSpawnItem(ItemID.LifeCrystal);
			else if (rand < .925f)
				player.QuickSpawnItem(ItemID.WarmthPotion, Main.rand.Next(1, 6));
			else if (rand < .94f)
				player.QuickSpawnItem(ItemID.Snowball, Main.rand.Next(50, 121));
			else if (rand < .945f)
				player.QuickSpawnItem(ItemID.IceMachine);
			else if (rand < .946f)
				player.QuickSpawnItem(ItemID.IceBoomerang);
			else if (rand < .947f)
				player.QuickSpawnItem(ItemID.SnowballCannon);
			else if (rand < .948f)
				player.QuickSpawnItem(ItemID.IceSkates);
			else if (rand < .949f)
				player.QuickSpawnItem(724);
			else if (rand < .95f)
				player.QuickSpawnItem(ItemID.BlizzardinaBottle);
			else if (rand < .951f)
				player.QuickSpawnItem(ItemID.IceMirror);
			else
				player.QuickSpawnItem(mod.ItemType("UglySocks"));
				}
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
			if (p.spaceAmulet && item.damage > 0 && useItemCount % 90 == 0) {
				Vector2 pos = Main.MouseWorld;
				float rand = Main.rand.NextFloat(-4, 4);
				pos.X -= rand*28;
				pos.Y = player.position.Y - 420;
				Projectile.NewProjectile(pos, new Vector2(rand, 15), ModContent.ProjectileType<Projectiles.Sky.AmuletStar>(), 40, 2, Main.myPlayer);
			}
			if (p.artifactofFire && Main.rand.Next(45) == 0)
				Projectile.NewProjectile(player.Center, player.DirectionTo(Main.MouseWorld) * 10f, 15, 20, 2f, Main.myPlayer);
		}
		static int shootCount;
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			shootCount++;
			AzercadmiumPlayer p = player.GetModPlayer<AzercadmiumPlayer>();
			if (p.gooeySetBonus && item.summon == false && shootCount % 3 == 0)
				Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<Projectiles.Other.Bats.ExplosiveMarshmallow>(), (int)(item.damage * 1.25f), 2f, Main.myPlayer);
			return true;
		}
		public override bool CanUseItem(Item item, Player player) {
			return !Azercadmium.sTree && !player.ModPlayer().hoveringOverUI;
		}
		public override bool UseItem(Item item, Player player) {
            Point mouseTileWorld = Main.MouseWorld.ToTileCoordinates();
            if (Main.myPlayer == player.whoAmI) {
                if (item.createTile == ModContent.TileType<Tiles.Ember.EmberGrass>()) {
                    Tile tile = Framing.GetTileSafely(mouseTileWorld.X, mouseTileWorld.Y);
                    if (tile.type == TileID.Ash) {
                        Main.PlaySound(SoundID.Dig, player.position);
                        Framing.GetTileSafely(mouseTileWorld.X, mouseTileWorld.Y).type = (ushort)ModContent.TileType<Tiles.Ember.EmberGrass>();
                        WorldGen.TileFrame(mouseTileWorld.X, mouseTileWorld.Y, true, false);
                        Azercadmium.NetTile(mouseTileWorld.X, mouseTileWorld.Y, 1);
                        return true;
                    }
                }
            }
            return base.UseItem(item, player);
        }
	}
}