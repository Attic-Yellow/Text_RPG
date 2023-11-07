using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class CreateCharacter
    {
        Character _player;
        CharacterStat _stat;

        public CreateCharacter(string name, string selectedClass)
        {
            switch (selectedClass)
            {
                case "전사":
                    _player = new Warrior(name);
                    break;
                case "마법사":
                    _player = new Mage(name);
                    break;
                case "궁수":
                    _player = new Archer(name);
                    break;
            }
            _stat = new CharacterStat(_player);
            
        }
    }
}
