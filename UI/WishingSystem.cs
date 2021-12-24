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
            ModContent.ItemType<ThrillingTalesOfDragonSlayers>()};

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
                        player.QuickSpawnItem(items[random.Next(0, items.Length)]);
                        item.stack--;
                        Main.PlaySound(SoundID.Pixie);
                        for (int x = 0; x < 10; x++) { int dust = Dust.NewDust(player.position, player.height, player.width, DustID.Clentaminator_Cyan, random.Next(-3, 3), random.Next(-3, 3)); }
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
