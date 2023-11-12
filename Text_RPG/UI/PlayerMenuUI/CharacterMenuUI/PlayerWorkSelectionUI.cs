using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Text_RPG.UI.GameMenuBoxHandler;
using Text_RPG.UI.PlayerMenuUI.InventoryUI;
using Text_RPG.Util;
using Text_RPG.GameEngine;

namespace Text_RPG.UI.PlayerMenuUI.CharacterMenuUI
{
    class PlayerWorkSelectionUI : PlayerCharacterMenuUI
    {
        public PlayerWorkSelectionUI(CharacterSelectionUI characterSelectionUI) : base(characterSelectionUI)
        {

        }

        private static readonly List<string> PlayerWorkSelectionNumber = new List<string>
        {
            "장비",
            "소모품"
        };

        protected static readonly GameBoxHandler PlayerWorkSelectionBoxHandler = new GameBoxHandler(PlayerWorkSelectionNumber);

        public void PlayerWorkSelectionDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI, Engine engine)
        {

            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                UIRender.DrawCharacterMenuWorkBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                menuBoxHandler.GameMenuFirstDisplay();
                PlayerMenuBoxHandler.GameMenuSecondOnlyPlayerDisplay();
                PlayerMenuNameBoxHandler.GameMenuFourthOnlyPlayerDisplay();
                PlayerWorkSelectionBoxHandler.GameMenuThirdDisplay();

                var key = inputHandler.GetUserInput();
                PlayerWorkSelectionBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {
                    PlayerWorkSelectionPerformAction(inputHandler, characterUI, PlayerWorkSelectionBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
                else if (key == ConsoleKey.V)
                {
                    PlayerMenuDisplay(inputHandler, characterUI, engine);
                    conti = false;
                }
                else if(key == ConsoleKey.C)
                {
                    DisplayCaharcterMenu(inputHandler, characterUI, engine);
                    conti = false;
                }
            }
        }

        protected static void PlayerWorkSelectionPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
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
