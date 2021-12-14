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

        
        public int BlackCliffdefeatedOpponent = 0;
        private int BlackCliffcounter = 0;

        public int SkyriderGreatswordHit = 0;
        private int SkyriderGreatswordCounter = 0;
        private int SkyriderGreatswordDelay = 0;

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            SkyriderGreatswordCounter = 0;
            if (SkyriderGreatswordDelay <= 0)
            {
                SkyriderGreatswordHit += 1;
                SkyriderGreatswordDelay = 30;
                if (SkyriderGreatswordHit >= 4)
                {
                    SkyriderGreatswordHit = 4;
                }
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(target.life <= 0)
            {
                BlackCliffdefeatedOpponent += 1;
                BlackCliffcounter = 0;
                if(BlackCliffdefeatedOpponent >= 3)
                {
                    BlackCliffdefeatedOpponent = 3;
                }
            }
        }
        public override void PostUpdate()
        {
            SkyriderGreatswordCounter++;
            if (SkyriderGreatswordDelay > 0)
            {
                SkyriderGreatswordDelay--;
            }
            if(SkyriderGreatswordCounter >= 360)
            {
                SkyriderGreatswordCounter = 0;
                SkyriderGreatswordHit = 0;
            }

            BlackCliffcounter++;
            if(BlackCliffcounter >= 1800)
            {
                BlackCliffdefeatedOpponent = 0;
                BlackCliffcounter = 0;
            }
        }
    }
}
