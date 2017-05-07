using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    class Flappy : ConsoleObject
    {
        private static char[,] FLAPPY_BIRD_BODY = new char[,]{ 
            {' ', '_', '_', '_', GameConsole.CHAR_INVISIBLE, GameConsole.CHAR_INVISIBLE, GameConsole.CHAR_INVISIBLE},
            {'/', '_', '_', 'O', '\\', '_', GameConsole.CHAR_INVISIBLE},
            {'\\', '_', '_', '_', '/', '-', '\''}
        };
        private int jumpPower = 0;
        private bool wingUp = true;
        Flappy(Point coords, char[,] body)
            : base(coords, body) { }

        public void addJump()
        {
            this.jumpPower = 4;
        }
        public void jump()
        {
            if (this.jumpPower > 0)
            {
                this.move(0, -1);
                this.jumpPower--;
                this.setBody(2, 2, wingUp ? '^' : 'V');
                this.setBody(2, 1, wingUp ? '^' : 'V');
                wingUp = !wingUp;
            }
            else if (this.jumpPower == -1)
            {
                this.move(0, 1);
            }
            else
            {
                this.setBody(2, 1, '_');
                this.setBody(2, 2, '_');
                this.jumpPower--;
            }
        }

        public bool collidesWithPipes(List<Pipe> pipes)
        {
            if (pipes == null) return false;

            foreach (Pipe pipe in pipes)
            {
                if (this.collidesWith(pipe))
                {
                    return true;
                }
            }
            return false;
        }

        public static Flappy createFlappy()
        {
            Point position = new Point(2, (int)(GameConsole.WINDOW_HEIGHT / 2) + 1);
            return new Flappy( position, FLAPPY_BIRD_BODY );
        }
    }
}
