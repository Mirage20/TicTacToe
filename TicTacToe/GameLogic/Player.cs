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

       
       

    }
}
