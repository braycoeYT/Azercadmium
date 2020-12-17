using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.NPCs.Bosses
{
	[AutoloadBossHead]
	public class AncientDesertDiscus2 : ModNPC
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Desert Discus");
		}
        public override void SetDefaults()
		{
			npc.width = 140;
			npc.height = 140;
			npc.damage = 21;
			npc.defense = 0;
			npc.lifeMax = 900;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath7;
			npc.value = Item.buyPrice(0, 2, 50, 0);
			npc.knockBackResist = 0f;
			npc.aiStyle = 56;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.lavaImmune = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/ADD");
			npc.netAlways = true;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 1400;
            npc.damage = 39;
        }
		
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = 226;
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Electrified, 60, false);
		}
		int Timer;
		bool chat2 = true;
		int flee = 0;

        public override void AI()
		{
			npc.TargetClosest(true);
			npc.dontTakeDamage = !Main.player[npc.target].ZoneDesert;
			if (Main.player[npc.target].statLife < 1)
			{
				npc.TargetClosest(true);
				if (Main.player[npc.target].statLife < 1)
				{
					if (flee == 0)
					flee++;
				}
				else
				flee = 0;
			}
			if (flee >= 1)
            {
                flee++;
                npc.noTileCollide = true;
                npc.velocity.Y = 7f;
                if (flee >= 450)
                    npc.active = false;
            }
			if (Timer % 180 == 0)
			{
				Main.PlaySound(SoundID.Item12);
				if (Main.expertMode)
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -10, mod.ProjectileType("ElectricSpeck"), 10, Main.myPlayer);
				else
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -12, mod.ProjectileType("ElectricSpeck"), 12, Main.myPlayer);
			}
			if (Main.dayTime)
			{
				npc.life += 5;
				npc.dontTakeDamage = true;
				if (npc.life > npc.lifeMax)
				{
					npc.life = npc.lifeMax;
					npc.lifeMax += 6;
				}
				if (chat2)
				{
					Color messageColor = Color.CornflowerBlue;
					string chat = "This is dragging on forever...";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
					chat2 = false;
				}
				npc.noTileCollide = true;
                npc.velocity.Y = 8f;
			}
			Timer++;
			if (Main.expertMode)
			{
				if  (Timer % 350 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Discus.ElectricAssaultDiscus>(), 0, npc.whoAmI);
				}
			}
			else
			{
				if  (Timer % 450 == 0)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<NPCs.Discus.ElectricAssaultDiscus>(), 0, npc.whoAmI);
				}
			}
        }
		
	    public override void NPCLoot()
        {
			if (Main.rand.NextFloat() < .1f)
			Item.NewItem(npc.getRect(), mod.ItemType("PolandballMask"));
			if (Main.rand.NextFloat() < .1f)
			Item.NewItem(npc.getRect(), mod.ItemType("AncientDesertDiscusMask"));
			if (Main.expertMode)
				Item.NewItem(npc.getRect(), mod.ItemType("DiscusBag"));
		    else {
			    Item.NewItem(npc.getRect(), mod.ItemType("BrokenDiscus"), 9 + Main.rand.Next(2));
	            Item.NewItem(npc.getRect(), ItemID.Amber, 2 + Main.rand.Next(3));
			    Item.NewItem(npc.getRect(), ItemID.GoldBar, 4 + Main.rand.Next(3));
				Item.NewItem(npc.getRect(), mod.ItemType("DriedEssence"), Main.rand.Next(5, 9));
				Item.NewItem(npc.getRect(), mod.ItemType("Electroid"));
			}
			AzercadmiumWorld.downedDiscus = true;
        }
		public override void BossLoot(ref string name, ref int potionType) {
			name = "Ancient Desert Discus";
		}
	}
}