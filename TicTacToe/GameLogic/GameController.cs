using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TicTacToe
{
    class GameController
    {
        public delegate void WinStatusChangedHandler(bool isDraw,Player winner,int winLine);
        public event WinStatusChangedHandler WinStatusChanged;

        public delegate void TileChangedHandler(MoveLocation location, string tileValue);
        public event TileChangedHandler TileChanged;

        // 1 for X , -1 for O 
        GameBoard board;
        Player player1;
        Player player2;
        bool isXturn = false;
        bool hasWinner = false;
        bool isValidMove = false;
        int turnCount = 0;
        bool isAI = false;
        int winningLine = 0;

        public GameController(Player player1,Player player2)
        {
            board = new GameBoard();
            this.player1 = player1;
            this.player2 = player2;
            isAI = this.player2 is ComputerPlayer;
            
        }

        public void taketurn(MoveLocation position)
        {
            
            if(isAI)
            {
                if (!turnComputer(position))
                    return;
            }
            else
            {
                if (!turnHuman(position))
                    return;
                checkForWinners();
                isXturn = !isXturn;
            }
           
            isValidMove = true;
                  
        }


        private bool turnHuman(MoveLocation position)
        {
            if (isXturn)
            {
                if (validate(position))
                {
                    if (player1.PlayerTile == 1)
                    {
                        player1.setmove(position);
                        player1.move(board);                        
                    }
                    else
                    {
                        player2.setmove(position);
                        player2.move(board);                      
                    }
                    TileChanged(position, "X");
                }
                else
                {
                    MessageBox.Show("invalid p1");
                    isValidMove = false;
                    return false; ;
                }

            }
            else
            {

                if (validate(position))
                {
                    if (player2.PlayerTile == -1)
                    {
                        player2.setmove(position);
                        player2.move(board);
                    }
                    else
                    {
                        player1.setmove(position);
                        player1.move(board);                      
                    }

                    TileChanged(position, "O");
                }
                else
                {
                    MessageBox.Show("invalid p2");
                    isValidMove = false;
                    return false;
                }
            }
            turnCount++;
            return true;
        }


        private bool turnComputer(MoveLocation position)
        {

            if (validate(position))
            {
                player1.setmove(position);
                player1.move(board);
                if(player1.PlayerTile==1)
                    TileChanged(position, "X");
                else
                    TileChanged(position, "O");
            }
            else
            {
                MessageBox.Show("invalid p1");
                isValidMove = false;
                return false; ;
            }
            turnCount++;
            checkForWinners();

            if (player1.PlayerTile == 1)
                isXturn = false; 
            else
                isXturn = true; 
            
            
            
            isValidMove = true;

            if (hasWinner)
                return true;

            MoveLocation cpuMove;
            do
            {
                cpuMove = ((ComputerPlayer)player2).getMove(board);
            } while (turnCount != 9 && !validate(cpuMove));

            if (turnCount != 9)
            {
                player2.setmove(cpuMove);
                player2.move(board);
                if (player2.PlayerTile == -1)
                    TileChanged(cpuMove, "O");
                else
                    TileChanged(cpuMove, "X");
                turnCount++;  
                checkForWinners();

                if (player2.PlayerTile == -1)
                    isXturn = true;
                else
                    isXturn = false; 
                           
                
            }
            
            return true;
        }

        #region WinCheck
        private void checkForWinners()
        {

            int winValue = 0;
            
            //horizontal check
            for (int j = 0; j < 3; j++)
            {
                winValue = 0;
                for (int i = 0; i < 3; i++)
                {
                    winValue += board.getTilevalue(new MoveLocation(i, j));
                    if (winValue == 3 || winValue == -3)
                    {
                        hasWinner = true;
                        winningLine = 1 + j;
                    }
                }
            }
            


            //vertical check
            for (int i = 0; i < 3; i++)
            {
                winValue = 0;
                for (int j = 0; j < 3; j++)
                {
                    winValue += board.getTilevalue(new MoveLocation(i, j));
                    if (winValue == 3 || winValue == -3)
                    {
                        hasWinner = true;
                        winningLine = 4 + i;
                    }
                }
            }

            //diagonal check
            winValue = 0;
            for (int i = 0; i < 3; i++)
            {             
                winValue += board.getTilevalue(new MoveLocation(i, i));
                if (winValue == 3 || winValue == -3)
                {
                    hasWinner = true;
                    winningLine = 7;
                }
            }

            winValue = 0;
            for (int i = 0; i < 3; i++)
            {               
                winValue += board.getTilevalue(new MoveLocation(2-i, i));
                if (winValue == 3 || winValue == -3)
                {
                    hasWinner = true;
                    winningLine = 8;
                }
            }

            if (hasWinner)
            {

                if (isXturn)
                {
                    Player winner = player1.PlayerTile == 1 ? player1 : player2;
                    winner.win();
                    Player looser = player1.PlayerTile == 1 ? player2 : player1;
                    looser.loss();
                    WinStatusChanged(false, winner, winningLine);
                }
                else
                {
                    Player winner = player2.PlayerTile == -1 ? player2 : player1;
                    winner.win();
                    Player looser = player2.PlayerTile == -1 ? player1 : player2;
                    looser.loss();
                    WinStatusChanged(false, player2.PlayerTile == -1 ? player2 : player1, winningLine);
                }
            }
            else
                checkForDraw();

        }

        private void checkForDraw()
        {
            if (turnCount == 9)
                WinStatusChanged(true, null, winningLine);
            
        }

        #endregion
        private bool validate(MoveLocation value)
        {
            if (board.getTilevalue(value) == 0)
                return true;
            return false;
        }

        public bool getLastMoveValidity()
        {
            return isValidMove;
           
        }

        public void changePlayers(Player player1,Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            isAI = this.player2 is ComputerPlayer;
        }

        public void resetGame()
        {
            board.reset();
            turnCount = 0;
            hasWinner = false;
        }

        public Player getPlayer1()
        {
            return player1;
        }

        public Player getPlayer2()
        {
            return player2;
        }
        
    }
}
