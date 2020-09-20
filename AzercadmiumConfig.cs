  using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace Azercadmium
{
	public class AzercadmiumConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[DefaultValue(true)]
		[Label("Elemental Discus Spawns")]
		[Tooltip("Allows elemental discuses to spawn after the Ancient Desert Discus is defeated.")]
		public bool elemDiscus;

		[Label("Basic Discus Spawns")]
		[Tooltip("Allows a themeless discus to spawn rarely on the surface after the Ancient Desert Discus is defeated.")]
		public bool plainDiscus;
	}
}