using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using GenshinImpactMod.Projectiles.SpearProjectiles;
using GenshinImpactMod;

namespace GenshinImpactMod.Weapons.Spears
{
    class JadeSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Primordial Winged Jade Spear");
            Tooltip.SetDefault("hmmm its greeeeen!");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 76;
            item.height = 76;
            item.useAnimation = 18;
            item.useTime = 24;
            item.shootSpeed = 4f;
            item.knockBack = 7f;
            item.scale = 1f;
            item.rare = 13;
            item.value = Item.buyPrice(gold: 7);

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<JadeSpearProj>();
        }
        private float damageMult = 0.032f;
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            damage += (int)(player.GetModPlayer<ModdedPlayer>().JadeSpearHits * damageMult * damage);
        }
    }
}
