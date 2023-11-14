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

        }

        public void WaitForUserInput()
        {
            Console.ReadKey();
        }
    }

}