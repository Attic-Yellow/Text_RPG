using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public class CharacterSelectionUI
    {
        private List<string> availableCharacters = new List<string> { "전사", "마법사", "궁수" };
        private Dictionary<string, string> selectedCharacters = new Dictionary<string, string>();
        private int selectedIndex = 0;

        public Dictionary<string, string> DisplayCharacterSelection(InputHandler inputHandler)
        {
            int boxWidth = 30;

            while (selectedCharacters.Count < 3)
            {
                Console.Clear();
                DisplaySelectedCharacters();
                UIRender.DrawBox(boxWidth, availableCharacters.Count);
                DisplayAvailableCharacters(boxWidth);

                var key = inputHandler.GetUserInput();

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(selectedIndex - 1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(selectedIndex + 1, availableCharacters.Count - 1);
                        break;
                    case ConsoleKey.Enter:
                        string selectedClass = availableCharacters[selectedIndex];
                        Console.Clear();

                        // 텍스트 박스의 크기와 위치 계산
                        boxWidth = 40;
                        int boxHeight = 3; // 박스의 높이

                        // 텍스트 박스 그리기
                        UIRender.DrawBox(boxWidth, boxHeight);

                        // 캐릭터 이름 입력
                        int startX = (Console.WindowWidth - boxWidth) / 2 + 5;
                        int startY = (Console.WindowHeight - boxHeight) / 2 + 2;
                        Console.SetCursorPosition(startX, startY);
                        Console.Write($"{selectedClass}의 이름: ");
                        string name = Console.ReadLine();

                        string keyToSave = $" ※ {selectedClass}{selectedCharacters.Count + 1}";
                        selectedCharacters[keyToSave] = name;
                        selectedIndex = 0;
                        break;
                }
            }
            return selectedCharacters;
        }

        private void DisplayAvailableCharacters(int boxWidth)
        {
            int topOffset = (Console.WindowHeight - availableCharacters.Count) / 2;

            for (int i = 0; i < availableCharacters.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - boxWidth) / 2 + 2, topOffset + i + 1);

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    UIRender.DrawCenteredStringInBox($"{availableCharacters[i]} ◀", boxWidth);
                    Console.ResetColor();
                }
                else
                {
                    UIRender.DrawCenteredStringInBox($"  {availableCharacters[i]}", boxWidth);
                }
            }
        }

        public void DisplaySelectedCharacters()
        {
            int boxWidth = Console.WindowWidth - 2;
            int boxHeight = Math.Min(4 + selectedCharacters.Count + 1, Console.WindowHeight);
            int startPosY = Console.WindowHeight - boxHeight - 1;

            UIRender.DrawBoxWithPosition(0, startPosY, boxWidth, boxHeight);

            int currentPosY = startPosY + 1;

            Console.SetCursorPosition(0, currentPosY++);
            Console.WriteLine($"│ 선택된 직업 :".PadRight(boxWidth - 6) + "│");

            foreach (var entry in selectedCharacters)
            {
                Console.SetCursorPosition(0, currentPosY++);
                Console.WriteLine($"│ {entry.Key} [{entry.Value}]".PadRight(boxWidth - 4) + "│");
            }

            while (currentPosY < startPosY + boxHeight - 1)
            {
                Console.SetCursorPosition(0, currentPosY++);
                Console.WriteLine("│".PadRight(boxWidth - 1) + "│");
            }
        }

    }
}

