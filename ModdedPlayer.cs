using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace GenshinImpactMod
{
    class ModdedPlayer : ModPlayer
    {
        //nothign necessary just yet, just a player class to use later.
        public bool defeatedOpponent = false;
        private int counter = 0;
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(target.life <= 0)
            {
                defeatedOpponent = true;
                counter = 0;
            }
        }
        public override void PostUpdate()
        {
            counter++;
            if(counter >= 1800)
            {
                defeatedOpponent = false;
                counter = 0;
            }
        }
    }
}
