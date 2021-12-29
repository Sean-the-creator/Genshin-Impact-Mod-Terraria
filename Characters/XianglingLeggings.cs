using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Characters
{
    [AutoloadEquip(EquipType.Legs)]
    class XianglingLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xiangling Legs");
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
