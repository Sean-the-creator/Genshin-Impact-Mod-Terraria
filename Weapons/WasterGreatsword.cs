using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons
{
    class WasterGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sturdy sheet of iron that may be powerful enough to break apart mountains, if wielded with enough willpower.");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.width = 80;
            item.height = 76;
            item.useTime = 40;
            item.useAnimation = 40;
            item.knockBack = 10;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 13;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
    }
}
