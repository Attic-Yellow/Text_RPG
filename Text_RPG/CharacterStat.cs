using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_RPG
{
    public class CharacterStat
    {
        List<Character> characters;
        public CharacterStat()
        {

        }
        public void AddCharacter(Character character)
        {
            charcters.Add(character);
        }
        public List<Character> GetCharacters()
        {
            return characters;
        }
    }
}
