using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    abstract class Player
    {
        string playerName;
        int playerTile;     //X=+1 O=-1
        MoveLocation mymove;
        int winnings = 0;
        int losses = 0;

        public int Winnings
        {
            get { return winnings; }
            set { winnings = value; }
        }       
        public int Losses
        {
            get { return losses; }
            set { losses = value; }
        }
        public int PlayerTile
        {
            get { return playerTile; }
            
        }
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public Player(string name,int tileType)
        {
            playerName = name;
            playerTile = tileType;
            mymove = new MoveLocation(0, 0);
        }

       public void setmove(MoveLocation newMove)
       {
           mymove=newMove;
       }

       public void move(GameBoard board)
       {
           board.placeTile(mymove, playerTile);
       }

       public void win()
       {
           winnings++;
       }


       public void loss()
       {
           losses++;
       }
    }
}
