using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Bows
{
    class SeasonedHuntersBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seasoned Hunter's Bow");
            Tooltip.SetDefault("\"A bow that has been well-polished by time and meticulously cared for by its owner. It feels almost like an extension of the archer's arm.\"\n Does not consume ammo and shoots unholy arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.ranged = true;
            item.width = 16;
            item.height = 62;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 7);
            item.rare = 13;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ProjectileID.UnholyArrow;
            item.shootSpeed = 9f;
            item.crit = 6;
        }
    }
}
