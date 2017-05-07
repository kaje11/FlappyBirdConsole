using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    class Ceiling : Border
    {
        private int edgePosition = 1;

        override public int EdgePosition
        {
            get { return this.edgePosition; }
        }
        private Ceiling( Point coords, char[,] body ) : base (coords, body )
        {
            
        }

        public static Ceiling getCeiling()
        {
            Point position = new Point(0, 0);
            char[,] body = Border.getBody();

            return new Ceiling(position, body);
        }
    }
}
