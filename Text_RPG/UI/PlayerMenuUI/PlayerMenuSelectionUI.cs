using Text_RPG.UI.PlayerMenuUI.CharacterMenuUI;
using Text_RPG.UI.PlayerMenuUI.InventoryUI;
using Text_RPG.Util;
using static Text_RPG.UI.GameMenuBoxHandler;


namespace Text_RPG.UI.PlayerMenuUI
{
    class PlayerMenuSelectionUI
    {
        private static readonly List<string> menuNumber = new List<string>
        { 
            "캐릭터", 
            "스킬", 
            "인벤토리", 
            "지도", 
            "뒤로 가기" 
        };

        protected static readonly GameBoxHandler menuBoxHandler = new GameBoxHandler(menuNumber);

        public static void DisplayCaharcterMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.GameMenus.Count);
                menuBoxHandler.GameMenuFirstDisplay();


                var key = inputHandler.GetUserInput();
                menuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    CharacterPerformAction(inputHandler, characterUI, menuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
            }
        }
        private static void CharacterPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    PlayerCharacterMenuUI playerCharacterMenuUI = new PlayerCharacterMenuUI(characterUI);
                    playerCharacterMenuUI.PlayerMenuDisplay(inputHandler, characterUI);
                    break;
                case 1:
                    break;
                case 2:
                    InventoryMenuUI.InventoryMenuDisplay(inputHandler, characterUI);
                    break;
                case 3:
                    break;
                case 4:
                    MainPageUI.DisplayMainPageMenu(inputHandler, characterUI);
                    break;
            }
        }
    }
}

