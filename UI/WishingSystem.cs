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
using GenshinImpactMod.Weapons.Swords;
using GenshinImpactMod.Weapons.Claymores;


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
            WishSystemPanel.Width.Set(600f, 0f);
            WishSystemPanel.Height.Set(300f, 0f);
            Texture2D wishButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonPlay");

            UIHoverImageButton wishButton = new UIHoverImageButton(wishButtonTexture, "Wish");
            wishButton.Left.Set(432f, 0f);
            wishButton.Top.Set(64f, 0f);
            wishButton.Width.Set(88f, 0f);
            wishButton.Height.Set(88f, 0f);
            wishButton.OnClick += new MouseEvent(WishButtonClicked);
            

            Texture2D deleteButtonTexture = ModContent.GetTexture("Terraria/UI/ButtonDelete");
            UIHoverImageButton closeButton = new UIHoverImageButton(deleteButtonTexture, Language.GetTextValue("LegacyInterface.52"));
            closeButton.Left.Set(536f, 0f);
            closeButton.Top.Set(240f, 0f);
            closeButton.Width.Set(32f, 0f);
            closeButton.Height.Set(32f, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            

            Texture2D wishingSystemBanner = ModContent.GetTexture("GenshinImpactMod/UI/WishingSystem");
            WishingSystemBanner = new UIImage(wishingSystemBanner);
            WishingSystemBanner.Left.Set(0f, 0f);
            WishingSystemBanner.Top.Set(0f, 0f);
            WishingSystemBanner.Width.Set(600f, 0);
            WishingSystemBanner.Height.Set(300f, 0f);

            WishSystemPanel.Append(wishButton);
            WishSystemPanel.Append(closeButton);
            WishSystemPanel.Append(WishingSystemBanner);
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
                        var randomitem = ModContent.ItemType<WasterGreatsword>();
                        switch (Main.rand.Next(1, 4))
                        {
                            case 1:
                                randomitem = ModContent.ItemType<SkyriderGreatSword>();
                                break;

                            case 2:
                                randomitem = ModContent.ItemType<BlackCliffPole>();
                                break;

                            case 3:
                                randomitem = ModContent.ItemType<HarbingersDawn>();
                                break;

                            default:
                                randomitem = ModContent.ItemType<WasterGreatsword>() ;
                                break;
                        }
                        player.QuickSpawnItem(randomitem);
                        item.TurnToAir();
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
