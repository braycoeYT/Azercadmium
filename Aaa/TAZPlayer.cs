using Azercadmium.Tiles.Ember;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Azercadmium.Aaa
{
    public class TAZPlayer : ModPlayer
    {
        private bool NamedNalyd { get; set; }

        public bool editwandNPCMode;

        public int editwandNPCHover = -1;

        public int editwandNPCSelect = -1;

        public bool editwandNPC_behindTiles;

        public bool editwandWingTooltip;

        public int editwand_swingTest;

        public bool givenDevastationRemote;

        public bool hoveringOverUI;

        public bool namedGifts;

        public bool nalydPumpkinPet;

        public bool marblePet;

        public bool braycoeSlimePet;

        public bool dirtboiPet;

        public bool sandTrapPet;

        public bool charredProj;

        public bool batCooldown;

        public bool charred;

        public bool fisg;

        public bool dirtSlime;

        public bool floatingCobaltOreMinion;

        public bool floatingAdamantiteOreMinion;

        public bool funkScytheMinion;

        public bool burningMossHornetMinion;

        public bool hellTanker;

        public bool overwrathMask;

        public bool bloomOfLife;

        public bool upgradeMeatball;

        public bool slimyCore;

        public bool portalofLight;

        public bool portalofLightVanity;

        public bool dioProtection;

        public bool dioProtectionHidden;

        public int spiceMedallion;

        public bool portalofNight;

        public bool magicMusketPouch;

        public bool antifreeze;

        public bool burningSkin;

        private bool zoneEmberGlades;

        private readonly bool zoneOblivion;

        private readonly bool zoneMicrobiome;

        public bool ZoneEmberGlades => zoneEmberGlades;

        public bool ZoneOblivion => zoneOblivion;

        public bool ZoneMicrobiome => zoneMicrobiome;

        public int devPoint;

        public int cinderCedarBowMode;

        public static bool IsWet(Player player) => player.wet || player.lavaWet || player.honeyWet;

        private bool IsWet() => player.wet || player.lavaWet || player.honeyWet;

        public static byte GetClosestActiveAndNotDeadTarget(Vector2 pos, float minDist = 1000)
        {
            byte closest = 0;
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                float _dist = Vector2.Distance(pos, player.Center);
                if (_dist < minDist && player.active && !player.dead)
                {
                    closest = (byte)i;
                    minDist = _dist;
                }
            }
            return closest;
        }

        public static TAZPlayer Get(Player player) => player.GetModPlayer<TAZPlayer>();

        public static Vector2 GetEmberGladesTeleportPosition()
        {
            int halfMaxTiles = Main.maxTilesX / 2;
            bool left = Main.dungeonX < halfMaxTiles;
            int emberGrassTileType = ModContent.TileType<EmberGrass>();
            for (int _i = 0; _i < halfMaxTiles; _i++)
            {
                int i = left ? _i + halfMaxTiles : halfMaxTiles - _i;
                for (int j = Main.maxTilesY - 200; j < Main.maxTilesY; j++)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    if (tile.active() && tile.type == emberGrassTileType)
                    {
                        Rectangle nearby = (new Rectangle(i - 1, j - 3, 3, 3));
                        bool safe = true;
                        for (int k = nearby.X; k < nearby.X + nearby.Width; k++)
                        {
                            for (int l = nearby.Y; l < nearby.Y + nearby.Height; l++)
                            {
                                Tile tile2 = Framing.GetTileSafely(k, l);
                                if (tile2.active() && Main.tileSolid[tile2.type] || tile2.lava())
                                {
                                    safe = false;
                                    break;
                                }
                            }
                        }
                        if (safe)
                        {
                            bool foundTile = false;
                            for (int k = j; k > j - 300; k--)
                            {
                                Tile tile2 = Framing.GetTileSafely(i, k);
                                if (tile2.active() && (tile2.type == TileID.LihzahrdBrick || tile2.type == TileID.JungleGrass || tile2.type == TileID.JunglePlants || tile2.type == TileID.JungleThorns || tile2.type == TileID.JungleVines))
                                {
                                    foundTile = true;
                                    break;
                                }
                            }
                            if (foundTile)
                            {
                                return new Vector2(i * 16, (j - 3) * 16);
                            }
                        }
                    }
                }
            }
            return Vector2.Zero;
        }

        public static void SetSpiceMedallionLevel(TAZPlayer player, int level)
        {
            if (level > player.spiceMedallion)
            {
                player.spiceMedallion = level;
            }
        }

        /*public override void OnEnterWorld(Player player)
        {
            if (player.name.Equals("Braycoe"))
            {
                Main.NewText("Hello Braycoe", new Color(255, 255, 10));
            }
            if (NamedNalyd = player.name.Equals("Nalyd T."))
            {
                if (!namedGifts)
                {
                    namedGifts = true;
                    player.inventory[0] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<Narrizuul>());
                    player.inventory[2] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<NalydTilewand>());
                    player.inventory[1] = AzercadmiumGlobalItem.GetItem(ItemID.RodofDiscord);
                    player.inventory[3] = AzercadmiumGlobalItem.GetItem(ItemID.NebulaPickaxe);
                    player.inventory[4] = AzercadmiumGlobalItem.GetItem(ItemID.TheAxe);
                    player.inventory[49] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<NalydStatue>());
                    player.armor[3] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<NalydWings>());
                    player.armor[4] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<PortalofLight>());
                    player.armor[10] = AzercadmiumGlobalItem.GetItem(ItemID.LamiaHat);
                    player.armor[11] = AzercadmiumGlobalItem.GetItem(ItemID.ApprenticeAltShirt);
                    player.armor[12] = AzercadmiumGlobalItem.GetItem(ItemID.VortexLeggings);
                    player.armor[13] = AzercadmiumGlobalItem.GetItem(ItemID.AnkhShield);
                    player.dye[0] = AzercadmiumGlobalItem.GetItem(ItemID.ShadowflameHadesDye);
                    player.dye[1] = AzercadmiumGlobalItem.GetItem(ItemID.ShadowflameHadesDye);
                    player.dye[2] = AzercadmiumGlobalItem.GetItem(ItemID.ShadowflameHadesDye);
                    player.dye[3] = AzercadmiumGlobalItem.GetItem(ItemID.ShadowflameHadesDye);
                    player.miscEquips[0] = AzercadmiumGlobalItem.GetItem(ModContent.ItemType<NalydPumpkin>());
                    Main.NewText("Hello Nalyd... looks like you were looking for these", new Color(255, 255, 10));
                }
            }
        }*/

        public override TagCompound Save()
        {
            //TileWandSaveInfo tileWandSaveInfo = Azercadmium.tileWandUI.GetSave();
            //string tileWandInfo_Mode = tileWandSaveInfo.mode;
            //bool tileWandInfo_HoverGlow = tileWandSaveInfo.hoverGlow;
            return new TagCompound()
            {
                ["nalydGifts"] = namedGifts,
                //["tileWandInfo_Mode"] = tileWandInfo_Mode,
                //["tileWandInfo_HoverGlow"] = tileWandInfo_HoverGlow,
                ["cinderCedarBowMode"] = cinderCedarBowMode,
            };
        }

        public override void Load(TagCompound tag)
        {
            namedGifts = tag.GetBool("nalydGifts");
            cinderCedarBowMode = tag.GetInt("cinderCedarBowMode");
            //Azercadmium.tileWandUI.Load(tag);
        }

        public override void ResetEffects()
        {
            floatingAdamantiteOreMinion = false;
            floatingCobaltOreMinion = false;
            funkScytheMinion = false;
            burningMossHornetMinion = false;
            overwrathMask = false;
            bloomOfLife = false;
            antifreeze = false;
            portalofLight = NamedNalyd;
            portalofLightVanity = NamedNalyd;
            burningSkin = false;
            nalydPumpkinPet = false;
            marblePet = false;
            braycoeSlimePet = false;
            dirtboiPet = false;
            upgradeMeatball = false;
            slimyCore = false;
            hellTanker = false;
            batCooldown = false;
            dioProtection = false;
            dioProtectionHidden = false;
            spiceMedallion = 0;
            portalofNight = false;
            charredProj = false;
            charred = false;
            sandTrapPet = false;
            if (!editwandNPCMode || editwandNPCSelect > 0 && !Main.npc[editwandNPCSelect].active)
            {
                if (editwandNPCSelect > 0)
                {
                    Main.npc[editwandNPCSelect].behindTiles = editwandNPC_behindTiles;
                }
                editwandNPCSelect = -1;
                editwandNPC_behindTiles = false;
            }
            // 0 - 2 = armor
            // 3 - 10 = accessories 
            // 11 - 13 = vanity armor
            // 14 - 21 = vanity accessories
            /*for (int i = 0; i < player.armor.Length; i++)
            {
                Item equip = player.armor[i];
                if (i >= 13)
                {
                    if (!portalofLight && !portalofLightVanity)
                    {
                        if (equip.type == ModContent.ItemType<PortalofLight>())
                        {
                            portalofLight = true;
                            portalofLightVanity = true;
                        }
                        else if (equip.type == ModContent.ItemType<PortalofNight>())
                        {
                            portalofNight = true;
                            portalofLightVanity = true;
                        }
                    }
                }
            }*/
            dirtSlime = false;
            fisg = false;
        }
        public override void UpdateDead() {
            burningSkin = false;
            charred = false;
        }
        public override void UpdateBadLifeRegen() {
            if (burningSkin) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 20;
			}
            if (charred) {
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 20;
			}
        }
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
			if (charred || burningSkin) {
				if (Main.rand.NextBool(4) && drawInfo.shadow == 0f) {
					int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 259, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					Main.playerDrawDust.Add(dust);
				}
				r *= 0.5f;
				g *= 0.1f;
				b *= 0.1f;
				fullBright = true;
			}
		}
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Azercadmium.skillTreeKey.JustPressed)
            {
                Main.PlaySound(SoundID.MenuTick);
                Azercadmium.sTree = !Azercadmium.sTree;
            }
        }

        public override void SetControls()
        {
            const float sTreeUISpeed = 5f;
            if (Azercadmium.sTree)
            {
                if (player.controlDown)
                {
                    Azercadmium.sTreeScreenPosition.Y -= sTreeUISpeed;
                }
                player.controlDown = false;
                if (player.controlUp)
                {
                    Azercadmium.sTreeScreenPosition.Y += sTreeUISpeed;
                }
                player.controlUp = false;
                if (player.controlLeft)
                {
                    Azercadmium.sTreeScreenPosition.X += sTreeUISpeed;
                }
                player.controlLeft = false;
                if (player.controlRight)
                {
                    Azercadmium.sTreeScreenPosition.X -= sTreeUISpeed;
                }
                player.controlRight = false;
                player.controlJump = false;
                player.controlHook = false;
                player.controlMount = false;
                player.controlQuickHeal = false;
                player.controlQuickMana = false;
                player.controlSmart = false;
                player.controlThrow = false;
                player.controlTorch = false;
                player.controlUseItem = false;
                player.controlUseTile = false;
                if (player.controlMap || player.controlInv)
                {
                    Azercadmium.sTree = false;
                }
            }
        }
        public override void UpdateBiomes()
        {
            zoneEmberGlades = Azercadmium.EmberGladesTileCount > 100;
        }

        public override void UpdateBiomeVisuals()
        {
            Azercadmium.screenShaderColor = new Color[] { Color.Lerp(Color.OrangeRed, Color.Orange, (float)(Math.Sin(Main.GameUpdateCount * 0.001f) + 1) * 0.5f), };
            bool honeyCrispAlive = false;
            float emberGladesBossEffectAmount = 0f;
            List<int> importantNPCs = new List<int>();
            //int honeyCrisp = ModContent.NPCType<EmberHoneycrisp>();
            //int heletron = ModContent.NPCType<Heletron>();
            /*for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active)
                {
                    if (npc.type == honeyCrisp || npc.type == heletron)
                    {
                        honeyCrispAlive = true;
                        float effectAmount = MathHelper.Clamp((2000 - Math.Abs(Vector2.Distance(player.Center, npc.Center))) * 0.001f, 0f, 1f);
                        emberGladesBossEffectAmount = effectAmount > emberGladesBossEffectAmount ? effectAmount : emberGladesBossEffectAmount;
                        importantNPCs.Add(npc.whoAmI);
                    }
                }
            }*/
            float countMult = 0.0125f;
            float lerpAmount = 0.022f;
            float shaderMax = honeyCrispAlive ? MathHelper.Clamp((float)(Math.Sin(Main.GameUpdateCount * countMult) + 1) * 0.125f, 0.125f, 0.25f) : 0.1f;
            float opacityLerp2 = MathHelper.Clamp((Azercadmium.EmberGladesTileCount - 100) / 200f, 0f, 1f) + emberGladesBossEffectAmount;
            Azercadmium.screenShaderFade[0] = MathHelper.Lerp(Azercadmium.screenShaderFade[0], MathHelper.Clamp(opacityLerp2, 0, shaderMax), lerpAmount);
            if (Azercadmium.screenShaderFade[0] > 0)
            {
                ScreenShaderData shader = Filters.Scene["TintScreen"].GetShader();
                shader.UseOpacity(Azercadmium.screenShaderFade[0]);
                shader.UseColor(Azercadmium.screenShaderColor[0]);
                if (!Filters.Scene["TintScreen"].Active)
                {
                    Filters.Scene.Activate("TintScreen");
                }
            }
            else
            {
                Filters.Scene.Deactivate("TintScreen");
            }
            if (emberGladesBossEffectAmount > 0)
            {
                int randNum = (int)(105 - emberGladesBossEffectAmount * 100f);
                Point dustPoint = (player.Center - new Vector2(1000, 1000)).ToPoint();
                Rectangle emberRectangle = new Rectangle(dustPoint.X, dustPoint.Y, 2000, 2000);
                if (WorldGen.genRand.NextBool(randNum))
                {
                    Dust.NewDust(new Vector2(WorldGen.genRand.Next(emberRectangle.X, emberRectangle.X + emberRectangle.Width), WorldGen.genRand.Next(emberRectangle.Y, emberRectangle.Y + emberRectangle.Height)), 2, 2, DustID.FlameBurst);
                }
                if (WorldGen.genRand.NextBool(randNum))
                {
                    Dust.NewDust(new Vector2(WorldGen.genRand.Next(emberRectangle.X, emberRectangle.X + emberRectangle.Width), WorldGen.genRand.Next(emberRectangle.Y, emberRectangle.Y + emberRectangle.Height)), 2, 2, DustID.FlameBurst);
                }
            }
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneEmberGlades && player.ZoneUnderworldHeight)
            {
                return Azercadmium.mapBGTexture[0];
            }
            return null;
        }

        public override void PreUpdateBuffs()
        {
            if (player.lavaWet && zoneEmberGlades)
            {
                player.AddBuff(ModContent.BuffType<Buffs.Debuffs.BurningSkin>(), 4);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (overwrathMask)
            {
                if (IsWet())
                {
                    player.wingTime = player.wingTimeMax;
                    Lighting.AddLight(player.MountedCenter, new Vector3(3f, 3f, 3f));
                }
                else
                {
                    Lighting.AddLight(player.MountedCenter, new Vector3(0.75f, 0.75f, 0.75f));
                }
            }
            Point playerTileWorld = player.MountedCenter.ToTileCoordinates();
            for (int i = playerTileWorld.X; i < playerTileWorld.X + 3; i++)
            {
                for (int j = playerTileWorld.Y; j < playerTileWorld.Y + 3; j++)
                {
                    if (new Rectangle((i - 1) * 16, (j - 1) * 16, 16, 16).Intersects(player.getRect()))
                    {
                        ThornInfo? thornInfo = TAZWorld.GetThorn(i - 1, j - 1);
                        if (thornInfo != null)
                        {
                            thornInfo.Value.damageMethod(player, i - 1, j - 1, thornInfo.Value.damage);
                        }
                    }
                }
            }
        }

        //
        // power is seemingly always 300 so don't use it. I have never seen it be a different number after debugging for hours
        //
        // liquidType is basically this:
        // 0 = water
        // 1 = lava
        // 2 = honey
        //
        // poolSize is normally about 10 - 50 so balance normal fishing stuff carefully
        //
        // worldlayer is kinda useless its just a way to use stuff like player.ZoneRockLayer except with magic numbers
        // worldLayer is only good for stuff like:
        // if (worldLayer <= 4 && worldLayer => 2)
        //
        // questFish is the item type of the quest fish
        //
        // caught type is the item caught from fishing
        // 
        // Idk what junk is for. I never tested it. 
        // Its obviously related to the junk items but why is it a ref bool and not a regular bool ?
        //

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            //layers.Insert(0, new PlayerLayer("Azercadmium", "Layer", new Action<PlayerDrawInfo>(delegate
            //{
            //})));
        }
    }
}