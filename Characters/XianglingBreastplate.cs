using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using GenshinImpactMod;

namespace GenshinImpactMod.Characters
{
    [AutoloadEquip(EquipType.Body)]
    class XianglingBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xiangling chest ;)");

        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 1;
            item.rare = ItemRarityID.Expert;
            item.defense = 0;
        }

    }
}
