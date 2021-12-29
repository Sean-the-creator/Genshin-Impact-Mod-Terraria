using GenshinImpactMod;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Characters
{
    [AutoloadEquip(EquipType.Head)]
    class XianglingHelmet : ModItem
    {
        public static bool isArmourSet = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xiangling Head");
            Tooltip.SetDefault("Equip with all other pieces to have special effects!");
        }

        // Add Size values
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 10;
            item.value = 1;
            item.rare = ItemRarityID.Expert;
        }

        // Add pieces of the set
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return true;
        }

        // Add set bonus
        public override void UpdateArmorSet(Player player)
        {
            isArmourSet = true;
        }
    }
}
