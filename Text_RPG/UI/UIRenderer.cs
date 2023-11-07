﻿using System;
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
                if (i == 0)
                {
                    Console.Write("┌" + new string('─', width - 2) + "┐");
                }
                else if (i == itemCount + 1)
                {
                    Console.Write("└" + new string('─', width - 2) + "┘");
                }
                else
                {
                    Console.Write("│" + new string(' ', width - 2) + "│");
                }
            }
        }

        public static void DrawCharacterMenuBox(int width, int itemCount)
        {
            string topLeft = "┌";
            string topRight = "┐";
            string middleLeft = "├";
            string middleRight = "┤";
            string bottomLeft = "└";
            string bottomRight = "┘";
            char horizontal = '─';
            string topVertical = "┬";
            string bottomVertical = "┴";
            string vertical = "│";

            for (int i = 0; i < itemCount - 1; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - width) / 2 + 3, (Console.WindowHeight) - 28 + i);
                if (i == 0)
                {
                    Console.Write(topLeft + new string(horizontal, width - 2) + topRight);
                }
                else
                {
                    Console.Write(vertical + new string(' ', width - 2) + vertical);
                }
            }
            for (int i = 0; i < itemCount - 2; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - width) / 2 + 3, (Console.WindowHeight) - 24 + i );
                if (i == 0)
                {
                    Console.Write(middleLeft + new string(horizontal, width / 2 - 3) + topVertical + new string(horizontal, width / 2) + middleRight);
                }
                else if (i == itemCount - 3)
                {
                    Console.Write(bottomLeft + new string(horizontal, width / 2 - 3) + bottomVertical + new string(horizontal, width / 2) + bottomRight);
                }
                else
                {
                    Console.Write(vertical + new string(' ', width / 2 - 3) + vertical + new string(' ', width / 2) + vertical);
                }
            }
        }

        public static void DrawCenteredStringInBox(string str, int boxWidth, int yOffset = 0)
        {
            int leftOffset = (boxWidth - str.Length) / 2;
            Console.SetCursorPosition((Console.WindowWidth - boxWidth) / 2 + leftOffset, Console.CursorTop + yOffset);
            Console.Write(str);
        }

        public static void DrawHorizontalLine(int width)
        {
            Console.WriteLine($"+{new string('─', width - 2)}+");
        }

        public static void DrawBoxWithPosition(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);

                if (i == 0)
                {
                    Console.Write("┌" + new string('─', width - 2) + "┐");
                }
                else if (i == height - 1)
                {
                    Console.Write("└" + new string('─', width - 2) + "┘");
                }
                else
                {
                    Console.Write("│" + new string(' ', width - 2) + "│");
                }
            }
        }
    }
}
