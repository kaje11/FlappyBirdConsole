using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdConsole
{
    class Score : ConsoleObject
    {
        private int 
            score = 0,
            scoreAnimUp = 0,
            scoreAnimDown = 0;

        private static int highScore = 0;

        public void saveScore()
        {
            if (this.score > Score.highScore)
            {
                Score.highScore = this.score;
            }
        }

        public static Score createScore()
        {
            Score scoreObj = new Score();
            scoreObj.setBody( ASCIICommon.getBigDigit(scoreObj.score) );
            scoreObj.setYPosition((int)(GameConsole.WINDOW_HEIGHT / 2) - (int)(scoreObj.body.GetLength(0)/2));
            scoreObj.setScorePosition();
            return scoreObj;
        }

        public void addScore(int inc)
        {
            this.score += inc;
        }
        public void animateScore()
        {
            if (scoreAnimUp > 0)
            {
                scoreAnimUp--;
                this.move(0, -1);
            }
            else if (scoreAnimDown > 0)
            {
                scoreAnimDown--;
                this.move(0, 1);
            }
        }
        int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
        private void setScorePosition()
        {
            this.setXPosition((int)(GameConsole.WINDOW_WIDTH / 2) - (int)(this.body.GetLength(1) / 2));
        }

        public int getScore()
        {
            return this.score;
        }
        public int getHighScore()
        {
            return Score.highScore;
        }
        public void incrementScore()
        {
            this.score++;
            this.scoreAnimUp = 3;
            this.scoreAnimDown = 3;

            int[] listOfInts = GetIntArray(this.score);
            char[,] newScore = ASCIICommon.getBigDigit( listOfInts[ 0 ] );
            for( int i = 1;i < listOfInts.Length;i++ )
            {
                newScore = ConsoleObject.appendBody(newScore, ASCIICommon.getBigDigit( listOfInts[ i ] ) );
            }

            this.setBody(newScore);
            this.setScorePosition();
        }
    }
}
