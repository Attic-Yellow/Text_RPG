using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;
using static Text_RPG.UI.GameMenuBoxHandler;

namespace Text_RPG.UI.GameMenuUI.InventoryUI
{
    class InventoryMenuUI : CharacterMenuUI
    {
        private static readonly List<string> InventoryMenuNumber = new List<string> 
        { 
            "장비", 
            "소모품" 
        };

        protected static readonly GameBoxHandler InventoryMenuBoxHandler = new GameBoxHandler(InventoryMenuNumber);

        public static void InventoryMenuDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {

            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                UIRender.DrawInventoryMenuWorkBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                menuBoxHandler.GameMenuFirstDisplay();
                InventoryMenuBoxHandler.GameMenuSecondDisplay();

                var key = inputHandler.GetUserInput();
                InventoryMenuBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {
                    InventoryMenuPerformAction(inputHandler, characterUI, InventoryMenuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
                else if (key == ConsoleKey.V)
                {
                    DisplayCaharcterMenu(inputHandler, characterUI);
                    conti = false;
                }
            }
        }

        protected static void InventoryMenuPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    InventoryMenuItemUI.InventoryMenuItemDisplay(inputHandler, characterUI);
                    break;
                case 1: 
                    break;
            }
        }
    }
}
