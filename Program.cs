using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FlappyBirdConsole.FlappyBird;

namespace FlappyBirdConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.showMenu();

            if (Menu.getMenuAction() == UserAction.QUIT)
                return;

            Game myGame;

            do
            {
                myGame = new Game();

                myGame.setupScene();
                myGame.mainLoop();
                myGame.gameOver();
            }
            while (Game.getUserAction() != UserAction.QUIT);
        }
    }
    enum UserAction
    {
        QUIT,
        CONTINUE,
        START
    }
    
    class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
   
    
}
