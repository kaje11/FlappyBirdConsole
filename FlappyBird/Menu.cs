using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole.FlappyBird
{
    class Menu
    {
        private readonly string START_MESSAGE = "Press [Up] to START the game";
        private readonly string QUIT_MESSAGE = "Press [ESC] to QUIT the game";

        private readonly char[,] START_MENU = ConsoleObject.stringTo2DArray(
            " ______ _                           ____  _         _ \n" +
            "|  ____| |                         |  _ \\(_)       | |\n" +
            "| |__  | | __ _ _ __  _ __  _   _  | |_) |_ _ __ __| |\n" +
            "|  __| | |/ _` | '_ \\| '_ \\| | | | |  _ <| | '__/ _` |\n" +
            "| |    | | (_| | |_) | |_) | |_| | | |_) | | | | (_| |\n" +
            "|_|    |_|\\__,_| .__/| .__/ \\__, | |____/|_|_|  \\__,_|\n" +
            "               | |   | |     __/ |                    \n" +
            "               |_|   |_|    |___/                     ");

        public GameConsole myConsole;

        public Menu()
        {
            myConsole = GameConsole.getHandler();
        }
        public void showMenu()
        {
            myConsole.setBackground(' ');
            myConsole.draw();

            char[,] startMenuBody = this.START_MENU;
            Point pos = new Point(
                (int)(GameConsole.WINDOW_WIDTH / 2 - this.START_MENU.GetLength(1) / 2),
                (int)(GameConsole.WINDOW_HEIGHT / 2 - this.START_MENU.GetLength(0) / 2));

            ConsoleObject logo = new ConsoleObject(pos, startMenuBody);
            myConsole.addObject(logo);
            myConsole.draw();

            Point quitPos = new Point(myConsole.centerPosition(QUIT_MESSAGE), 19);
            myConsole.printToConsole(quitPos, QUIT_MESSAGE);

            Point startPos = new Point(myConsole.centerPosition(START_MESSAGE), 17);
            myConsole.printToConsole(startPos, START_MESSAGE);

        }

        public static UserAction getMenuAction()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        return UserAction.QUIT;
                    case ConsoleKey.UpArrow:
                        return UserAction.START;
                }
            }
        }
    }
}
