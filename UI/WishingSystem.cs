using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using GenshinImpactMod.Weapons.Spears;
using GenshinImpactMod.Weapons.Swords;
using GenshinImpactMod.Weapons.Claymores;
using GenshinImpactMod.Weapons.Bows;
using GenshinImpactMod.Weapons.Catalysts;
using Terraria.GameContent.UI.Elements;
using GenshinImpactMod.Characters;
using System.Collections.Generic;
using GenshinImpactMod.Items;


namespace GenshinImpactMod.UI
{
    internal class WishingSystem : UIState
    {
        public DragableUI WishSystemPanel;
        public UIImage WishingSystemBanner;
        public static bool Visible;

        public static int[] items = new int[]{ModContent.ItemType<SkyriderGreatSword>(),
            ModContent.ItemType<BlackCliffPole>(),
            ModContent.ItemType<HarbingersDawn>(),
            ModContent.ItemType<StaffOfHoma>(),
            ModContent.ItemType<XianglingHelmet>(),
            ModContent.ItemType<JadeCutter>(),
            ModContent.ItemType<JadeSpear>(),
            ModContent.ItemType<ThrillingTalesOfDragonSlayers>()};


        public override void OnInitialize()
        {

            WishSystemPanel = new DragableUI();
            WishSystemPanel.Left.Set(400f, 0f);
            WishSystemPanel.Top.Set(100f, 0f);
            WishSystemPanel.Width.Set(500f, 0f);
            WishSystemPanel.Height.Set(250f, 0f);

            Texture2D wishButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
            UIHoverImageButton wishButton = new UIHoverImageButton(wishButtonTexture, "Wish");
            wishButton.Left.Set(218f, 0f);
            wishButton.Top.Set(192f, 0f);
            wishButton.Width.Set(117f, 0f);
            wishButton.Height.Set(45f, 0f);
            wishButton.OnClick += new MouseEvent(WishButtonClicked);

            Texture2D wishButtonx10Texture = ModContent.GetTexture("Terraria/UI/ButtonPlay");
            UIHoverImageButton wishButtonx10 = new UIHoverImageButton(wishButtonx10Texture, "Wish x 10");
            wishButtonx10.Left.Set(348f, 0f);
            wishButtonx10.Top.Set(192f, 0f);
            wishButtonx10.Width.Set(117f, 0f);
            wishButtonx10.Height.Set(45f, 0f);
            wishButtonx10.OnClick += new MouseEvent(WishButtonx10Clicked);


            Texture2D deleteButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
            UIHoverImageButton closeButton = new UIHoverImageButton(deleteButtonTexture, Language.GetTextValue("LegacyInterface.52"));
            closeButton.Left.Set(460f, 0f);
            closeButton.Top.Set(8f, 0f);
            closeButton.Width.Set(30f, 0f);
            closeButton.Height.Set(30f, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);


            Texture2D wishingSystemBanner = ModContent.GetTexture("GenshinImpactMod/UI/WishingSystem");
            WishingSystemBanner = new UIImage(wishingSystemBanner);
            WishingSystemBanner.Left.Set(0f, 0f);
            WishingSystemBanner.Top.Set(0f, 0f);
            WishingSystemBanner.Width.Set(500f, 0);
            WishingSystemBanner.Height.Set(250f, 0f);

            WishSystemPanel.Append(wishButton);
            WishSystemPanel.Append(closeButton);
            WishSystemPanel.Append(wishButtonx10);
            WishSystemPanel.Append(WishingSystemBanner);
            Append(WishSystemPanel);
        }

        private void WishButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    Random random = new Random();
                    if (item.type == ModContent.ItemType<AcquiantFate>())
                    {
                        int wishItem = items[random.Next(0, items.Length)];
                        if (wishItem == ModContent.ItemType<XianglingHelmet>())
                        {
                            player.QuickSpawnItem(ModContent.ItemType<XianglingHelmet>());
                            player.QuickSpawnItem(ModContent.ItemType<XianglingBreastplate>());
                            player.QuickSpawnItem(ModContent.ItemType<XianglingLeggings>());
                        }
                        else
                        {
                            player.QuickSpawnItem(wishItem);
                        }
                        item.stack--;
                        Main.PlaySound(SoundID.Pixie);
                        for (int x = 0; x < 10; x++) { int dust = Dust.NewDust(player.position, player.height, player.width, DustID.Clentaminator_Cyan, random.Next(-3, 3), random.Next(-3, 3)); }
                        break;
                    }
                }

            }
        }

        private void WishButtonx10Clicked(UIMouseEvent evt, UIElement listeningElement)
        {
            for (int s = 0; s < 255; s++)
            {
                Player player = Main.player[s];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    Random random = new Random();
                    if (item.type == ModContent.ItemType<AcquiantFate>() && item.stack >= 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            int wishItem = items[random.Next(0, items.Length)];
                            if (wishItem == ModContent.ItemType<XianglingHelmet>())
                            {
                                player.QuickSpawnItem(ModContent.ItemType<XianglingHelmet>());
                                player.QuickSpawnItem(ModContent.ItemType<XianglingBreastplate>());
                                player.QuickSpawnItem(ModContent.ItemType<XianglingLeggings>());
                            }
                            else
                            {
                                player.QuickSpawnItem(wishItem);
                            }
                            item.stack--;
                            Main.PlaySound(SoundID.Pixie);
                            for (int x = 0; x < 10; x++) { int dust = Dust.NewDust(player.position, player.height, player.width, DustID.Clentaminator_Cyan, random.Next(-3, 3), random.Next(-3, 3)); }
                            
                        }
                        break;
                        
                    }
                }

            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuClose);
            Visible = false;
        }
    }
}
