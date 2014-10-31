using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class MoveLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MoveLocation(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
