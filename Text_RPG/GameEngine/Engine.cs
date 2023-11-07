using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.UI;
using Text_RPG.Util;

namespace Text_RPG.GameEngine
{
    public class Engine
    {
        private InputHandler _inputHandler;
        private CharacterSelectionUI _characterUI;
        private Dictionary<string, string> _userCharacters;

        // 기본 생성자
        public Engine()
        {
            _inputHandler = new InputHandler();
            _characterUI = new CharacterSelectionUI();
            _userCharacters = new Dictionary<string, string>();
        }

        // 소멸자
        ~Engine()
        {
            
        }

        public void Init()
        {
            _inputHandler = new InputHandler();
            _characterUI = new CharacterSelectionUI();
        }

        public void Start()
        {
            StartUI.DisplayMainMenu(_inputHandler, _characterUI);
            _userCharacters = _characterUI.DisplayCharacterSelection(_inputHandler);
            Update();
        }

        private void Update()
        {
            while (true)
            {
                ConsoleKey userInput = _inputHandler.GetUserInput();
                _inputHandler.ProcessInput(userInput);
            }
        }

        public void Release()
        {
            
        }
    }
}
