using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    enum PipeType
    {
        TopPipe,
        BottomPipe
    }
    class Pipe : ConsoleObject
    {
        private static char[] PIPE_TOP_LID = { '|', '_', '_', '_', '_', '|' };
        private static char[] PIPE_BOTTOM_LID = { '^', '^', '^', '^', '^', '^' };
        private static char[] PIPE_BODY = { '|', ' ', ' ', ' ', ' ', '|' };
        private static int SPACE_BETWEEN_PIPES = 8;

        public static List<Pipe> gamePipes;
        public PipeType pipeType { get; private set; }

        private Pipe(Point coords, char[,] body) : base (coords, body)
        {
            if (gamePipes == null)
            {
                gamePipes = new List<Pipe>(20);
            }

            gamePipes.Add(this);
            
        }
        public static Pipe[] getPipes()
        {
            Random randomSeed = new Random();
            int availableSpace = GameConsole.WINDOW_HEIGHT - SPACE_BETWEEN_PIPES;

            int topPipeHeight = randomSeed.Next(3, availableSpace - 2);
            int bottomPipeHeight = availableSpace - topPipeHeight;

            Pipe topPipe = Pipe.getTopPipe(topPipeHeight);
            topPipe.pipeType = PipeType.TopPipe;

            Pipe bottomPipe = Pipe.getBottomPipe(bottomPipeHeight);
            bottomPipe.pipeType = PipeType.BottomPipe;

            topPipe.setPosition(GameConsole.WINDOW_WIDTH, 0);
            bottomPipe.setPosition(GameConsole.WINDOW_WIDTH, GameConsole.WINDOW_HEIGHT - bottomPipeHeight);

            return new Pipe[2] { topPipe, bottomPipe };
        }

        private static Pipe getTopPipe(int height)
        {
            char[,] pipe = new char[height, PIPE_TOP_LID.Length];
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < PIPE_BODY.Length; j++)
                {
                    pipe[i, j] = PIPE_BODY[j];
                }
            }
            for (int i = 0; i < PIPE_TOP_LID.Length; i++)
            {
                pipe[height - 1, i] = PIPE_TOP_LID[i];
            }
            return new Pipe(new Point(0, 0), pipe);
        }
        public static Pipe getBottomPipe(int height)
        {
            char[,] pipe = new char[height, PIPE_BOTTOM_LID.Length];
            for (int i = 0; i < PIPE_BOTTOM_LID.Length; i++)
            {
                pipe[0, i] = PIPE_BOTTOM_LID[i];
            }

            for (int i = 1; i < height; i++)
            {
                for (int j = 0; j < PIPE_BODY.Length; j++)
                {
                    pipe[i, j] = PIPE_BODY[j];
                }
            }

            return new Pipe(new Point(0, 0), pipe);
        }
    }
}
