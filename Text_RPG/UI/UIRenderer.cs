using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Util;

namespace Text_RPG.UI
{
    public class UIRender
    {
        public static void DrawBox(int width, int itemCount)
        {
            for (int i = 0; i < itemCount + 2; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - width) / 2 + 3, (Console.WindowHeight - itemCount) / 2 + i);
                if (i == 0 || i == itemCount + 1)
                {
                    Console.Write("+" + new string('-', width - 2) + "+");
                }
                else
                {
                    Console.Write("|" + new string(' ', width - 2) + "|");
                }
            }
        }

        public static void DrawCenteredStringInBox(string str, int boxWidth, int yOffset = 0)
        {
            int leftOffset = (boxWidth - str.Length) / 2;
            Console.SetCursorPosition((Console.WindowWidth - boxWidth) / 2 + leftOffset, Console.CursorTop + yOffset);
            Console.Write(str);
        }
    }
}
