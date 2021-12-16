using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using GenshinImpactMod.Items;

namespace GenshinImpactMod.GlobalProperties
{
    class BossBags : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
            {
                player.QuickSpawnItem(ModContent.ItemType<AcquiantFate>());
            }
        }
    }
}
