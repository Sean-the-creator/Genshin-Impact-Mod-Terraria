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
    class Flute : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Flute");
            Tooltip.SetDefault("I tried playing it once, my lip got a cut\nit hurts...");
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
            ModdedPlayer p = player.GetModPlayer<ModdedPlayer>();
            if(p.fluteHitCount >= 4)
            {
                damage = item.damage * 5;
            }
        }
    }
}
