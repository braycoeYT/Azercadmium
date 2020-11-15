using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Azercadmium
{
	public class AzercadmiumConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Label("Elemental Discus Spawns")]
		[Tooltip("Allows elemental discuses to spawn after the Ancient Desert Discus is defeated. Reload may be required.")]
		public bool elemDiscus;

		[Label("Basic Discus Spawns")]
		[Tooltip("Allows a themeless discus to spawn rarely on the surface after the Ancient Desert Discus is defeated. Reload may be required.")]
		public bool plainDiscus;

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

		/*[DefaultValue(true)]
		[Label("Dirtball Hint")]
		[Tooltip("When Dirtball is summoned, gives a hint if Dirtball has not yet been defeated.")]
		public bool dirtballHint;*/
	}
}