using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameBoard
    {
        int[,] tiles;

        public GameBoard()
        {
            tiles=new int[3,3];

        }

        public void placeTile(MoveLocation place,int type)
        {
            tiles[place.X, place.Y] = type;
        }

        public int getTilevalue(MoveLocation pos)
        {
            return tiles[pos.X, pos.Y];
        }

        public void reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tiles[i, j] = 0;
                }
            }
        }
    }
}
