using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using Azercadmium.Buffs.Debuffs;
using Azercadmium.Textures;
using Azercadmium.Aaa;

namespace Azercadmium.NPCs
{
    public class TAZGNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public float[] ai2;

        public bool xenicAcid;

        public bool slimyOoze;

        public bool shroomed;

        public bool charred;

        public override void ResetEffects(NPC npc)
        {
            xenicAcid = false;
            slimyOoze = false;
            shroomed = false;
            charred = false;
        }

        public override void SetDefaults(NPC npc)
        {
            if (!Azercadmium.loading)
            {
                ai2 = new float[Azercadmium.NPCAITimerCache[npc.type]];
            }
            switch (npc.type)
            {

                case NPCID.EaterofWorldsHead:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.EaterofWorldsBody:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.EaterofWorldsTail:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.MeteorHead:
                npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                break;

                case NPCID.SkeletronHead:
                npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                break;

                case NPCID.LavaSlime:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Hellbat:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Demon:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.VoodooDemon:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.DungeonGuardian:
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                break;

                case NPCID.Wraith:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.EnchantedSword:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.CursedHammer:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.ChaosElemental:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Gastropod:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Retinazer:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.Spazmatism:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.SkeletronPrime:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.PrimeCannon:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.PrimeSaw:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.PrimeVice:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.PrimeLaser:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.TheDestroyer:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.TheDestroyerBody:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.TheDestroyerTail:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.Probe:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.IlluminantBat:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.SnowmanGangsta:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.MisterStabby:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.SnowBalla:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.None3: // unused snowman dynamite be like: None3
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Lavabat:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.IceTortoise:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.RedDevil:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.BlackRecluse:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.BlackRecluseWall:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.SwampThing:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.IceElemental:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.PigronCorruption:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.PigronHallow:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.PigronCrimson:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.CrimsonAxe:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Moth:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.IcyMerman:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.SeaSnail:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Squid:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.FlyingFish:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.UmbrellaSlime:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.BloodFeeder:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.BloodJelly:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.IceGolem:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.Golem:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.GolemFistLeft:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.GolemFistRight:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.GolemHeadFree:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.HellArmoredBones:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.HellArmoredBonesSpikeShield:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.HellArmoredBonesMace:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.HellArmoredBonesSword:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.DiabolistRed:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.DiabolistWhite:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.DungeonSpirit:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.MoonLordHead:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.MoonLordHand:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.MoonLordCore:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.MoonLordFreeEye:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.CultistBoss:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                    //npc.buffImmune[mod.BuffType("Sick")] = true;
                }
                break;

                case NPCID.AncientCultistSquidhead:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.AncientLight:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;

                case NPCID.AncientDoom:
                {
                    npc.buffImmune[ModContent.BuffType<Charred>()] = true;
                }
                break;
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (charred)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 30;
                if (damage < 1)
                {
                    damage = 1;
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (charred)
            {
                drawColor.R = (byte)(drawColor.R * 0.65f);
                drawColor.G = (byte)(drawColor.R * 0.35f);
                drawColor.B = (byte)(drawColor.R * 0.15f);
                Lighting.AddLight(npc.position, Color.Orange.ToVector3() * 0.75f);
                if (Main.rand.NextBool())
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.SolarFlare);
                }
            }
            if (npc.whoAmI == Main.LocalPlayer.ModPlayer().editwandNPCSelect)
            {
                drawColor = Main.DiscoColor;
            }
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            if (Main.LocalPlayer.ModPlayer().editwandNPCMode)
            {
                if (Vector2.Distance(npc.Center, Main.MouseWorld) < 200)
                {
                    spriteBatch.Draw(TextureContainer.pixle, npc.position - Main.screenPosition, null, new Color(Main.mouseColor.R, Main.mouseColor.G, Main.mouseColor.B, 0), 0f, Vector2.Zero, new Vector2(npc.width, npc.height), SpriteEffects.None, 0f);
                }
            }
            if (npc.whoAmI == Main.LocalPlayer.ModPlayer().editwandNPCHover)
            {
                Vector2 drawPos = npc.Top - Main.screenPosition;
                ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontCombatText[0], "Select", drawPos + new Vector2(Main.fontCombatText[0].MeasureString("Select").X / -2f, -24f), new Color(255, 255, 10), 0f, Vector2.Zero, Vector2.One);
            }
            if (npc.whoAmI == Main.LocalPlayer.ModPlayer().editwandNPCSelect)
            {
                Vector2 drawPos = npc.BottomRight - Main.screenPosition;
                for (int i = 0; i < npc.ai.Length; i++)
                {
                    ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontCombatText[0], nameof(npc.ai) + "[" + i + "]: " + npc.ai[i], drawPos + new Vector2(0, 32 * i), Color.White, 0f, Vector2.Zero, Vector2.One);
                }
                for (int i = 0; i < npc.ai.Length; i++)
                {
                    ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, Main.fontCombatText[0], nameof(npc.localAI) + "[" + i + "]: " + npc.localAI[i], drawPos + new Vector2(0, 32 * i + 128), Color.White, 0f, Vector2.Zero, Vector2.One);
                }
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.ModPlayer().ZoneEmberGlades)
            {
                spawnRate = (int)(spawnRate * 1.5);
                maxSpawns = (int)(maxSpawns * 0.5f);
            }
        }

        /*public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.desertCave)
            {
                if (NPC.downedMoonlord)
                {
                    pool[0] *= (SpawnCondition.DesertCave.Chance * 0.2f);
                    pool.Add(NPCID.DesertDjinn, 0.02f);
                }
            }
        }*/
    }
}