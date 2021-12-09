using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Swords
{
    class SilverSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Sword");
            Tooltip.SetDefault("A sword for chasing away demons. Everyone knows it's made of a silver alloy, not pure silver.");
        }

        public override void SetDefaults()
        {
            item.damage = 47;
            item.melee = true;
            item.width = 74;
            item.height = 74;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 5;
            item.value = Item.buyPrice(gold: 7);
            item.rare = 13;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
    }
}
