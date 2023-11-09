using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Text_RPG.UI.GameMenuBoxHandler;
using Text_RPG.Util;

namespace Text_RPG.UI.PlayerMenuUI.InventoryUI
{
    class InventoryMenuItemWorkUI : InventoryMenuItemUI
    {
        private static readonly List<string> InventoryMenuItemWorkNumber = new List<string> { "버리기", "정렬(구현 미정)" };

        protected static readonly GameBoxHandler InventoryMenuItemWorkBoxHandler = new GameBoxHandler(InventoryMenuItemWorkNumber);

        public static void InventoryMenuItemWorkDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                UIRender.DrawInventoryMenuWorkBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                menuBoxHandler.GameMenuFirstDisplay();
                InventoryMenuBoxHandler.GameMenuSecondDisplay();
                InventoryMenuItemBoxHandler.GameMenuFourthDisplay();
                InventoryMenuItemWorkBoxHandler.GameMenuThirdDisplay();

                var key = inputHandler.GetUserInput();
                InventoryMenuItemWorkBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {
                    InventoryMenuItemWorkPerformAction(inputHandler, characterUI, InventoryMenuItemWorkBoxHandler.Box.SelectedIndex);

                }
                else if (key == ConsoleKey.V)
                {
                    InventoryMenuItemDisplay(inputHandler, characterUI);
                    conti = false;
                }
                else if (key == ConsoleKey.C)
                {
                    DisplayCaharcterMenu(inputHandler, characterUI);
                    conti = false;
                }
            }
        }

        public static void InventoryMenuItemWorkPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
    }
}
