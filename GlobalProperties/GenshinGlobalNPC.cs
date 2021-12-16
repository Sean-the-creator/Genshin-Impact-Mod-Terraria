using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GenshinImpactMod.Items;

namespace GenshinImpactMod.GlobalProperties
{
    class GenshinGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.SkeletronHead && !Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<AcquiantFate>());
            }
        }
    }
}
