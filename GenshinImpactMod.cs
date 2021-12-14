using GenshinImpactMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace GenshinImpactMod
{
	public class GenshinImpactMod : Mod
	{
		private UserInterface _genshinImpactUserInterface;

		internal WishingSystem WishingSystem;
        public static ModHotKey ToggleWishingSystem;

        public override void Load()
        {
            ToggleWishingSystem = RegisterHotKey("Toggle Wishing System", "P");
            if (!Main.dedServ)
            {
                WishingSystem = new WishingSystem();
                WishingSystem.Activate();
                _genshinImpactUserInterface = new UserInterface();
                _genshinImpactUserInterface.SetState(WishingSystem);
            }
        }

        public override void Unload()
        {
            ToggleWishingSystem = null;
        }

        public override void UpdateUI(GameTime gameTime)
        {if (WishingSystem.Visible)
            {
                _genshinImpactUserInterface?.Update(gameTime);
            }
            
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "YourMod: A Description",
                    delegate
                    {
                        if (WishingSystem.Visible)
                        {
                            _genshinImpactUserInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}