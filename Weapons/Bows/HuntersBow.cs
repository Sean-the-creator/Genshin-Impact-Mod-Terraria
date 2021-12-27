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
    class HuntersBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("\"A hunter's music consists of but two sounds: the twang of the bowstring and the whoosh of soaring arrows.\"\n Does not consume ammo");
            DisplayName.SetDefault("Hunter's Bow");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 16;
            item.height = 62;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 13;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 10f;
            item.crit = 6;
        }
    }
}
