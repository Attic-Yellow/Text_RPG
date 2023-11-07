using System;
using Text_RPG.GameEngine;

namespace Text_RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GameEngine 초기화
            Engine gameEngine = new Engine();
            gameEngine.Init();

            // 게임 시작
            gameEngine.Start();

            // 게임 종료 후 자원 해제 
            gameEngine.Release();
        }
        int a;
        int b;
    }
}
