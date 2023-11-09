using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.UI.PlayerMenuUI;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public static class MainPageUI
    {
        private static readonly List<string> mainPageMenuNumber = new List<string>
        {
            " 탐색 하기 ",
            " 캐릭터 메뉴", 
            " 상점 이용 ",
            " 게임 설정 ",
            " 저장 하기 ",
            " 종료 하기 "
        };

        private static readonly BoxHandler mainPageMenuBoxHandler = new BoxHandler(mainPageMenuNumber);

        public static void DisplayMainPageMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            PlayerMenuSelectionUI characterMenuUI = new PlayerMenuSelectionUI();

            while (true)
            {
                Console.Clear();
                UIRender.DrawBox(mainPageMenuBoxHandler.Box.Width, mainPageMenuBoxHandler.Box.Menus.Count);
                mainPageMenuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                mainPageMenuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    MainPagePerformAction(inputHandler, characterUI, mainPageMenuBoxHandler.Box.SelectedIndex);
                }
            }
        }

        private static void MainPagePerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: 
                    Console.Clear();
                    break;
                case 1:
                    Console.Clear();
                    PlayerMenuSelectionUI.DisplayCaharcterMenu(inputHandler, characterUI);
                    Console.ReadKey(); 
                    break;
                case 2:
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    break;
                case 5: // 종료
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
