using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Azercadmium.Projectiles.Empress
{
	public class RoyalMotherSlime : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Royal Mother Slime");
			Main.projFrames[projectile.type] = 2;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public sealed override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
		}
		public override bool? CanCutTiles() {
			return true;
		}
		public override bool MinionContactDamage() {
			return true;
		}
		int Timer;
		int rand = Main.rand.Next(0, 40);
		bool flag;
		bool flag2;
		bool flag7;
		bool flag8;
		Vector2 vector9;
		public override void AI() {
			Player player = Main.player[projectile.owner];
			#region Active check
			if (player.dead || !player.active)
			{
				player.ClearBuff(BuffType<Buffs.Minions.Ores.FloatingAdamantiteOre>());
			}
			if (player.HasBuff(BuffType<Buffs.Minions.Ores.FloatingAdamantiteOre>()))
			{
				projectile.timeLeft = 2;
			}
			#endregion

			float num78 = (float)(40 * projectile.minionPos);
						int num79 = 60;
						projectile.localAI[0] -= 1f;
						if (projectile.localAI[0] < 0f)
						{
							projectile.localAI[0] = 0f;
						}
						if (projectile.ai[1] > 0f)
						{
							projectile.ai[1] -= 1f;
						}
						else
						{
							float num80 = projectile.position.X;
							float num81 = projectile.position.Y;
							float num82 = 100000f;
							float num83 = num82;
							int num84 = -1;
							NPC ownerMinionAttackTargetNPC2 = projectile.OwnerMinionAttackTargetNPC;
							if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(projectile, false))
							{
								float x = ownerMinionAttackTargetNPC2.Center.X;
								float y = ownerMinionAttackTargetNPC2.Center.Y;
								float num85 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - x) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - y);
								if (num85 < num82)
								{
									if (num84 == -1 && num85 <= num83)
									{
										num83 = num85;
										num80 = x;
										num81 = y;
									}
									if (Collision.CanHit(projectile.position, projectile.width, projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
									{
										num82 = num85;
										num80 = x;
										num81 = y;
										num84 = ownerMinionAttackTargetNPC2.whoAmI;
									}
								}
							}
							if (num84 == -1)
							{
								for (int m = 0; m < 200; m++)
								{
									if (Main.npc[m].CanBeChasedBy(projectile, false))
									{
										float num86 = Main.npc[m].position.X + (float)(Main.npc[m].width / 2);
										float num87 = Main.npc[m].position.Y + (float)(Main.npc[m].height / 2);
										float num88 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num86) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num87);
										if (num88 < num82)
										{
											if (num84 == -1 && num88 <= num83)
											{
												num83 = num88;
												num80 = num86;
												num81 = num87;
											}
											if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[m].position, Main.npc[m].width, Main.npc[m].height))
											{
												num82 = num88;
												num80 = num86;
												num81 = num87;
												num84 = m;
											}
										}
									}
								}
							}
							if (projectile.type >= 390 && projectile.type <= 392 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
							{
								projectile.tileCollide = true;
							}
							if (num84 == -1 && num83 < num82)
							{
								num82 = num83;
							}
							else if (num84 >= 0)
							{
								flag7 = true;
								vector9 = new Vector2(num80, num81) - projectile.Center;
								if (projectile.type >= 390 && projectile.type <= 392)
								{
									if (Main.npc[num84].position.Y > projectile.position.Y + (float)projectile.height)
									{
										int num89 = (int)(projectile.Center.X / 16f);
										int num90 = (int)((projectile.position.Y + (float)projectile.height + 1f) / 16f);
										if (Main.tile[num89, num90] != null && Main.tile[num89, num90].active() && TileID.Sets.Platforms[(int)Main.tile[num89, num90].type])
										{
											projectile.tileCollide = false;
										}
									}
									Rectangle rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
									Rectangle value = new Rectangle((int)Main.npc[num84].position.X, (int)Main.npc[num84].position.Y, Main.npc[num84].width, Main.npc[num84].height);
									int num91 = 10;
									value.X -= num91;
									value.Y -= num91;
									value.Width += num91 * 2;
									value.Height += num91 * 2;
									if (rectangle.Intersects(value))
									{
										flag8 = true;
										Vector2 vector10 = Main.npc[num84].Center - projectile.Center;
										if (projectile.velocity.Y > 0f && vector10.Y < 0f)
										{
											projectile.velocity.Y = projectile.velocity.Y * 0.5f;
										}
										if (projectile.velocity.Y < 0f && vector10.Y > 0f)
										{
											projectile.velocity.Y = projectile.velocity.Y * 0.5f;
										}
										if (projectile.velocity.X > 0f && vector10.X < 0f)
										{
											projectile.velocity.X = projectile.velocity.X * 0.5f;
										}
										if (projectile.velocity.X < 0f && vector10.X > 0f)
										{
											projectile.velocity.X = projectile.velocity.X * 0.5f;
										}
										if (vector10.Length() > 14f)
										{
											vector10.Normalize();
											vector10 *= 14f;
										}
										projectile.rotation = (projectile.rotation * 5f + vector10.ToRotation() + 1.57079637f) / 6f;
										projectile.velocity = (projectile.velocity * 9f + vector10) / 10f;
										for (int n = 0; n < 1000; n++)
										{
											if (projectile.whoAmI != n && projectile.owner == Main.projectile[n].owner && Main.projectile[n].type >= 390 && Main.projectile[n].type <= 392 && (Main.projectile[n].Center - projectile.Center).Length() < 15f)
											{
												float num92 = 0.5f;
												if (projectile.Center.Y > Main.projectile[n].Center.Y)
												{
													Projectile expr_4C8A_cp_0_cp_0 = Main.projectile[n];
													expr_4C8A_cp_0_cp_0.velocity.Y = expr_4C8A_cp_0_cp_0.velocity.Y - num92;
													projectile.velocity.Y = projectile.velocity.Y + num92;
												}
												else
												{
													Projectile expr_4CB5_cp_0_cp_0 = Main.projectile[n];
													expr_4CB5_cp_0_cp_0.velocity.Y = expr_4CB5_cp_0_cp_0.velocity.Y + num92;
													projectile.velocity.Y = projectile.velocity.Y - num92;
												}
												if (projectile.Center.X > Main.projectile[n].Center.X)
												{
													projectile.velocity.X = projectile.velocity.X + num92;
													Projectile expr_4D0E_cp_0_cp_0 = Main.projectile[n];
													expr_4D0E_cp_0_cp_0.velocity.X = expr_4D0E_cp_0_cp_0.velocity.X - num92;
												}
												else
												{
													projectile.velocity.X = projectile.velocity.X - num92;
													Projectile expr_4D39_cp_0_cp_0 = Main.projectile[n];
													expr_4D39_cp_0_cp_0.velocity.Y = expr_4D39_cp_0_cp_0.velocity.Y + num92;
												}
											}
										}
									}
								}
							}
							float num93 = 300f;
							if ((double)projectile.position.Y > Main.worldSurface * 16.0)
							{
								num93 = 150f;
							}
							if (projectile.type >= 390 && projectile.type <= 392)
							{
								num93 = 500f;
								if ((double)projectile.position.Y > Main.worldSurface * 16.0)
								{
									num93 = 250f;
								}
							}
							if (num82 < num93 + num78 && num84 == -1)
							{
								float num94 = num80 - (projectile.position.X + (float)(projectile.width / 2));
								if (num94 < -5f)
								{
									flag = true;
									flag2 = false;
								}
								else if (num94 > 5f)
								{
									flag2 = true;
									flag = false;
								}
							}
							bool flag9 = false;
							if (projectile.type >= 390 && projectile.type <= 392 && projectile.localAI[1] > 0f)
							{
								flag9 = true;
								projectile.localAI[1] -= 1f;
							}
							if (num84 >= 0 && num82 < 800f + num78)
							{
								projectile.friendly = true;
								projectile.localAI[0] = (float)num79;
								float num95 = num80 - (projectile.position.X + (float)(projectile.width / 2));
								if (num95 < -10f)
								{
									flag = true;
									flag2 = false;
								}
								else if (num95 > 10f)
								{
									flag2 = true;
									flag = false;
								}
								if (num81 < projectile.Center.Y - 100f && num95 > -50f && num95 < 50f && projectile.velocity.Y == 0f)
								{
									float num96 = Math.Abs(num81 - projectile.Center.Y);
									if (num96 < 120f)
									{
										projectile.velocity.Y = -10f;
									}
									else if (num96 < 210f)
									{
										projectile.velocity.Y = -13f;
									}
									else if (num96 < 270f)
									{
										projectile.velocity.Y = -15f;
									}
									else if (num96 < 310f)
									{
										projectile.velocity.Y = -17f;
									}
									else if (num96 < 380f)
									{
										projectile.velocity.Y = -18f;
									}
								}
								if (flag9)
								{
									projectile.friendly = false;
									if (projectile.velocity.X < 0f)
									{
										flag = true;
									}
									else if (projectile.velocity.X > 0f)
									{
										flag2 = true;
									}
								}
							}
							else
							{
								projectile.friendly = false;
							}
						}

			#region Projectile
			/*Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 40;
			if (foundTarget)
			{
				Timer++;
				if (Timer % 40 == rand)
				Projectile.NewProjectile(projectile.Center, projDir, mod.ProjectileType("AdamantiteOrebolt"), projectile.damage, projectile.knockBack, Main.myPlayer);
			}*/

			#endregion

			#region Animation and visuals
			Timer++;
			if (Timer % 6 < 3)
				projectile.frame = 0;
			else
				projectile.frame = 1;
			#endregion
		}
	}
}