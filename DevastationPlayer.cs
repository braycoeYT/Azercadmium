using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Azercadmium
{
	public class DevastationPlayer : ModPlayer
	{	
		public int devLevel;
		public int devPoints;
		public int maxDevPoints = 100;
		public int devLevelCap;
		public override TagCompound Save()
		{
			return new TagCompound {
		{"devLevel", devLevel},
		{"devPoints", devPoints},
		{"maxDevPoints", maxDevPoints},
	};
		}
		public override void Load(TagCompound tag)
		{
			devLevel = tag.GetInt("devLevel");
			devPoints = tag.GetInt("devPoints");
			maxDevPoints = tag.GetInt("maxDevPoints");
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			if (AzercadmiumWorld.devastation && target.life <= 0 && devLevel < devLevelCap && !target.friendly && target.damage > 0) {
				int div = 1;
				if (Main.invasionType != 0 || Main.pumpkinMoon || Main.snowMoon) devPoints += div = 100;
				else if (target.boss) div = 5;
				else if (Main.LocalPlayer.ZoneTowerSolar || Main.LocalPlayer.ZoneTowerVortex || Main.LocalPlayer.ZoneTowerNebula || Main.LocalPlayer.ZoneTowerStardust) devPoints += div = 3;
				devPoints += target.lifeMax / div;
				if (Main.rand.Next(2) == 0) CombatText.NewText(player.getRect(), Color.LightGreen, target.lifeMax / div);
				else CombatText.NewText(player.getRect(), Color.SaddleBrown, target.lifeMax / div);
				int numIncrease = 0;
				while (devPoints > maxDevPoints) {
					numIncrease++;
					devLevel += 1;
					devPoints -= maxDevPoints;
					maxDevPoints += 100 + (devLevel * 50) + maxDevPoints / 100 - 1;
					Color messageColor;
					if (devLevel % 2 == 0) messageColor = Color.LightGreen;
					else messageColor = Color.SaddleBrown;
					string chat = player.name + "'s devastation level has increased to " + devLevel + "!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				if (numIncrease > 1) {
					Color messageColor;
					if (devLevel % 2 == 1) messageColor = Color.LightGreen;
					else messageColor = Color.SaddleBrown;
					string chat = player.name + "(Total number of devastation levels increased by " + numIncrease + ")";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			if (AzercadmiumWorld.devastation && target.life <= 0 && devLevel < devLevelCap && !target.friendly && target.damage > 0) {
				int div = 1;
				if (Main.invasionType != 0 || Main.pumpkinMoon || Main.snowMoon) devPoints += div = 100;
				else if (target.boss) div = 5;
				else if (Main.LocalPlayer.ZoneTowerSolar || Main.LocalPlayer.ZoneTowerVortex || Main.LocalPlayer.ZoneTowerNebula || Main.LocalPlayer.ZoneTowerStardust) devPoints += div = 3;
				devPoints += target.lifeMax / div;
				if (Main.rand.Next(2) == 0) CombatText.NewText(player.getRect(), Color.LightGreen, target.lifeMax / div);
				else CombatText.NewText(player.getRect(), Color.SaddleBrown, target.lifeMax / div);
				int numIncrease = 0;
				while (devPoints > maxDevPoints) {
					numIncrease++;
					devLevel += 1;
					devPoints -= maxDevPoints;
					maxDevPoints += 100 + (devLevel * 50) + maxDevPoints / 100 - 1;
					Color messageColor;
					if (devLevel % 2 == 0) messageColor = Color.LightGreen;
					else messageColor = Color.SaddleBrown;
					string chat = player.name + "'s devastation level has increased to " + devLevel + "!";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
				if (numIncrease > 1) {
					Color messageColor;
					if (devLevel % 2 == 1) messageColor = Color.LightGreen;
					else messageColor = Color.SaddleBrown;
					string chat = "(Total number of devastation levels increased by " + numIncrease + ")";
					if (Main.netMode == NetmodeID.Server)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(chat), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer)
					{
						Main.NewText(Language.GetTextValue(chat), messageColor);
					}
				}
			}
		}
		public override void PostUpdateMiscEffects() {
			if (AzercadmiumWorld.devastation) {
				player.statLifeMax2 += devLevel;
				player.allDamage += (0.0015f * devLevel);
				player.statDefense += (int)(0.1f * devLevel);
			}
			if (NPC.downedMoonlord)
				devLevelCap = 99;
			else if (NPC.downedAncientCultist)
				devLevelCap = 80;
			else if (NPC.downedGolemBoss)
				devLevelCap = 75;
			else if (NPC.downedPlantBoss)
				devLevelCap = 70;
			else if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				devLevelCap = 60;
			else if (Main.hardMode)
				devLevelCap = 50;
			else if (NPC.downedBoss3)
				devLevelCap = 40;
			else if (NPC.downedBoss2)
				devLevelCap = 30;
			else if (NPC.downedBoss1)
				devLevelCap = 20;
			else
				devLevelCap = 10;
		}
	}
}