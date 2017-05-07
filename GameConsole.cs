using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    class GameConsole
    {
        public static char CHAR_INVISIBLE = Char.MinValue;
        public static char CHAR_INVISIBLE_COLLIDING = (char)(Char.MinValue + 1);
        private static int ADDITIONAL_SPACE = 5;
        private static int MAX_OBJECTS = 50;

        private List<ConsoleObject> objects;
        private int objectsCount = 0;
        private char[,] board;
        public static int WINDOW_WIDTH { get; private set; }
        public static int WINDOW_HEIGHT { get; private set; }
        private char background = ' ';

        public void setBackground(char c)
        {
            this.background = c;
        }
        public void addObject(ConsoleObject obj)
        {
            if (objectsCount + 1 > MAX_OBJECTS)
            {
                throw new Exception();
            }
            else
            {
                this.objects.Add(obj);
                this.objectsCount++;
            }
        }
        public void removeObject(int id)
        {
            this.objects.RemoveAll(x => x.getId() == id);
            this.objectsCount--;
        }
        // public 
        public void removeNullFromList()
        {
            this.objects.RemoveAll(item => item == null);
        }
        public static GameConsole getHandler()
        {
            GameConsole consoleHandler = new GameConsole();
            System.Console.CursorVisible = false;
            consoleHandler.empty();
            return consoleHandler;
        }
        private GameConsole()
        {
            WINDOW_HEIGHT = System.Console.WindowHeight;
            WINDOW_WIDTH = System.Console.WindowWidth - 1;
            this.objects = new List<ConsoleObject>(MAX_OBJECTS);
            this.board = new char[WINDOW_HEIGHT, WINDOW_WIDTH + ADDITIONAL_SPACE];
        }
        private void empty()
        {
            this.fillConsoleWithCharacter(this.background);
        }
        public void fillConsoleWithCharacter(char c)
        {
            for (int column = 0; column < WINDOW_HEIGHT; column++)
            {
                for (int row = 0; row < WINDOW_WIDTH; row++)
                {
                    this.board[column, row] = c;
                }
            }
        }

        public int centerPosition(String str)
        {
            return (int)(GameConsole.WINDOW_WIDTH / 2 - str.Length / 2);
        }
        public void printToConsole(Point coords, string text)
        {
            System.Console.SetCursorPosition(coords.x, coords.y);
            System.Console.Write(text);
        }
        public void clearConsole()
        {
            System.Console.Clear();
        }
        private void setElements()
        {
            foreach (ConsoleObject obj in objects)
            {
                for (int i = 0; i < obj.body.GetLength(0); i++) //height
                {
                    for (int j = 0; j < obj.body.GetLength(1); j++) //width
                    {
                        Point goalPos = new Point(obj.getYPosition() + i, obj.getXPosition() + j);
                        if (!isOutOfBounds(goalPos) && obj.body[i, j] != GameConsole.CHAR_INVISIBLE)
                        {
                            this.board[goalPos.x, goalPos.y] = obj.body[i, j];
                        }
                    }
                }
            }
        }

        private bool isOutOfBounds(Point point)
        {
            if (point.x < WINDOW_HEIGHT
                   && point.y < WINDOW_WIDTH
                   && point.x >= 0
                   && point.y >= 0)
            {
                return false;
            }
            return true;

        }
        private void sortElements()
        {
            this.objects = this.objects.OrderBy(o => o.getOrder()).ToList();
        }
        public void draw()
        {
            empty();
            sortElements();
            setElements();

            string finalDraw = "";

            for (int column = 0; column < WINDOW_HEIGHT; column++)
            {
                for (int row = 0; row < WINDOW_WIDTH; row++)
                {
                    finalDraw += this.board[column, row];
                }
                finalDraw += "\n";
            }

            clearConsole();
            System.Console.Write(finalDraw);
            System.Console.SetCursorPosition(0, 0);
        }
    }
}
