using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons.Swords
{
    class JadeCutter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primordial Jade Cutter");
            Tooltip.SetDefault("I cut my jadE!");
        }

        public override void SetDefaults()
        {
            item.damage = 47;
            item.melee = true;
            item.width = 74;
            item.height = 74;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 5;
            item.value = Item.buyPrice(gold: 7);
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            damage += (int)(player.statLifeMax * 0.24f);
        }
        public override void HoldItem(Player player)
        {
            player.statLifeMax2 += (int)(player.statLifeMax2 * 0.2);
            player.statLife += (int)(player.statLife * 0.2);
        }
    }
}
