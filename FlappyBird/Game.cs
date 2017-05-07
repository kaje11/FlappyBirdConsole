using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole.FlappyBird
{
    class Game
    {
        private readonly string RESTART_MESSAGE = "Press [Enter] to RESTART the game";
        private readonly string QUIT_MESSAGE = "Press [ESC] to QUIT the game";
        private readonly string SCORE_MESSAGE = "Score: {0}";
        private readonly string HIGHSCORE_MESSAGE = "Highscore: {0}";

        private readonly char[,] GAME_OVER = ConsoleObject.stringTo2DArray(
            "  _____                         ____                 \n" +
            " / ____|                       / __ \\                \n" +
            "| |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ \n" +
            "| | |_ |/ _` | '_ ` _ \\ / _ \\ | |  | \\ \\ / / _ \\ '__|\n" +
            "| |__| | (_| | | | | | |  __/ | |__| |\\ V /  __/ |   \n" +
            " \\_____|\\__,_|_| |_| |_|\\___|  \\____/  \\_/ \\___|_|   ");

        public GameConsole myConsole;
        private int frame = 0;
        private Flappy flappyBird;
        private Floor floor;
        private Ceiling ceiling;

        private Score score;

        public Game()
        {
            Pipe.gamePipes = null;
            myConsole = GameConsole.getHandler();
        }
        public void setupScene()
        {
            myConsole.setBackground(' ');
            myConsole.draw();

            flappyBird = Flappy.createFlappy();
            flappyBird.setOrder(3);
            myConsole.addObject(flappyBird);

            floor = Floor.getFloor();
            floor.setOrder(2);

            ceiling = Ceiling.getCeiling();
            ceiling.setOrder(4);

            score = Score.createScore();
            score.setOrder(5);

            myConsole.addObject(score);
            myConsole.addObject(ceiling);
            myConsole.addObject(floor);
        }
        public void mainLoop()
        {
            do
            {
                System.Threading.Thread.Sleep(60);
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            flappyBird.addJump();
                            break;
                        case ConsoleKey.Q:
                            return;
                    }
                }


                flappyBird.jump();

                movePipes();

                floor.moveBorder();
                ceiling.moveBorder();
                score.animateScore();

                drawGame();
                incFrame();
            } while (!flappyHasCollided());
        }
        public static UserAction getUserAction()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        return UserAction.QUIT;
                    case ConsoleKey.Enter:
                        return UserAction.CONTINUE;
                }
            }
        }
        private bool flappyHasCollided()
        {
            if (flappyBird.collidesWithPipes(Pipe.gamePipes))
                return true;

            if (flappyBird.getYPosition() == floor.getYPosition() - 3)
                return true;

            if (flappyBird.getYPosition() == ceiling.getYPosition() + 1)
                return true;

            return false;
        }
        private void drawGame()
        {
            this.myConsole.draw();
        }
        private void incFrame()
        {
            this.frame++;
        }

        public void gameOver()
        {
            this.score.saveScore();

            char[,] gameOverBody = this.GAME_OVER;
            Point pos = new Point(
                (int)(GameConsole.WINDOW_WIDTH / 2 - this.GAME_OVER.GetLength(1) / 2),
                (int)(GameConsole.WINDOW_HEIGHT / 2 - this.GAME_OVER.GetLength(0) / 2));

            ConsoleObject gameOver = new ConsoleObject(pos, gameOverBody);
            myConsole.addObject(gameOver);
            myConsole.removeObject(score.getId());
            drawGame();

            Point quitPos = new Point(myConsole.centerPosition(QUIT_MESSAGE), 19);
            myConsole.printToConsole(quitPos, QUIT_MESSAGE);

            Point restartPos = new Point(myConsole.centerPosition(RESTART_MESSAGE), 17);
            myConsole.printToConsole(restartPos, RESTART_MESSAGE);

            string myScore = String.Format(SCORE_MESSAGE, this.score.getScore());
            Point scorePos = new Point(myConsole.centerPosition(myScore), 5);
            myConsole.printToConsole(scorePos, myScore);

            string highScore = String.Format(HIGHSCORE_MESSAGE, this.score.getHighScore());
            Point highscorePos = new Point(myConsole.centerPosition(highScore), 7);
            myConsole.printToConsole(highscorePos, highScore);
        }

        private void movePipes()
        {
            if (this.frame % 25 == 0)
            {
                Pipe[] pipes = Pipe.getPipes();

                myConsole.addObject(pipes[0]);
                myConsole.addObject(pipes[1]);
            }
            int cnt = Pipe.gamePipes.Count;
            for (int obj = cnt - 1; obj >= 0; obj--)
            {
                Pipe myObj = Pipe.gamePipes[obj];
                myObj.move(-1, 0);
                if (myObj.getXPosition() <= -3)
                {
                    myConsole.removeObject(myObj.getId());
                    Pipe.gamePipes.RemoveAll(x => x.getId() == myObj.getId());
                }
                else if (myObj.pipeType == PipeType.TopPipe
                    && myObj.getXPosition() == flappyBird.getXPosition())
                {
                    this.score.incrementScore();
                }
            }
        }

    }
}
