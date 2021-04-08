using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Azercadmium
{
	public class Azercadmium : Mod
	{
		public Azercadmium()
		{
			
		}
		public static Mod Mod => ModLoader.GetMod("Azercadmium");
		public static bool[] JavelinCache;
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call(
					"AddBoss",
					0.5f,
					new List<int> { ModContent.NPCType<NPCs.Dirtball.Dirtball>() },
					this,
					"$Mods.Azercadmium.NPCName.Dirtball",
					(Func<bool>)(() => AzercadmiumWorld.downedDirtball),
					ModContent.ItemType<Items.Dirtball.CreepyMud>(),
					new List<int> { ModContent.ItemType<Items.Dirtball.MuddyGreatsword>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Dirtball.MuddyGreatsword>()}, //other
					$"Dirtball has an extremely low chance of spawning if not defeated and any player's max health is over 100. It can also be manually summoned with a [i:{ModContent.ItemType<Items.Dirtball.CreepyMud>()}], which can be crafted or rarely dropped from enemies."
				);
				bossChecklist.Call(
					"AddBoss",
					6.75f,
					new List<int> { ModContent.NPCType<NPCs.Titan.TitanTankorb>() },
					this,
					"$Mods.Azercadmium.NPCName.TitanTankorb",
					(Func<bool>)(() => AzercadmiumWorld.downedTitan),
					ModContent.ItemType<Items.Titan.TitaniumEnergyCore>(),
					new List<int> { ModContent.ItemType<Items.Titan.TitanicEnergy>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Titan.TitanicEnergy>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Titan.AdamantiteEnergyCore>()}] or [i:{ModContent.ItemType<Items.Titan.TitaniumEnergyCore>()}]."
				);
				bossChecklist.Call(
					"AddBoss",
					9.25f,
					new List<int> { ModContent.NPCType<NPCs.Scavenger.MatrixScavenger>() },
					this,
					"$Mods.Azercadmium.NPCName.MatrixScavenger",
					(Func<bool>)(() => AzercadmiumWorld.downedScavenger),
					ModContent.ItemType<Items.Scavenger.FloppyDisc>(),
					new List<int> { ModContent.ItemType<Items.Scavenger.SoulofByte>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Scavenger.SoulofByte>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Scavenger.FloppyDisc>()}]."
				);
				bossChecklist.Call(
					"AddBoss",
					10.5f,
					new List<int> { ModContent.NPCType<NPCs.Empress.EmpressSlime>()},
					this,
					"$Mods.Azercadmium.NPCName.EmpressSlime",
					(Func<bool>)(() => AzercadmiumWorld.downedEmpress),
					ModContent.ItemType<Items.Empress.EmpressChalice>(),
					new List<int> { ModContent.ItemType<Items.Empress.EmpressShard>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Empress.EmpressShard>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Empress.EmpressChalice>()}]."
				);
			}
			JavelinCache = new bool[ProjectileLoader.ProjectileCount];
			JavelinCache[ProjectileID.JavelinFriendly] = true;
			JavelinCache[ProjectileID.BoneJavelin] = true;
			JavelinCache[ProjectileID.Daybreak] = true;
			JavelinCache[ProjectileID.TinyEater] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Wood.WoodenSplinter>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Corruption.DemoniteJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Crimson.CrimtaneJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Jungle.Snarevine>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.InfernalJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.HungeringJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.HungeringJavelin2>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Mech.France>()] = true;
			AzercadmiumUtils.Initialize();
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Basic Prehardmode Bar", new int[]
			{
			ItemID.CopperBar,
			ItemID.TinBar,
			ItemID.IronBar,
			ItemID.LeadBar,
			ItemType("ZincBar"),
			ItemID.SilverBar,
			ItemID.TungstenBar,
			ItemID.GoldBar,
			ItemID.PlatinumBar
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyPHBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
			{
			ItemID.Amethyst,
			ItemID.Topaz,
			ItemID.Sapphire,
			ItemID.Emerald,
			ItemID.Amber,
			ItemID.Diamond,
			ItemID.Ruby
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyGem", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Shadow Scale", new int[]
			{
			ItemID.ShadowScale,
			ItemID.TissueSample,
			});
			RecipeGroup.RegisterGroup("Azercadmium:AnyShadowScale", group);

			if (RecipeGroup.recipeGroupIDs.ContainsKey("IronBar")) {
				int index = RecipeGroup.recipeGroupIDs["IronBar"];
				group = RecipeGroup.recipeGroups[index];
				group.ValidItems.Add(ItemType("ZincBar"));
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.RecallPotion, 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MagicMirror);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.Pwnhammer);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.PocketMirror);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MechanicalWheelPiece);
			recipe.AddIngredient(ItemID.MechanicalWagonPiece);
			recipe.AddIngredient(null, "MechanicalGearPiece");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.MinecartMech);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "IronBand");
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofRegeneration);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "LeadBand");
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofRegeneration);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ZincBand");
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofRegeneration);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "IronBand");
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "LeadBand");
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ZincBand");
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldHelmet);
			recipe.AddIngredient(ItemID.Glass);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MiningHelmet);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldBar, 9);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Seashell);
			recipe.AddIngredient(ItemID.Starfish);
			recipe.AddIngredient(ItemID.Coral);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Trident);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Azercadmium:AnyPHBar", 5);
			recipe.AddRecipeGroup("Azercadmium:AnyGem");
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SlimeCrown);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 4);
			recipe.AddIngredient(ItemID.Hook);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeHook);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 4);
			recipe.AddIngredient(ItemID.Leather, 2);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimySaddle);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 3);
			recipe.AddRecipeGroup("IronBar", 7);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeGun);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SlimyCore", 3);
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(ItemID.SlimeStaff);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Cactus);
			recipe.AddIngredient(null, "BloodySpiderLeg");
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.ThornsPotion);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "Electrolight", 11);
			recipe.AddIngredient(ItemID.RainCloud, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.NimbusRod);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CopperPlatform", 2);
			recipe.SetResult(ItemID.CopperBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "TinPlatform", 2);
			recipe.SetResult(ItemID.TinBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "IronPlatform", 2);
			recipe.SetResult(ItemID.IronBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "LeadPlatform", 2);
			recipe.SetResult(ItemID.LeadBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "SilverPlatform", 2);
			recipe.SetResult(ItemID.SilverBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "TungstenPlatform", 2);
			recipe.SetResult(ItemID.TungstenBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "AlternateGoldPlatform", 2);
			recipe.SetResult(ItemID.GoldBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "PlatinumPlatform", 2);
			recipe.SetResult(ItemID.PlatinumBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.EmptyBullet, 50);
			recipe.AddIngredient(null, "Electrolight");
			recipe.SetResult(ItemID.HighVelocityBullet, 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.SnowBlock, 12);
			recipe.AddIngredient(ItemID.IceBlock, 8);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(ItemID.HandWarmer);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CocoaBeans");
			recipe.AddTile(TileID.DyeVat);
			recipe.SetResult(ItemID.BrownDye);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.Worm);
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddTile(TileID.Autohammer);
			recipe.SetResult(ItemID.TruffleWorm);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(null, "ZincOre");
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(ItemID.IronskinPotion);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "NeutronFragment", 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentSolar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "NeutronFragment", 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentVortex);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "NeutronFragment", 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentNebula);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "NeutronFragment", 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(ItemID.FragmentStardust);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CobaltBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.PalladiumBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.PalladiumBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.CobaltBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MythrilBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.OrichalcumBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.OrichalcumBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.MythrilBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.AdamantiteBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.TitaniumBar);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TitaniumBar);
			recipe.AddIngredient(null, "TitanicEnergy");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.AdamantiteBar);
			recipe.AddRecipe();
		}
		/*public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome && Main.LocalPlayer.ZoneRockLayerHeight)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/MicroUnder");
				priority = MusicPriority.BiomeHigh;
			}
			else if (Main.LocalPlayer.GetModPlayer<AzercadmiumPlayer>().ZoneMicrobiome)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/Micro");
				priority = MusicPriority.BiomeHigh;
			}
		}*/
		public override void Unload() {
			AzercadmiumUtils.Unload();
		}
	}
}