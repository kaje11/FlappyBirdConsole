using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    class Floor : Border
    {
        private int edgePosition = 0;

        override public int EdgePosition
        {
            get { return this.edgePosition; }
        }
        private Floor( Point coords, char[,] body ) : base (coords, body )
        {
            
        }

        public static Floor getFloor()
        {
            Point position = new Point(0, GameConsole.WINDOW_HEIGHT - 2);
            char[,] body = Border.getBody();

            return new Floor(position, body);
        }
    }
}
