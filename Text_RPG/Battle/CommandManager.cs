using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG.Battle
{
    public class CommandManager
    {
        public Command[] commands = new Command[4];
        public void AddCommand(Command command, int index)
        {
            commands[index] = command;
        }

        public void SortCommands()
        {
            for (int i = 0; i < commands.Length - 1; i++)
            {
                for (int j = 0; j < commands.Length - i - 1; j++)
                {
                    if (commands[i].priority > commands[j].priority)
                    {
                        Command temp = commands[i];
                        commands[i] = commands[j];
                        commands[j] = temp;
                    }
                }
            }
        }
        public void ExecuteCommand()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Execute();
            }
        }
    }
}
