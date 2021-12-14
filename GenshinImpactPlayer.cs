using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using GenshinImpactMod;
using GenshinImpactMod.UI;
using Terraria.GameInput;

namespace GenshinImpactMod
{
    class GenshinImpactPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GenshinImpactMod.ToggleWishingSystem.JustPressed)
            {
                if (WishingSystem.Visible)
                {
                    WishingSystem.Visible = false;
                }
                else if (!WishingSystem.Visible)
                {
                    WishingSystem.Visible = true;
                }
            }    
        }
    }
}
