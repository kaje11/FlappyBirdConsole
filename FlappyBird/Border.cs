using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    abstract class Border : ConsoleObject
    {
        private bool addSpace = false;
        public abstract int EdgePosition {
            get;
        }

        protected Border(Point coords, char[,] body)
            : base(coords, body) { }

        public static char[,] getBody()
        {
            char[,] body = new char[2, GameConsole.WINDOW_WIDTH ];
            for (int i = 0; i < body.GetLength(0); i++)
                for (int j = 0; j < body.GetLength(1); j++)
                    body[i, j] = ' ';

            return body;
        }

        public void moveBorder()
        {
            for (int i = addSpace ? 0 : 1; i < this.body.GetLength(1); i += 2)
            {
                this.setBody( EdgePosition, i, ' ');
            }

            for (int i = addSpace ? 1 : 0; i < this.body.GetLength(1); i += 2)
            {
                this.setBody(EdgePosition, i, '<');
            }
            addSpace = !addSpace;
        }
    }
}
