using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ComputerPlayer:Player
    {
        /// <summary>
        /// 0 = Easiest
        /// 1 = Easy
        /// 2 = Medium
        /// 3 = Hard
        /// 4 = Hardest
        /// </summary>
        int difficultyLevel;

        public int DifficultyLevel
        {
            get { return difficultyLevel; }
            set { difficultyLevel = value; }
        }

        public ComputerPlayer(int tileType,int computerDifficulty): base("Computer", tileType)
        {
            this.difficultyLevel = computerDifficulty;
        }


        public MoveLocation getMove(GameBoard board)
        {
            switch (difficultyLevel)
            {
                case 0:
                    return probabilityMove(board,1);
                case 1:
                    return probabilityMove(board, 20);
                case 2:
                    return probabilityMove(board, 50);
                case 3:
                    return probabilityMove(board, 70);
                case 4:
                    return probabilityMove(board, 99);  
                default:
                    return probabilityMove(board, 100);  
            }
            
            
        }
 

        #region WinnigProbabilityMoveAlgorithm

        private MoveLocation probabilityMove(GameBoard board, int winningProbability)
        {

            int probability = winningProbability;

            if (winningProbability > 100)
                probability = 100;

            Random rndChoise = new Random();
            int number = rndChoise.Next(0, 100);

            if(number>(100-probability))
            {
                int[] result = minimax(2, PlayerTile, board);
                return new MoveLocation(result[1], result[2]);
            }
            else
            {
                return randomMove();
            }
           
        }

        private MoveLocation randomMove()
        {
            Random rnd = new Random();
            int randomNum;
            randomNum = rnd.Next(0, 8);

            return new MoveLocation(randomNum % 3, randomNum / 3);

        }

        #endregion

        

        #region Minimax
        private int[] minimax(int depth, int tile, GameBoard dummyBoard)
        {
            // Generate possible next moves in a List of int[2] of {row, col}.
            List<MoveLocation> nextMoves = generateNextPossibleMoves(dummyBoard);

            // mySeed is maximizing; while oppSeed is minimizing
            int bestScore = (tile == PlayerTile) ? Int32.MinValue : Int32.MaxValue;
            int currentScore;
            int bestRow = -1;
            int bestCol = -1;

            if (nextMoves.Count == 0 || depth == 0)
            {
                // Gameover or depth reached, evaluate score
                bestScore = evaluate(dummyBoard);
            }
            else
            {
                for (int i = 0; i < nextMoves.Count; i++)
                {
                    MoveLocation move = nextMoves[i];
                    // Try this move for the current "player"
                    dummyBoard.placeTile(move, tile);
                    if (tile == PlayerTile)
                    {  // mySeed (computer) is maximizing player
                        currentScore = minimax(depth - 1, -PlayerTile, dummyBoard)[0];
                        if (currentScore > bestScore)
                        {
                            bestScore = currentScore;
                            bestRow = move.X;
                            bestCol = move.Y;
                        }
                    }
                    else
                    {  // oppSeed is minimizing player
                        currentScore = minimax(depth - 1, PlayerTile, dummyBoard)[0];
                        if (currentScore < bestScore)
                        {
                            bestScore = currentScore;
                            bestRow = move.X;
                            bestCol = move.Y;
                        }
                    }
                    // Undo move
                    dummyBoard.placeTile(move, 0);
                }
            }
            return new int[] { bestScore, bestRow, bestCol };
        }

        

        private List<MoveLocation> generateNextPossibleMoves(GameBoard board)
        {
            List<MoveLocation> nextPossibleMoves = new List<MoveLocation>(); 
                       
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    MoveLocation testMove= new MoveLocation(i,j);
                    if (board.getTilevalue(testMove) == 0)
                    {
                        nextPossibleMoves.Add(testMove);
                    }
                }
            }
            return nextPossibleMoves;
        }

        /** The heuristic evaluation function for the current board
            @Return +100, +10, +1 for EACH 3-, 2-, 1-in-a-line for computer.
                    -100, -10, -1 for EACH 3-, 2-, 1-in-a-line for opponent.
                    0 otherwise   */
        private int evaluate(GameBoard board)
        {
            int score = 0;
            // Evaluate score for each of the 8 lines (3 rows, 3 columns, 2 diagonals)
            score += evaluateLine(board,0, 0, 0, 1, 0, 2);  // row 0
            score += evaluateLine(board,1, 0, 1, 1, 1, 2);  // row 1
            score += evaluateLine(board,2, 0, 2, 1, 2, 2);  // row 2
            score += evaluateLine(board,0, 0, 1, 0, 2, 0);  // col 0
            score += evaluateLine(board,0, 1, 1, 1, 2, 1);  // col 1
            score += evaluateLine(board,0, 2, 1, 2, 2, 2);  // col 2
            score += evaluateLine(board,0, 0, 1, 1, 2, 2);  // diagonal
            score += evaluateLine(board,0, 2, 1, 1, 2, 0);  // alternate diagonal
            return score;
        }

        /** The heuristic evaluation function for the given line of 3 cells
            @Return +100, +10, +1 for 3-, 2-, 1-in-a-line for computer.
                    -100, -10, -1 for 3-, 2-, 1-in-a-line for opponent.
                    0 otherwise */
        private int evaluateLine(GameBoard board, int row1, int col1, int row2, int col2, int row3, int col3)
        {
            int score = 0;

            // First cell
            if (board.getTilevalue(new MoveLocation(row1,col1)) == PlayerTile)
            {
                score = 1;
            }
            else if (board.getTilevalue(new MoveLocation(row1, col1)) == -PlayerTile)
            {
                score = -1;
            }

            // Second cell
            if (board.getTilevalue(new MoveLocation(row2, col2)) == PlayerTile)
            {
                if (score == 1)
                {   // cell1 is mySeed
                    score = 10;
                }
                else if (score == -1)
                {  // cell1 is oppSeed
                    return 0;
                }
                else
                {  // cell1 is empty
                    score = 1;
                }
            }
            else if (board.getTilevalue(new MoveLocation(row2, col2)) == - PlayerTile)
            {
                if (score == -1)
                { // cell1 is oppSeed
                    score = -10;
                }
                else if (score == 1)
                { // cell1 is mySeed
                    return 0;
                }
                else
                {  // cell1 is empty
                    score = -1;
                }
            }

            // Third cell
            if (board.getTilevalue(new MoveLocation(row3, col3)) == PlayerTile)
            {
                if (score > 0)
                {  // cell1 and/or cell2 is mySeed
                    score *= 10;
                }
                else if (score < 0)
                {  // cell1 and/or cell2 is oppSeed
                    return 0;
                }
                else
                {  // cell1 and cell2 are empty
                    score = 1;
                }
            }
            else if (board.getTilevalue(new MoveLocation(row3, col3)) == -PlayerTile)
            {
                if (score < 0)
                {  // cell1 and/or cell2 is oppSeed
                    score *= 10;
                }
                else if (score > 1)
                {  // cell1 and/or cell2 is mySeed
                    return 0;
                }
                else
                {  // cell1 and cell2 are empty
                    score = -1;
                }
            }
            return score;
        }
        #endregion
        
    }
}
