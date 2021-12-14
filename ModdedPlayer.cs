using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using GenshinImpactMod.UI;

namespace GenshinImpactMod
{
    class ModdedPlayer : ModPlayer
    {
        #region Hotkeys
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GenshinImpactMod.ToggleWishingSystem.JustPressed)
            {
                WishingSystem.Visible = !WishingSystem.Visible;
            }
        }
        #endregion

        
        public int defeatedOpponent = 0;
        private int counter = 0;
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(target.life <= 0)
            {
                defeatedOpponent += 1;
                counter = 0;
                if(defeatedOpponent >= 3)
                {
                    defeatedOpponent = 3;
                }
            }
        }
        public override void PostUpdate()
        {
            counter++;
            if(counter >= 1800)
            {
                defeatedOpponent = 0;
                counter = 0;
            }
        }
    }
}
