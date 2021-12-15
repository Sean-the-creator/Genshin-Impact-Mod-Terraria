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
            ModContent.ItemType<SeasonedHuntersBow>(),
            ModContent.ItemType<ApprenticesNotes>(),
            ModContent.ItemType<PocketGrimoire>(),
            ModContent.ItemType<OldMercsPal>(),
            ModContent.ItemType<SkyriderGreatSword>(),
            ModContent.ItemType<WasterGreatsword>(),
            ModContent.ItemType<BeginnersProtector>(),
            ModContent.ItemType<BlackCliffPole>(),
            ModContent.ItemType<IronPoint>(),
            ModContent.ItemType<DullBlade>(),
            ModContent.ItemType<HarbingersDawn>(),
            ModContent.ItemType<SilverSword>(),
            ModContent.ItemType<WasterGreatsword>()};
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
