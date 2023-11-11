using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Text_RPG.UI.GameMenuBoxHandler;
using Text_RPG.Util;

namespace Text_RPG.UI.PlayerMenuUI.InventoryUI
{
    class InventoryMenuItemUI : InventoryMenuUI
    {
        private static readonly List<string> InventoryItemIndex = new List<string> { "아이템 1", "아이템 2" };

        protected static readonly GameBoxHandler InventoryMenuItemBoxHandler = new GameBoxHandler(InventoryItemIndex);

        public static void InventoryMenuItemDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
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

                var key = inputHandler.GetUserInput();
                InventoryMenuItemBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {
                    InventoryMenuItemWorkUI.InventoryMenuItemWorkDisplay(inputHandler, characterUI);

                }
                else if (key == ConsoleKey.V)
                {
                    InventoryMenuDisplay(inputHandler, characterUI);
                    conti = false;
                }
                else if (key == ConsoleKey.C)
                {
                    DisplayCaharcterMenu(inputHandler, characterUI);
                    conti = false;
                }
            }
        }
    }
}
