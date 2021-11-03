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
    class DullBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Youthful dreams and the thrill of adventure. If this isn't enough, then make it up with valiance.");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 45;
            item.height = 45;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 5;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 13;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
    }
}
