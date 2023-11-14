using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Entity.Character;

namespace Text_RPG.Entity
{
    public class CreateEntity
    {
        static List<Character.Character> characters;
        static CreateEntity()
        {
            characters = new List<Character.Character>();
        }
        public CreateEntity(string name, Data.PlayerClass playerClass)
        {
            switch (playerClass)
            {
                case Data.PlayerClass.Defender:
                    break;
                case Data.PlayerClass.Dealer:
                    break;
                case Data.PlayerClass.Healer:
                    break;
            }
        }
    }
}
