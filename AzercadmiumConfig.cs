using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Azercadmium
{
	public class AzercadmiumConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Label("Pearlwood Buff")]
		[Tooltip("Buffs pearlwood tools and armor. Reload required.")]
		public bool pearlwoodBuff;

		[Label("Attack of the Nebula Pillar")]
		[Tooltip("Gives the Nebula Pillar a unique attack (as it is the only pillar without one in vanilla). Reload may be required.")]
		public bool nebulaAttack;

		[DefaultValue(true)]
		[Label("Azercadmium Prefixes")]
		[Tooltip("Allows Azercadmium prefixes to be rolled.")]
		public bool azercadmiumPrefixes;
		
		[Label("Vanilla Seeds are Blowpipe Ammo")]
		[Tooltip("Turns all vanilla seeds into blowpipe ammo, and increases their max stack.")]
		public bool vanillaSeedAmmo;
		
		[DefaultValue(true)]
		[Label("Dirtboi Cries for its Father")]
		[Tooltip("If you defeat Dirtball, he will cry before running away.")]
		public bool dirtboiCries;
	}
}