using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using GenshinImpactMod.Projectiles.SpearProjectiles;

namespace GenshinImpactMod.Weapons.Spears
{
    class IronPoint : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Point");
            Tooltip.SetDefault("Sharp and pointy at one end, it is a balanced weapon that is quite popular among travelers.");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 76;
            item.height = 76;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 4f;
            item.knockBack = 7f;
            item.scale = 1f;
            item.rare = 13;
            item.value = Item.buyPrice(gold: 7);

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<IronPointProj>();
        }
    }
}
