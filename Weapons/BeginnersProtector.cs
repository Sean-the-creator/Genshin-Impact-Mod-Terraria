using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using GenshinImpactMod.Projectiles;

namespace GenshinImpactMod.Weapons
{
    class BeginnersProtector : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A polearm as straight as a flag pole. Well suited to most combat situations, it has an imposing presence when swung.");
            DisplayName.SetDefault("Beginner's Protector");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 48;
            item.height = 48;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 4f;
            item.knockBack = 7f;
            item.scale = 1f;
            item.rare = 13;
            item.value = Item.buyPrice(gold: 1);

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<BeginnersProtectorProj>();
        }
    }
}
