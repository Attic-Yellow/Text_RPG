using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public class GameBox
    {
        public List<string> Menus { get; set; }
        public int SelectedIndex { get; private set; } = 0;
        public int Width { get; set; } = 100; // 기본 너비 설정
        public int Padding { get; set; } = 4; // 내부 패딩 설정

        public GameBox(List<string> menus)
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

    public class GameBoxHandler
    {
        public Box Box { get; private set; }

        public GameBoxHandler(List<string> menuNumbers, int width = 100)
        {
            Box = new Box(menuNumbers) { Width = width };
        }

        public void Display()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 7;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 6; 
            int spaceBetween = (Box.Width - Box.Menus.Sum(s => s.Length)) / (Box.Menus.Count);

            Console.SetCursorPosition(leftOffset, topOffset);
            for (int i = 0; i < Box.Menus.Count; i++)
            {
                
                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1) 
                {
                    Console.Write(new string(' ', spaceBetween));
                }
            }
            Console.WriteLine(); 
        }

        public void Navigate(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    Box.PreviousItem();
                    break;
                case ConsoleKey.RightArrow:
                    Box.NextItem();
                    break;
            }
        }
    }
    class CharacterMenuUI
    {
        private static readonly List<string> menuNumber = new List<string>
        {
            "캐릭터", 
            "스킬", 
            "인벤토리", 
            "지도",
            "뒤로 가기"
        };

        private static readonly GameBoxHandler menuBoxHandler = new GameBoxHandler(menuNumber);

        public static void DisplayCaharcterMenu(InputHandler inputHandler, CharacterSelectionUI characterUI)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.Menus.Count);
                menuBoxHandler.Display();

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
                    Console.Clear();
                    break;
                case 1: 
                    break;
                case 2: 
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

