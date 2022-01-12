using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using GenshinImpactMod;

namespace GenshinImpactMod.Items.Food
{
    class MonsdadtHashbrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monsdadt Hashbrown");
            Tooltip.SetDefault("ARE THESE NUGGIES\n- Timmie");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            ModdedPlayer player = new ModdedPlayer();
            
            if (player.CanEat)
            {
                item.useTurn = true;
                item.maxStack = 30;
                item.rare = ItemRarityID.Expert;
                item.useAnimation = 15;
                item.useTime = 15;
                item.useStyle = ItemUseStyleID.EatingUsing;

                item.UseSound = SoundID.Item2;

            
                item.stack--;
                item.buffType = BuffID.WellFed;
                item.buffTime = 10000;
                player.Saturation = 100;
            }

            item.value = 1;
        }


    }
}
