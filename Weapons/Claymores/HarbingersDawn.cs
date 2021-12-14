using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Claymores
{
    class HarbingersDawn : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(@"This sword has an extraordinary full name:
The Triumphant Harbinger of Dawn that Points Towards Victory.
Only one has ever fallen by this blade on the battlefield.
One night, the bearer drew the sword triumphantly.
The night sky lit up as bright as day,
pin - pointing his precise location.
Arrows rained down upon him. ");
            DisplayName.SetDefault("Harbinger of Dawn");
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 76;
            item.height = 76;
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
        public override void GetWeaponCrit(Player player, ref int crit)
        {
            if(player.statLife >= player.statLifeMax * 0.9f)
            {
                crit += 28;
            }
        }
    }
}
