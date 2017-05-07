using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{

    class ConsoleObject
    {
        private static int idInc = 0;
        private readonly int id;
        public char[,] body { get; private set; }
        private Point coords;
        private int order;

        public ConsoleObject()
        {
            this.id = idInc++;
            this.body = new char[0, 0];
            this.coords = new Point(0, 0);
        }
        public ConsoleObject(Point coords, char[,] body)
        {
            this.id = idInc++;
            this.body = body;
            this.coords = coords;
        }
        public int getOrder()
        {
            return this.order;
        }

        public static char[,] stringTo2DArray(String body) //only 2d array
        {
            string[] rows = body.Split('\n');
            int rowCount = rows.Length,
                columnCount = rows[0].Length;

            char[,] array2D = new char[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    array2D[i, j] = rows[i][j];
                }
            }

            return array2D;
        }
        public static char[,] appendBody(char[,] bodyOne, char[,] bodyTwo)
        {
            int rowOne = bodyOne.GetLength(0),
                rowTwo = bodyTwo.GetLength(0),
                columnOne = bodyOne.GetLength(1),
                columnTwo = bodyTwo.GetLength(1);

            char[,] newBody = new char[rowOne, columnOne + columnTwo];
            for (int i = 0; i < rowOne; i++)
            {
                for (int j = 0; j < columnOne; j++)
                {
                    newBody[i, j] = bodyOne[i, j];
                }
            }

            for (int i = 0; i < rowOne; i++)
            {
                for (int j = columnOne; j < columnOne + columnTwo; j++)
                {
                    newBody[i, j] = bodyTwo[i, j - columnOne];
                }
            }
            return newBody;
        }
        public bool collidesWith(ConsoleObject obj)
        {
            int widthOne = this.body.GetLength(1), // 7
                widthTwo = obj.body.GetLength(1), //6
                heightOne = this.body.GetLength(0), // 3
                heightTwo = obj.body.GetLength(0); //15


            for (int i = this.coords.y; i < this.coords.y + heightOne; i++)
            {
                for (int j = this.coords.x; j < this.coords.x + widthOne; j++)
                {
                    if (j < obj.coords.x + widthTwo &&
                        j >= obj.coords.x &&
                        i < obj.coords.y + heightTwo &&
                        i >= obj.coords.y)
                    {
                        if (obj.body[i - obj.coords.y, j - obj.coords.x] != GameConsole.CHAR_INVISIBLE)
                        {
                            if (this.body[i - this.coords.y, j - this.coords.x] != GameConsole.CHAR_INVISIBLE)
                            {
                                this.setBody(j - this.coords.y, i - this.coords.x, 'X');
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void setOrder(int order)
        {
            this.order = order;
        }
        public int getId()
        {
            return this.id;
        }
        public int getXPosition()
        {
            return coords.x;
        }
        public int getYPosition()
        {
            return coords.y;
        }
        public void setBody(char[,] newBody)
        {
            this.body = newBody;
        }
        public void setBody(int x, int y, char c)
        {
            if (x >= 0 && y >= 0
                && x < this.body.GetLength(0)
                && y < this.body.GetLength(1))
            {
                this.body[x, y] = c;
            }
        }
        public void setPosition(int x, int y)
        {
            this.coords = new Point(x, y);
        }
        public void setXPosition(int x)
        {
            this.coords = new Point(x, this.getYPosition());
        }
        public void setYPosition(int y)
        {
            this.coords = new Point(this.getXPosition(), y);
        }

        public void move(int x, int y)
        {
            this.coords = new Point(this.coords.x + x, this.coords.y + y);
        }
    }
}
