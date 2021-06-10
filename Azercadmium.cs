using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;
using Azercadmium.Textures;
using Azercadmium.Tiles.Tree;
using Azercadmium.Aaa;
using Azercadmium.UI;
using Azercadmium.Systems;
using Azercadmium.Tiles.Ember;

namespace Azercadmium
{
	public class Azercadmium : Mod
	{
        public static Mod Mod => ModLoader.GetMod("Azercadmium");
        public static bool[] JavelinCache;

		public const string ModPath = "Azercadmium/";

        public const int ashGrassMaxStyles = 7;

        public const int hellGrassMaxStyles = 11;

        public const int screenShaderAmount = 1;

        public static bool debug;

        public static bool loading;

        public static bool bothEvils;

        public static bool Devastation => TAZWorld.devastation;

        private bool mapDataInitialized;

        public const int ExtraTextureMax = 29;

        public static bool ClearedPreHardmodeVanilla => NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3 && NPC.downedQueenBee && NPC.downedGoblins;
        public static bool DownedAllMechBosses => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3;
        public static bool DownedAllPumpkinMoonBosses => NPC.downedHalloweenTree && NPC.downedHalloweenKing;
        public static bool DownedAllFrostMoonBosses => NPC.downedChristmasTree && NPC.downedChristmasSantank && NPC.downedChristmasIceQueen;

        public static bool BossActive { get; set; }

        public static bool clearSpecialDrawPoints;

        public static bool accHellTanker;

        public static bool accDevastationRemote;

        public static bool sTree;

        public static bool GameWorldRunning => !Main.gameInactive && !Main.gameMenu && !Main.gamePaused;

        public static bool[] ItemCastCache { get; set; }

        public static int[] NPCAITimerCache { get; set; }

        public static bool[] NPCNoEnviroDropsCache { get; set; }

        public static bool[] TileEmberGladesCache { get; set; }

        public static int hoveringOverIconSoundTimer;

        public static int sTreeHover;

        public static int[] NPCXPCache { get; set; }

        public static string hellTankerText = "";

        public static string devastationRemoteText = "";

        public static float[] screenShaderFade = new float[screenShaderAmount];

        public static Color[] screenShaderColor = new Color[screenShaderAmount];

        public static readonly Point InvalidPoint = new Point(-1, -1);

        public static readonly Rectangle InvalidRectangle = new Rectangle(-1, -1, -1, -1);

        public static Vector2 sTreeScreenPosition;
        public static int EmberGladesTileCount => TAZWorld.emberGladesTileCount;

        public static ModHotKey skillTreeKey;

        public static Ref<Effect> NoiseDye;

        public static Effect TintScreen;

        public Effect VertexShader;

        public static Azercadmium Instance { get; set; }

        public static AZConfigClient clientConfigInstance { get; set; }

        public static AzercadmiumConfig serverConfigInstance { get; set; }

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D[] extraTexture;

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D[] mapBGTexture;

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D sTreeTexture;

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D devStarTexture;

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D pixle;

        [Obsolete("Replaced with TextureHelper")]
        public static Texture2D[] chainTexture;

       // public static TilewandUI tileWandUI;

        //public static NecroniusCarverUI necroniusCarverUI;

        public static List<Point> specialTileDrawPoints { get; set; }

        /// <summary>
        /// A list of all the registered mod thorns
        /// </summary>
        public static List<ThornInfo> ThornInfo { get; set; }

        /// <summary>
        /// A list of all the registered plants
        /// </summary>
        public static List<PlantInfo> PlantInfo { get; set; }

        //public static List<STreeUI> sTreeUIs;

        public static bool OnScreen(Vector2 screenPosition, float padding = 0) => screenPosition.X >= -padding && screenPosition.X <= Main.screenWidth + padding && screenPosition.Y >= -padding && screenPosition.Y <= Main.screenHeight + padding;

        public static int DamageRange(int damage) => (int)(damage * Main.rand.NextFloat(0.85f, 1.15f));
		public Azercadmium()
		{
			
		}
		public static void NetTile(int i, int j, int size = 1, int whoAmI = -1, TileChangeType tileChangeType = TileChangeType.None)
        {
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(whoAmI, i, j, 1, tileChangeType);
        }

        public static void BeginDrawingTiles()
            => Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.ZoomMatrix);

        public static void BeginProjectileShaderDraw()
            => Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);

        public static void BeginProjectileDraw()
            => Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);

        public static void DrawTile(Texture2D texture, int i, int j, Rectangle rectangle, Color color, float rotation = 0f, Vector2 origin = default(Vector2), float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Vector2 offset = default(Vector2))
        {
            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange, Main.offScreenRange);
            Main.spriteBatch.Draw(texture, new Vector2(i * 16, j * 16) - Main.screenPosition + offset + zero, rectangle, color, rotation, origin, scale, effects, layerDepth);
        }

        public static void DrawTile2(Texture2D texture, int i, int j, Rectangle rectangle, Color color, float rotation = 0f, Vector2 origin = default(Vector2), float scale = 1f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0f, Vector2 offset = default(Vector2))
            => Main.spriteBatch.Draw(texture, new Vector2(i * 16, j * 16) - Main.screenPosition + offset, rectangle, color, rotation, origin, scale, effects, layerDepth);

        public static void SetFloatsToVector2(Vector2 vector, ref float valueX, ref float valueY)
        {
            valueX = vector.X;
            valueY = vector.Y;
        }

        /// <summary>
        /// Rarity color used for Developer items
        /// </summary>
        public static readonly Color DeveloperColor = new Color(116, 179, 237);

        /// <summary>
        /// Color for things like <c>Boss has awoken</c>
        /// </summary>
        public static readonly Color BossColor = new Color(171, 64, 255);

        /// <summary>
        /// Color for items with a rarity of 12
        /// </summary>
        public static readonly Color Magenta = new Color(255, 10, 255);

        [Obsolete("Replaced with magenta")]
        public static readonly Color ForestGreen = new Color(11, 102, 35);

        /// <summary>
        /// Color from Nalyddd's previous mod attempts...
        /// </summary>
        public static Color Narrotol => ColorLerp(new Color[] { new Color(240, 200, 255), new Color(220, 120, 255), new Color(180, 80, 255), new Color(220, 120, 255), }, 30f, 0f);

        /// <summary>
        /// A repeating color that is used in most Ember Glade's glow masks in order to make a pulse effect
        /// </summary>
        public static Color EmberGladesPulseColor => Color.White * 0.8f * (float)((Math.Sin(Main.GlobalTime * 100 % MathHelper.Pi) + 1) * 0.45f);

        /// <summary>
        /// Color for Devastation rarity items
        /// </summary>
        public static Color MintChocolateRarity => Color.Lerp(new Color(146, 255, 138), new Color(97, 56, 10), (float)(Math.Sin(Main.GlobalTime * 10 % MathHelper.Pi) + 1) / 2);

        public static Color ColorLerp(Color[] colors, float time = 30f, float offset = 0f)
        {
            float c = 1f / time;
            int i = (int)(Main.GlobalTime * 60 + offset);
            int index = (int)(i * c % colors.Length);
            return Color.Lerp(colors[index], colors[(index + 1) % colors.Length], i * c % 1);
        }

        public static Color MovingRainbow(float time = 30, float offset = 0f)
        {
            return ColorLerp(new Color[]
            {
                Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Violet, Color.Magenta,
            },
            time, offset);
        }

        public static Vector2 ShootTowards(Vector2 pos1, Vector2 pos2, float speed) => Vector2.Normalize(pos1 - pos2) * speed;

        public static SpriteEffects DirectionToSpriteEffects(int direction) => direction < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

        public static void BroadcastText(object text, Color color)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromKey(text.ToString()), color);
            }
            else if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(Language.GetTextValue(text.ToString()), color);
            }
        }
		public override void Load()
        {
            loading = true;
            Instance = this;
            ThornInfo = new List<ThornInfo>();
            PlantInfo = new List<PlantInfo>();
            AZTreeLoader.trees = new Dictionary<int, AZTree>();
            AZTreeLoader.saplings = new List<int>();
            skillTreeKey = RegisterHotKey("Skill Tree", "N");
            /*if (Main.netMode != NetmodeID.Server && !Main.dedServ)
            {
                tileWandUI = new TilewandUI();
                tileWandUI.SetDefaults();
                necroniusCarverUI = new NecroniusCarverUI();
                necroniusCarverUI.SetDefaults();
                sTreeUIs = new List<STreeUI>
                {
                    new STreeUI(STreeUIType.Stardust, "Increases summon damage by 5%", delegate (Player player)
                    {
                        player.minionDamageMult += 0.05f;
                    }),
                    new STreeUI(STreeUIType.Solar, "Increases melee damage by 5%", delegate (Player player)
                    {
                        player.meleeDamageMult += 0.05f;
                    }),
                    new STreeUI(STreeUIType.Vortex, "Increases ranged damage by 5%", delegate (Player player)
                    {
                        player.rangedDamageMult += 0.05f;
                    }),
                    new STreeUI(STreeUIType.Nebula, "Increases magic damage by 5%", delegate (Player player)
                    {
                        player.magicDamageMult += 0.05f;
                    })
                };*/
                //DevastationManager.AddStars();
                HotbarUI.instances = new List<HotbarUI>();
                HotbarUI.outline = ModContent.GetTexture("Azercadmium/UI/HotbarUIOutline");
                screenShaderFade = new float[screenShaderAmount];
                screenShaderColor = new Color[screenShaderAmount];
                specialTileDrawPoints = new List<Point>();
                extraTexture = new Texture2D[ExtraTextureMax];
                for (int i = 0; i < ExtraTextureMax; i++)
                {
                    extraTexture[i] = ModContent.GetTexture("Azercadmium/Extras/Extra_" + i);
                }
                mapBGTexture = new Texture2D[1];
                mapBGTexture[0] = ModContent.GetTexture("Azercadmium/Extras/EmberGladesMapBG");
                //sTreeTexture = ModContent.GetTexture("Azercadmium/SkillTree");
                //DevastationManager.popupTexture = ModContent.GetTexture("Azercadmium/PointPopup");
                //devStarTexture = ModContent.GetTexture("Azercadmium/SkillTreeStar");
                //pixle = ModContent.GetTexture("Azercadmium/Pixle");
                /*CarnivorousPlant.chainTexture = new Texture2D[CarnivorousPlant.maxChains];
                for (int i = 0; i < CarnivorousPlant.maxChains; i++)
                {
                    CarnivorousPlant.chainTexture[i] = ModContent.GetTexture("Azercadmium/NPCs/Chain" + i);
                }*/
                chainTexture = new Texture2D[3];
                for (int i = 0; i < 3; i++)
                {
                    chainTexture[i] = ModContent.GetTexture("Azercadmium/Textures/Chain" + i);
                }
                TextureContainer.invisible = GetTexture("Textures/Invisible");
                TextureContainer.pixle = GetTexture("Textures/Pixle");
                TextureContainer.popupTexture = GetTexture("Textures/PointPopup");
                TextureContainer.chain = new Texture2D[3];
                for (int i = 0; i < 3; i++)
                {
                    TextureContainer.chain[i] = GetTexture("Textures/Chain" + i);
                }
                TextureContainer.mapBG = new Texture2D[1];
                for (int i = 0; i < 1; i++)
                {
                    TextureContainer.mapBG[i] = GetTexture("Textures/MapBG" + i);
                }
                TextureContainer.skillTreeUI = new Texture2D[1];
                for (int i = 0; i < 1; i++)
                {
                    TextureContainer.skillTreeUI[i] = GetTexture("Textures/SkillTree" + i);
                }
                TextureContainer.skillTreeStar = new Texture2D[1];
                for (int i = 0; i < 1; i++)
                {
                    TextureContainer.skillTreeUI[i] = GetTexture("Textures/SkillTreeStar" + i);
                }
                TextureContainer.trailTextures = new Texture2D[TextureContainer.trailTexturesCount];
                TextureContainer.trailTextures[0] = GetTexture("Textures/TrailTextures/GSNoise");
                TextureContainer.trailTextures[1] = GetTexture("Textures/TrailTextures/Perlin");
                TextureContainer.trailTextures[2] = GetTexture("Textures/TrailTextures/Trail1");
                TextureContainer.trailTextures[3] = GetTexture("Textures/TrailTextures/Trail2");
                TextureContainer.trailTextures[4] = GetTexture("Textures/TrailTextures/Trail3");
                TextureContainer.trailTextures[5] = GetTexture("Textures/TrailTextures/Trail4");
                TextureContainer.algaeConnecter = new Texture2D[TextureContainer.algaeConnecterCount];
                for (int i = 0; i < TextureContainer.algaeConnecterCount; i++)
                {
                    TextureContainer.algaeConnecter[i] = GetTexture("Textures/Algae/AlgaeConnecter" + i);
                }
                TextureContainer.segment = new Texture2D[TextureContainer.segmentCount];
                for (int i = 0; i < TextureContainer.segmentCount; i++)
                {
                    TextureContainer.segment[i] = GetTexture("Textures/Segments/Segment" + i);
                }
                TintScreen = GetEffect("Effects/TintScreen");
                Filters.Scene["TintScreen"] = new Filter(new ScreenShaderData(new Ref<Effect>(TintScreen), "TintPass"), EffectPriority.High);
                Filters.Scene["TintScreen"].Load();
                NoiseDye = new Ref<Effect>(GetEffect("Effects/NoiseTest"));
                //GameShaders.Armor.BindShader(ModContent.ItemType<LoudDye>(), new ArmorShaderData(NoiseDye, "NoiseTesting").UseColor(Color.LightSalmon).UseSecondaryColor(Color.Blue).UseImage("Terraria/Misc/Noise"));
                VertexShader = GetEffect("Effects/Trailshader");
            }
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call(
					"AddBoss",
					2.33f,
					new List<int> { ModContent.NPCType<NPCs.Dirtball.Dirtball>() },
					this,
					"$Mods.Azercadmium.NPCName.Dirtball",
					(Func<bool>)(() => AzercadmiumWorld.downedDirtball),
					ModContent.ItemType<Items.Dirtball.CreepyMud>(),
					new List<int> { ModContent.ItemType<Items.Dirtball.MuddyGreatsword>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Dirtball.MuddyGreatsword>()}, //other
					$"Dirtball has an extremely low chance of spawning if not defeated and any player's max health is 300 or more. It can also be manually summoned with a [i:{ModContent.ItemType<Items.Dirtball.CreepyMud>()}], which can be crafted or rarely dropped from enemies."
				);
				bossChecklist.Call(
					"AddBoss",
					6.75f,
					new List<int> { ModContent.NPCType<NPCs.Titan.TitanTankorb>() },
					this,
					"$Mods.Azercadmium.NPCName.TitanTankorb",
					(Func<bool>)(() => AzercadmiumWorld.downedTitan),
					ModContent.ItemType<Items.Titan.TitansCapsule>(),
					new List<int> { ModContent.ItemType<Items.Titan.TitanicEnergy>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Titan.TitanicEnergy>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Titan.TitansCapsule>()}]."
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
            JavelinCache[ProjectileID.FrostDaggerfish] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Wood.WoodenSplinter>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Corruption.DemoniteJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Crimson.CrimtaneJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Jungle.Snarevine>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.InfernalJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.HungeringJavelin>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Underworld.HungeringJavelin2>()] = true;
			JavelinCache[ModContent.ProjectileType<Projectiles.Mech.France>()] = true;
            JavelinCache[ModContent.ProjectileType<Projectiles.Ember.CinderCedarJavelin>()] = true;
			TileEmberGladesCache = new bool[TileLoader.TileCount];
            TileEmberGladesCache[ModContent.TileType<EmberGrass>()] = true;
            TileEmberGladesCache[ModContent.TileType<EmberThornTile>()] = true;
            ItemCastCache = new bool[ItemLoader.ItemCount];
            NPCAITimerCache = new int[NPCLoader.NPCCount];
            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                NPCAITimerCache[i] = 4;
            }
            NPCAITimerCache[NPCID.EyeofCthulhu] = 5;
            NPCNoEnviroDropsCache = new bool[NPCLoader.NPCCount];
            NPCNoEnviroDropsCache[NPCID.ServantofCthulhu] = true;
            NPCNoEnviroDropsCache[NPCID.EaterofWorldsHead] = true;
            NPCNoEnviroDropsCache[NPCID.EaterofWorldsBody] = true;
            NPCNoEnviroDropsCache[NPCID.EaterofWorldsTail] = true;
            NPCNoEnviroDropsCache[NPCID.MeteorHead] = true;
            NPCNoEnviroDropsCache[NPCID.BurningSphere] = true;
            NPCNoEnviroDropsCache[NPCID.WaterSphere] = true;
            NPCNoEnviroDropsCache[NPCID.ChaosBall] = true;
            NPCNoEnviroDropsCache[NPCID.VileSpit] = true;
            NPCNoEnviroDropsCache[NPCID.Slimer] = true;
            NPCNoEnviroDropsCache[NPCID.ShadowFlameApparition] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernHead] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernBody] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernBody2] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernBody3] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernLegs] = true;
            NPCNoEnviroDropsCache[NPCID.WyvernTail] = true;
            NPCNoEnviroDropsCache[NPCID.SlimeSpiked] = true;
            NPCNoEnviroDropsCache[NPCID.BlueSlime] = true;
            NPCNoEnviroDropsCache[ModContent.NPCType<NPCs.Empress.CrownSlime>()] = true;
            NPCXPCache = new int[NPCLoader.NPCCount];
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

			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 15);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.LihzahrdPowerCell);
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
		public override void PostAddRecipes() => loading = false;
		public override void Unload() {
			Instance = null;
            clientConfigInstance = null;
            serverConfigInstance = null;
            PlantInfo = null;
            PlantInfo = null;
            extraTexture = null;
            ItemCastCache = null;
            NPCAITimerCache = null;
            NPCNoEnviroDropsCache = null;
            TileEmberGladesCache = null;
            screenShaderFade = null;
            screenShaderColor = null;
            //tileWandUI = null;
           // necroniusCarverUI = null;
            mapBGTexture = null;
            //sTreeTexture = null;
            //sTreeUIs = null;
            devStarTexture = null;
            TextureContainer.chain = null;
            TextureContainer.invisible = null;
            TextureContainer.mapBG = null;
            TextureContainer.pixle = null;
            TextureContainer.popupTexture = null;
            TextureContainer.skillTreeStar = null;
            TextureContainer.skillTreeUI = null;
            TextureContainer.trailTextures = null;
            TextureContainer.algaeConnecter = null;
            TextureContainer.segment = null;
            AZTreeLoader.trees = null;
            AZTreeLoader.saplings = null;
			AzercadmiumUtils.Unload();
		}
		public override object Call(params object[] args)
        {
            string callType = (string)args[0];
            Mod mod = (Mod)args[1];
            switch (callType)
            {
                /*case "Azercadmium:Ember Glades:EmberGlades Setup":
                return NalydPlus_EmberGlades_TeleporterSetup(args[2] as Player);            
                case "Azercadmium:Ember Glades:EmberGlades Teleport":
                NalydPlus_EmberGlades_Teleporting(args[2] as Player);
                break;*/
                case "Hell Weather:UpdateInfoOnce_active":
                accHellTanker = Main.LocalPlayer.ModPlayer().hellTanker;
                return accHellTanker;
                case "Hell Weather:UpdateInfoOnce_text":
                return null;
                case "Hell Weather:UpdateInfo_text":
                {
                    int windSpeed = (int)HellWind.VisibleWindSpeed;
                    if (windSpeed == 0)
                    {
                        hellTankerText = "No wind";
                        return hellTankerText;
                    }
                    int speed = (int)HellWind.VisibleWindSpeed;
                    string dir = speed > 0 ? "E" : "W";
                    hellTankerText = $"{speed}mph {dir}";
                }
                return hellTankerText;
                case "Devastation Points:UpdateInfoOnce_active":
                accHellTanker = Main.LocalPlayer.ModPlayer().hellTanker;
                return accHellTanker;
                case "Devastation Points:UpdateInfoOnce_text":
                return null;
                case "Devastation Points:UpdateInfo_text":
                {
                    int points = 0;
                    return points + " points";
                }
            }
            return null;
        }
		//public override void UpdateUI(GameTime gameTime) => tileWandUI.Update();//necroniusCarverUI.Update();//necroniusCarverUI.active = true;

        private bool CanSpawnAlgae()
        {
            Vector2 pos = Main.MouseWorld;
            int npcWidth = 34;
            int npcHeight = 34;
            int length = 12;
            bool @return = true;
            bool allFalse = false;
            if (!Collision.CanHitLine(pos, npcWidth, npcHeight, pos - new Vector2(npcHeight * length), npcWidth, npcHeight))
            {
                allFalse = true;
                @return = false;
            }
            for (int i = 0; i < length; i++)
            {
                Vector2 npcPos = pos - new Vector2(0, npcHeight * i);
                bool noWater = false;
                if (!Collision.WetCollision(npcPos, npcWidth, npcHeight))
                {
                    noWater = true;
                    @return = false;
                }
                Color drawColor = new Color(1f, (allFalse ? 0f : 0.5f) + (noWater ? 0f : 0.5f), (allFalse ? 0.5f : 0f) + (noWater ? 0.5f : 0f), (allFalse ? 0.5f : 0f) + (noWater ? 0.5f : 0f));
                Main.spriteBatch.Draw(TextureContainer.pixle, npcPos - Main.screenPosition, null, drawColor, 0f, Vector2.Zero, new Vector2(npcWidth, npcHeight), SpriteEffects.None, 0f);
            }
            return @return;
        }
		public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (!mapDataInitialized)
            {
                accHellTanker = Main.LocalPlayer.ModPlayer().hellTanker;
            }
        }

        public override void MidUpdateNPCGore()
        {
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
        }

        public override void PostUpdateEverything()
        {
            BossActive = false;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active)
                {
                    if (npc.boss || npc.type == NPCID.EaterofWorldsHead)
                    {
                        BossActive = true;
                    }
                }
            }
            if (!Main.mapFullscreen)
            {
                mapDataInitialized = false;
            }
            if (hoveringOverIconSoundTimer > 0)
            {
                hoveringOverIconSoundTimer--;
            }
            sTreeHover = -1;
            TAZWorld.GenerateThorns();
        }

        /// <summary>
        /// Find the closest NPC from a point. Defaults to -1
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>The index of the NPC chosen</returns>
        public static int ClosestHostileNPC(Vector2 pos, int width = 16, int height = 16, float seeingDist = float.MaxValue, bool seeThroughWalls = false)
        {
            int currentIndex = -1;
            float currentDist = seeingDist;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && !npc.townNPC && npc.lifeMax > 5 && !npc.dontTakeDamage)
                {
                    Vector2 nCenter = npc.Center;
                    float dist = Vector2.Distance(pos, npc.Center);
                    if (dist < currentDist && (seeThroughWalls || Collision.CanHitLine(pos, width, height, npc.position, npc.width, npc.height)))
                    {
                        currentDist = dist;
                        currentIndex = i;
                    }
                }
            }
            return currentIndex;
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
			{
				return;
			}
			if (Main.LocalPlayer.GetModPlayer<TAZPlayer>().ZoneEmberGlades)
			{
				Mod azercadmiumMusic = ModLoader.GetMod("AzercadmiumMusic");
			    if (azercadmiumMusic != null) 
				    music = azercadmiumMusic.GetSoundSlot(SoundType.Music, "Sounds/Music/Prism");
			    else 
				    music = MusicID.Hell;
				priority = MusicPriority.Environment;
			}
		}
	}
}