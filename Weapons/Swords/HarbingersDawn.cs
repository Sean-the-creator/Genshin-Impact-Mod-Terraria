using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Swords
{
    class HarbingersDawn : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sword that once shone like the sun. The wielder of this sword will be blessed with a \"feel - good\" buff. The reflective material on the blade has long worn off.\nIncreases crit rate if your health is below a certain percentage");
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
