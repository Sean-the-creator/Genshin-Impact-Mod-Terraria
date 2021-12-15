using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace GenshinImpactMod.Items
{
    class AcquiantFate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("\"The fate of the world is in your hands\"\n-some random dude");
            DisplayName.SetDefault("Acquaint Fate");
        }
        public override void SetDefaults()
        {
            item.material = true;
            item.width = 64;
            item.height = 64;
            item.value = Item.buyPrice(0, 3, 50, 0);
            item.rare = ItemRarityID.Expert;
        }
    }
}
