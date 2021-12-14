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
    class SkyriderGreatSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("\"Bigger is always better, and swords are no exception\"\n-The Skyrider");
            DisplayName.SetDefault("Skyrider Greatsword");
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 64;
            item.height = 64;
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
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            ModdedPlayer p = player.GetModPlayer<ModdedPlayer>();
            damage += (int)(p.SkyriderGreatswordHit * 0.1f);
        }
    }
}
