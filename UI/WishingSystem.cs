﻿/* Current notes for UI
 * 
 * 
 * 1 Finish the CloseButton method
 * 
 * 2 Add item values
 */








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
using Terraria.GameContent.UI.Elements;


namespace GenshinImpactMod.UI
{
    internal class WishingSystem : UIState
    {
        public DragableUI WishSystemPanel;
        public UIImage WishingSystemBanner;
        public static bool Visible;

        public override void OnInitialize()
        {
            WishSystemPanel = new DragableUI();
            WishSystemPanel.Left.Set(400f, 0f);
            WishSystemPanel.Top.Set(100f, 0f);
            WishSystemPanel.Width.Set(360f, 0f);
            WishSystemPanel.Height.Set(180f, 0f);
            Texture2D wishButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");

            UIHoverImageButton wishButton = new UIHoverImageButton(wishButtonTexture, "Wish");
            wishButton.Left.Set(10f, 0f);
            wishButton.Top.Set(10f, 0f);
            wishButton.Width.Set(22f, 0f);
            wishButton.Height.Set(22f, 0f);
            wishButton.OnClick += new MouseEvent(WishButtonClicked);
            

            Texture2D deleteButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
            UIHoverImageButton closeButton = new UIHoverImageButton(deleteButtonTexture, Language.GetTextValue("LegacyInterface.52"));
            closeButton.Left.Set(30f, 0f);
            closeButton.Top.Set(10f, 0f);
            closeButton.Width.Set(22f, 0f);
            closeButton.Height.Set(22f, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            

            Texture2D wishingSystemBanner = ModContent.GetTexture("GenshinImpactMod/UI/WishingSystem");
            WishingSystemBanner = new UIImage(wishingSystemBanner);
            WishingSystemBanner.Left.Set(0f, 0f);
            WishingSystemBanner.Top.Set(0f, 0f);
            WishingSystemBanner.Width.Set(360f, 0);
            WishingSystemBanner.Height.Set(180f, 0f);

            WishSystemPanel.Append(wishButton);
            WishSystemPanel.Append(WishingSystemBanner);
            WishSystemPanel.Append(closeButton);
            Append(WishSystemPanel);
        }

        private void WishButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType</*Temporary*/IronPoint>())
                    {
                        item.SetDefaults(ItemID.Wood);
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
