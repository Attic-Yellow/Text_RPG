using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public static class StartUI
    {

        private static readonly List<string> menuNumber = new List<string>
        {
            "처음부터", // 게임 시작
            "이어 하기", // 기존 게임 이어하기
            "설정", // 게임 설정
            "종료" // 게임 종료
        };

        private static readonly BoxHandler menuBoxHandler = new BoxHandler(menuNumber);

        public static void DisplayMainMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.Menus.Count);
                menuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                menuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    PerformAction(inputHandler, characterUI, menuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
            }
        }

        private static void PerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 처음부터
                    Console.Clear();
                    // 캐릭터 선택 UI를 여기서 호출합니다.
                    var userCharacters = characterUI.DisplayCharacterSelection(inputHandler);
                    // 이후 게임 시작 로직을 여기에 추가합니다.
                    break;
                case 1: // 이어 하기
                        // 이어하기 로직을 구현하세요.
                    break;
                case 2: // 설정
                        // 설정 메뉴 로직을 구현하세요.
                    break;
                case 3: // 종료
                    Environment.Exit(0);
                    break;
            }
        }
    }
}