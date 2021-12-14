﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using GenshinImpactMod.Projectiles.SpearProjectiles;


namespace GenshinImpactMod.Weapons.Spears
{
    class BlackCliffPole : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A polearm as straight as a flag pole. Well suited to most combat situations, it has an imposing presence when swung.");
            DisplayName.SetDefault("Beginner's Protector");
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
            item.shoot = ModContent.ProjectileType<BlackCliffPoleProj>();
        }
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            ModdedPlayer p = player.GetModPlayer<ModdedPlayer>();
            if (p.defeatedOpponent)
            {
                damage += (int)(damage * 0.24f);
            }
        }
    }
}
