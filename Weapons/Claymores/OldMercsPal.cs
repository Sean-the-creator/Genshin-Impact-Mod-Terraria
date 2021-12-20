using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Claymores
{
    class OldMercsPal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Merc's Pal");
            Tooltip.SetDefault("A battle-tested greatsword that has seen better days and worse.\n A slow but powerful sword");
        }

        public override void SetDefaults()
        {
            item.damage = 53;
            item.melee = true;
            item.width = 58;
            item.height = 64;
            item.useTime = 40;
            item.useAnimation = 40;
            item.knockBack = 10;
            item.value = Item.buyPrice(gold: 7);
            item.rare = 13;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
    }
}
