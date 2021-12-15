using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using GenshinImpactMod;

namespace GenshinImpactMod.Weapons.Catalysts
{
    class ThrillingTalesOfDragonSlayers : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thrilling Tales Of Dragon Slayers");
            Tooltip.SetDefault("Contains many stories of mystical dragon slayers");
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
            item.shoot = ProjectileID.RubyBolt;
            item.shootSpeed = 14f;
            item.crit = 6;
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            ModdedPlayer p = player.GetModPlayer<ModdedPlayer>();
            if (p.ThrillingTalesOfDragonSlayersDmgModifier)
            {
                damage = (int)(1.5f * damage);
            }
        }
    }
}
