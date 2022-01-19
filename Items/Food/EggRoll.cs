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
    class EggRoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Egg Roll");
            Tooltip.SetDefault("First Flatten the egg\n then roll the egg");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            ModdedPlayer player = new ModdedPlayer();


                item.useTurn = true;
                item.maxStack = 30;
                item.rare = ItemRarityID.Expert;
                item.useAnimation = 15;
                item.useTime = 15;
                item.useStyle = ItemUseStyleID.EatingUsing;

                item.UseSound = SoundID.Item2;


                item.stack--;
                item.buffType = BuffID.WellFed;
                item.buffTime = 8000;
                player.Saturation = 100;
            

            item.value = 1;
        }


    }
}
