using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            StartUI.DisplayMainMenu(_inputHandler, _characterUI, this);
            _userCharacters = LoadCharacterData();
           
            Update();
        }

        private void Update()
        {
            bool running = true;
            while (running)
            {
                MainPageUI.DisplayMainPageMenu(_inputHandler, _characterUI, this);
                ConsoleKey userInput = _inputHandler.GetUserInput();
                _inputHandler.ProcessInput(userInput);
            }
        }

        public void Release()
        {
            
        }

        // 저장하기
        public void SaveCharacterData()
        {
            string path = "characterData.json";

            using (StreamWriter writer = File.CreateText(path))
            {
                string jsonString = JsonSerializer.Serialize(_userCharacters);
                writer.Write(jsonString);
            }
        }

        // 불러오기
        public Dictionary<string, string> LoadCharacterData()
        {
            using StreamReader reader = new StreamReader("characterData.json");
            string json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
    }
}