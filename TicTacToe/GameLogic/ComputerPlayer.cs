using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ComputerPlayer:Player
    {
        int difficultyLevel;
        public ComputerPlayer(int tileType,int computerDifficulty): base("Computer", tileType)
        {
            this.difficultyLevel = computerDifficulty;
        }


        public MoveLocation getMove(GameBoard board)
        {
            return easyMove();
        }

        private MoveLocation easyMove()
        {
            Random rnd = new Random();
            int randomNum;
            randomNum = rnd.Next(0, 8);

            return new MoveLocation(randomNum % 3, randomNum / 3);
            
        }


        //public Boolean winningMove()
        //{

        //    int matchingMovesCount = 0;
        //    int k = 0;

        //    //check for horizontal winning moves
        //    for (int i = 0; i < 3; i++)
        //    {
        //        matchingMovesCount = 0;
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (buttonGrid[i, j].Text == "O")
        //                matchingMovesCount++;
        //            else
        //                k = j;
        //            if ((matchingMovesCount == 2) && (buttonGrid[i, k].Text == ""))
        //            {
        //                buttonGrid[i, k].Text = "O";
        //                buttonGrid[i, k].Enabled = false;
        //                return true;
        //            }
        //        }
        //    }

        //    //check for vertical winning moves
        //    for (int j = 0; j < 3; j++)
        //    {
        //        matchingMovesCount = 0;
        //        for (int i = 0; i < 3; i++)
        //        {
        //            if (buttonGrid[i, j].Text == "O")
        //                matchingMovesCount++;
        //            else
        //                k = i;
        //            if ((matchingMovesCount == 2) && (buttonGrid[k, j].Text == ""))
        //            {
        //                buttonGrid[k, j].Text = "O";
        //                buttonGrid[k, j].Enabled = false;
        //                return true;
        //            }
        //        }
        //    }

        //    if (buttonGrid[0, 0].Text.Equals("O") && buttonGrid[1, 1].Text.Equals("O") && buttonGrid[2, 2].Text.Equals(""))
        //    {
        //        buttonGrid[2, 2].Text = "O";
        //        buttonGrid[2, 2].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 0].Text.Equals("O") && buttonGrid[1, 1].Text.Equals("") && buttonGrid[2, 2].Text.Equals("O"))
        //    {
        //        buttonGrid[1, 1].Text = "O";
        //        buttonGrid[1, 1].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 0].Text.Equals("") && buttonGrid[1, 1].Text.Equals("O") && buttonGrid[2, 2].Text.Equals("O"))
        //    {
        //        buttonGrid[0, 0].Text = "O";
        //        buttonGrid[0, 0].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("O") && buttonGrid[1, 1].Text.Equals("O") && buttonGrid[2, 0].Text.Equals(""))
        //    {
        //        buttonGrid[2, 0].Text = "O";
        //        buttonGrid[2, 0].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("O") && buttonGrid[1, 1].Text.Equals("") && buttonGrid[2, 0].Text.Equals("O"))
        //    {
        //        buttonGrid[1, 1].Text = "O";
        //        buttonGrid[1, 1].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("") && buttonGrid[1, 1].Text.Equals("O") && buttonGrid[2, 0].Text.Equals("O"))
        //    {
        //        buttonGrid[0, 2].Text = "O";
        //        buttonGrid[0, 2].Enabled = false;
        //        return true;
        //    }
        //    else
        //        return false;

        //}

        //public Boolean blockingMove()
        //{

        //    int matchingMovesCount = 0;
        //    int k = 0;

        //    //check for horizontal winning moves
        //    for (int i = 0; i < 3; i++)
        //    {
        //        matchingMovesCount = 0;
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (buttonGrid[i, j].Text == "X")
        //                matchingMovesCount++;
        //            else
        //                k = j;
        //            if ((matchingMovesCount == 2) && (buttonGrid[i, k].Text == ""))
        //            {
        //                buttonGrid[i, k].Text = "O";
        //                buttonGrid[i, k].Enabled = false;
        //                return true;
        //            }
        //        }
        //    }

        //    //check for vertical winning moves
        //    for (int j = 0; j < 3; j++)
        //    {
        //        matchingMovesCount = 0;
        //        for (int i = 0; i < 3; i++)
        //        {
        //            if (buttonGrid[i, j].Text == "X")
        //                matchingMovesCount++;
        //            else
        //                k = i;
        //            if ((matchingMovesCount == 2) && (buttonGrid[k, j].Text == ""))
        //            {
        //                buttonGrid[k, j].Text = "O";
        //                buttonGrid[k, j].Enabled = false;
        //                return true;
        //            }
        //        }
        //    }

        //    if (buttonGrid[0, 0].Text.Equals("X") && buttonGrid[1, 1].Text.Equals("X") && buttonGrid[2, 2].Text.Equals(""))
        //    {
        //        buttonGrid[2, 2].Text = "O";
        //        buttonGrid[2, 2].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 0].Text.Equals("X") && buttonGrid[1, 1].Text.Equals("") && buttonGrid[2, 2].Text.Equals("X"))
        //    {
        //        buttonGrid[1, 1].Text = "O";
        //        buttonGrid[1, 1].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 0].Text.Equals("") && buttonGrid[1, 1].Text.Equals("X") && buttonGrid[2, 2].Text.Equals("X"))
        //    {
        //        buttonGrid[0, 0].Text = "O";
        //        buttonGrid[0, 0].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("X") && buttonGrid[1, 1].Text.Equals("X") && buttonGrid[2, 0].Text.Equals(""))
        //    {
        //        buttonGrid[2, 0].Text = "O";
        //        buttonGrid[2, 0].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("X") && buttonGrid[1, 1].Text.Equals("") && buttonGrid[2, 0].Text.Equals("X"))
        //    {
        //        buttonGrid[1, 1].Text = "O";
        //        buttonGrid[1, 1].Enabled = false;
        //        return true;
        //    }
        //    else if (buttonGrid[0, 2].Text.Equals("") && buttonGrid[1, 1].Text.Equals("X") && buttonGrid[2, 0].Text.Equals("X"))
        //    {
        //        buttonGrid[0, 2].Text = "O";
        //        buttonGrid[0, 2].Enabled = false;
        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
