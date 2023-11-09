using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Text_RPG.UI.GameMenuBoxHandler;
using Text_RPG.UI.PlayerMenuUI.InventoryUI;
using Text_RPG.Util;

namespace Text_RPG.UI.PlayerMenuUI.CharacterMenuUI
{
    class PlayerCharacterMenuUI : InventoryMenuUI
    {
        protected readonly GameBoxHandler? PlayerMenuBoxHandler;
        protected readonly GameBoxHandler? PlayerMenuNameBoxHandler;
        public PlayerCharacterMenuUI(CharacterSelectionUI characterSelectionUI)
        {
            IEnumerable<string> characterKeys = characterSelectionUI.GetSelectedCharacters().Keys.ToList();
            IEnumerable<string> characterValues = characterSelectionUI.GetSelectedCharacters().Values.ToList();

            PlayerMenuBoxHandler = new GameBoxHandler(characterKeys.ToList());
            PlayerMenuNameBoxHandler = new GameBoxHandler(characterValues.ToList());

        }

        public void PlayerMenuDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                UIRender.DrawInventoryMenuWorkBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                menuBoxHandler.GameMenuFirstDisplay();
                PlayerMenuBoxHandler.GameMenuSecondOnlyPlayerDisplay();
                PlayerMenuNameBoxHandler.GameMenuFourthOnlyPlayerDisplay();

                var key = inputHandler.GetUserInput();
                PlayerMenuBoxHandler.Navigate(key);
                PlayerMenuNameBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {
                    PlayerMenuPerformAction(inputHandler, characterUI, PlayerMenuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
                else if (key == ConsoleKey.V)
                {
                    DisplayCaharcterMenu(inputHandler, characterUI);
                    conti = false;
                }
            }
        }

        protected static void PlayerMenuPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    PlayerWorkSelectionUI playerWorkSelectionUI = new PlayerWorkSelectionUI(characterUI);
                    playerWorkSelectionUI.PlayerWorkSelectionDisplay(inputHandler, characterUI);
                    break;
                case 1:
                    break;
            }
        }
    }
}
