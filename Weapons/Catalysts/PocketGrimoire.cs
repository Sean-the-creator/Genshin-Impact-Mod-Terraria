using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Catalysts
{
    class PocketGrimoire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pocket Grimoire");
            Tooltip.SetDefault("A carefully compiled notebook featuring the essentials needed to pass a magic exam.");
        }

        public override void SetDefaults()
        {
            item.damage = 43;
            item.magic = true;
            item.mana = 0;
            item.width = 28;
            item.height = 30;
            item.channel = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 7);
            item.rare = 13;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = ProjectileID.AmberBolt;
            item.shootSpeed = 14f;
            item.crit = 6;
        }
    }
}
