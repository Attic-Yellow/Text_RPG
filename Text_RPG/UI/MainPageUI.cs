using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public class MainPageMenuBox
    {
        public List<string> MainPageMenus { get; set; }
        public int SelectedIndex { get; private set; } = 0;
        public int Width { get; set; } = 40; 
        public int Padding { get; set; } = 2; 

        public MainPageMenuBox(List<string> mainPageMenus)
        {
            MainPageMenus = mainPageMenus;
        }

        public void NextMainPageMenu()
        {
            SelectedIndex = (SelectedIndex + 1) % MainPageMenus.Count;
        }

        public void PreviousMainPageMenu()
        {
            SelectedIndex = (SelectedIndex - 1 + MainPageMenus.Count) % MainPageMenus.Count;
        }
    }

    public static class MainPageUI
    {
        private static readonly List<string> mainPageMenuNumber = new List<string>
        {
            "탐색 하기",
            "캐릭터 메뉴", 
            "상점 구매/판매",
            "설정",
            "저장 하기",
            "종료 하기"
        };

        private static readonly MainPageMenuBox mainPageMenuBox = new MainPageMenuBox(mainPageMenuNumber);

        public static void DisplayMainPageMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            while (true)
            {
                Console.Clear();
                UIRender.DrawBox(mainPageMenuBox.Width, mainPageMenuNumber.Count);
                DisplayMainPageMenu();

                var key = inputHandler.GetUserInput();
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        mainPageMenuBox.PreviousMainPageMenu();
                        break;
                    case ConsoleKey.DownArrow:
                        mainPageMenuBox.NextMainPageMenu();
                        break;
                    case ConsoleKey.Enter:
                        MainPagePerformAction(inputHandler, characterUI, mainPageMenuBox.SelectedIndex);
                        break;
                }
            }
        }

        private static void DisplayMainPageMenu()
        {
            int topOffset = (Console.WindowHeight - mainPageMenuNumber.Count) / 2;

            for (int i = 0; i < mainPageMenuNumber.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - mainPageMenuBox.Width) / 2 + 2, topOffset + i + 1);

                if (i == mainPageMenuBox.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    UIRender.DrawCenteredStringInBox($"{mainPageMenuNumber[i]} ◀", mainPageMenuBox.Width);
                    Console.ResetColor();
                }
                else
                {
                    UIRender.DrawCenteredStringInBox($"  {mainPageMenuNumber[i]}", mainPageMenuBox.Width);
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
                case 5:
                    Console.Clear();
                    break;
                case 6: // 종료
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
