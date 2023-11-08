using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    class GameMenuBoxHandler
    {
        public class GameMenuBox
        {
            public List<string> GameMenus { get; set; }
            public int SelectedIndex { get; private set; } = 0;
            public int Width { get; set; } = 110;
            public int Padding { get; set; } = 4;

            public GameMenuBox(List<string> gamemenus)
            {
                GameMenus = gamemenus;
            }

            public void NextItem()
            {
                SelectedIndex = (SelectedIndex + 1) % GameMenus.Count;
            }

            public void PreviousItem()
            {
                SelectedIndex = (SelectedIndex - 1 + GameMenus.Count) % GameMenus.Count;
            }
        }

        public class GameBoxHandler
        {
            public GameMenuBox Box { get; private set; }

            public GameBoxHandler(List<string> menuNumbers, int width = 110)
            {
                Box = new GameMenuBox(menuNumbers) { Width = width };
            }

            public void GameMenuFirstDisplay()
            {
                int topOffset = (Console.WindowHeight - Box.GameMenus.Count) / 2 - 8;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 5;
                int spaceBetween = (Box.Width - Box.GameMenus.Sum(s => s.Length)) / (Box.GameMenus.Count);

                Console.SetCursorPosition(leftOffset, topOffset);
                for (int i = 0; i < Box.GameMenus.Count; i++)
                {

                    if (i == Box.SelectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Box.GameMenus[i] + " ◀");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Box.GameMenus[i]);
                    }

                    if (i < Box.GameMenus.Count - 1)
                    {
                        Console.Write(new string(' ', spaceBetween));
                    }
                }
                Console.WriteLine();
            }

            public void GameMenuSecondDisplay()
            {
                int topOffset = (Console.WindowHeight - Box.GameMenus.Count) / 2 - 8;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (15 - Box.GameMenus.Count);
                int spaceBetween = (Box.Width / 2) - 35;

                Console.SetCursorPosition(leftOffset, topOffset);

                for (int i = 0; i < Box.GameMenus.Count; i++)
                {

                    if (i == Box.SelectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Box.GameMenus[i] + " ◀");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Box.GameMenus[i]);
                    }

                    if (i < Box.GameMenus.Count - 1)
                    {
                        Console.Write(new string(' ', spaceBetween));
                    }
                }
            }

            public void GameMenuThirdDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
            {
                int topOffset = (Console.WindowHeight - Box.GameMenus.Count) / 2 - 8;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (65 - Box.GameMenus.Count);
                int spaceBetween = (Box.Width / 2) - 35;

                Console.SetCursorPosition(leftOffset, topOffset);
                for (int i = 0; i < Box.GameMenus.Count; i++)
                {
                    

                    if (i == Box.SelectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Box.GameMenus[i] + " ◀");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Box.GameMenus[i]);
                    }

                    if (i < Box.GameMenus.Count - 1)
                    {
                        Console.Write(new string(' ', spaceBetween));
                    }
                }
            }

            public void GameMenuFourthdDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI)
            {
                int topOffset = (Console.WindowHeight - Box.GameMenus.Count) / 2 - 2;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (15 - Box.GameMenus.Count);

                for (int i = 0; i < Box.GameMenus.Count; i++)
                {
                    Console.SetCursorPosition(leftOffset, topOffset++);

                    if (i == Box.SelectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Box.GameMenus[i] + " ◀");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Box.GameMenus[i]);
                    }

                    if (i < Box.GameMenus.Count - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }

            public void GameMenuTestDisplay(InputHandler inputHandler, CharacterSelectionUI characterUI, int selectedIndex)
            {
                int topOffset = (Console.WindowHeight - Box.GameMenus.Count) / 2 - 5;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 8;
                int spaceBetween = (Box.Width / 2);

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
                    case ConsoleKey.UpArrow:
                        Box.PreviousItem();
                        break;
                    case ConsoleKey.DownArrow:
                        Box.NextItem();
                        break;
                }
            }
        }
    }
}
