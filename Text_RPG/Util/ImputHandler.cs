using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Util
{
    public class InputHandler
    {
        public ConsoleKey GetUserInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.Key;
        }

        public void ProcessInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    // 위 방향키 입력 처리
                    break;
                case ConsoleKey.DownArrow:
                    // 아래 방향키 입력 처리
                    break;
                case ConsoleKey.LeftArrow:
                    // 왼쪽 방향키 입력 처리
                    break;
                case ConsoleKey.RightArrow:
                    // 오른쪽 방향키 입력 처리
                    break;
                case ConsoleKey.Spacebar:
                    // 공격 혹은 선택 등의 액션
                    break;
                default:
                    break;
            }
        }

        public void WaitForUserInput()
        {
            Console.ReadKey();
        }
    }

}