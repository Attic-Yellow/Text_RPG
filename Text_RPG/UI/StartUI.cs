using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public class MenuBox
    {
        public List<string> Menus { get; set; }
        public int SelectedIndex { get; private set; } = 0;
        public int Width { get; set; } = 40; // 기본 너비 설정
        public int Padding { get; set; } = 2; // 내부 패딩 설정

        public MenuBox(List<string> menus)
        {
            Menus = menus;
        }

        public void NextItem()
        {
            SelectedIndex = (SelectedIndex + 1) % Menus.Count;
        }

        public void PreviousItem()
        {
            SelectedIndex = (SelectedIndex - 1 + Menus.Count) % Menus.Count;
        }
    }

    public static class StartUI
    {
        private static readonly List<string> menuNumber = new List<string>
        {
            "처음부터", // 게임 시작
            "이어 하기", // 기존 게임 이어하기
            "설정", // 게임 설정
            "종료" // 게임 종료
        };

        private static readonly MenuBox menuBox = new MenuBox(menuNumber);

        public static void DisplayMainMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            while (true)
            {
                Console.Clear();
                UIRender.DrawBox(menuBox.Width, menuNumber.Count);
                DisplayMenu();

                var key = inputHandler.GetUserInput();
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        menuBox.PreviousItem();
                        break;
                    case ConsoleKey.DownArrow:
                        menuBox.NextItem();
                        break;
                    case ConsoleKey.Enter:
                        PerformAction(inputHandler, characterUI, menuBox.SelectedIndex);
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            int topOffset = (Console.WindowHeight - menuNumber.Count) / 2;

            for (int i = 0; i < menuNumber.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - menuBox.Width) / 2 + 2, topOffset + i + 1);

                if (i == menuBox.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    UIRender.DrawCenteredStringInBox($"{menuNumber[i]} ◀", menuBox.Width);
                    Console.ResetColor();
                }
                else
                {
                    UIRender.DrawCenteredStringInBox($"  {menuNumber[i]}", menuBox.Width);
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
