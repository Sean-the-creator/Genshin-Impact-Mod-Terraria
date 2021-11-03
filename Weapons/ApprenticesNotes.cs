using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace GenshinImpactMod.Weapons
{
    class ApprenticesNotes : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Notes left behind by a top student. Many useful spells are listed, and the handwriting is beautiful.");
            DisplayName.SetDefault("Apprentice's Notes");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.magic = true;
            item.mana = 0;
            item.width = 36;
            item.height = 38;
            item.channel = true;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 13;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = ProjectileID.AmethystBolt;
            item.shootSpeed = 16f;
            item.crit = 6;
        }
    }
}
