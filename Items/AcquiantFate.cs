using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using GenshinImpactMod.Weapons.Swords;
using GenshinImpactMod.Weapons.Spears;
using GenshinImpactMod.Weapons.Claymores;
using GenshinImpactMod.Weapons.Bows;
using GenshinImpactMod.Weapons.Catalysts;

namespace GenshinImpactMod.Items
{
    class AcquiantFate : ModItem
    {
        public static int[] items = new int[]{ModContent.ItemType<HuntersBow>(),
            ModContent.ItemType<SkyriderGreatSword>(),
            ModContent.ItemType<BlackCliffPole>(),
            ModContent.ItemType<HarbingersDawn>()};
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("\"The fate of the world is in your hands\"\n-some random dude\"\n A secret currency just don't go into controls and see the hotkey we made");
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
