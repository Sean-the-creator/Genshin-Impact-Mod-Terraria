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
    class StaffOfHoma : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("OP");
            DisplayName.SetDefault("Staff of Homa");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 68;
            item.height = 70;
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
            item.shoot = ModContent.ProjectileType<StaffOfHomaProj>();
        }

        public override void GetWeaponDamage(Player player, ref int damage)
        {
            if (player.statLife >= 0.5 * player.statLifeMax2)
            {
                damage += (int)(damage + (player.statLife * 0.008));
            }

        }

        public void GetCharacterHealth(Player player)
        {
            player.statLifeMax2 += (int)(player.statLifeMax2 * 0.2);
            player.statLife += (int)(player.statLife * 0.2);
        }

        public override void HoldItem(Player player)
        {
            GetCharacterHealth(player);
        }
    }
}
