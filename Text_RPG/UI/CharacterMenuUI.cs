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
        public int Width { get; set; } = 110; // 기본 너비 설정
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

        public GameBoxHandler(List<string> menuNumbers, int width = 110)
        {
            Box = new Box(menuNumbers) { Width = width };
        }

        public void Display()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 8;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 5; 
            int spaceBetween = (Box.Width - Box.Menus.Sum(s => s.Length)) / (Box.Menus.Count);

            Console.SetCursorPosition(leftOffset, topOffset);
            for (int i = 0; i < Box.Menus.Count; i++)
            {
                
                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i]+" ◀");
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

        public void SecondDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 5;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 8;

            Console.SetCursorPosition(leftOffset, topOffset);

            var selectedCharacters = characterUI.DisplayCharacterSelection(inputHandler);
            int nameWidth = selectedCharacters.Max(sc => sc.Key.Length) + 4; 

            for (int i = 0; i < selectedCharacters.Count; i++)
            {
                var character = selectedCharacters.ElementAt(i);
                var key = character.Key.PadRight(nameWidth);
                var value = character.Value;

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{key}◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{key}");
                }

                if (i < selectedCharacters.Count - 1)
                {
                    Console.Write(new string(' ', nameWidth));
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

        public static void DisPlayCharacter(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            bool conti = true;
            int selectedCharactersCount = characterUI.DisplayCharacterSelection(inputHandler).Count;

            while (conti)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(menuBoxHandler.Box.Width, menuBoxHandler.Box.Menus.Count);
                menuBoxHandler.Display();
                menuBoxHandler.SecondDisplay(inputHandler, characterUI, selectedIndex);

                var key = inputHandler.GetUserInput();

                if (key == ConsoleKey.LeftArrow && selectedIndex > 0)
                {
                    selectedIndex--;  
                }
                else if (key == ConsoleKey.RightArrow && selectedIndex < selectedCharactersCount - 1)
                {
                    selectedIndex++;  
                }

                if (key == ConsoleKey.Enter)
                {
                   
                    CharacterStatusPerformAction(inputHandler, characterUI, selectedIndex);
                    conti = false; 
                }
                else if (key == ConsoleKey.V) 
                {
                    DisplayCaharcterMenu(inputHandler, characterUI);
                    conti = false;
                }
            }
        }

        private static void CharacterPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    DisPlayCharacter(inputHandler, characterUI, selectedIndex);

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

        private static void CharacterStatusPerformAction(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    DisPlayCharacter(inputHandler, characterUI, selectedIndex);
                    break;
                case 1:
                    break;
                case 2:
                    MainPageUI.DisplayMainPageMenu(inputHandler, characterUI);
                    break;
            }
        }
    }
}

