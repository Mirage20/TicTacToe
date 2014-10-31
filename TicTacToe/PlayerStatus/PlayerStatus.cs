using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Serializable]
    class PlayerStatus
    {
        List<string> playerName = new List<string>();
        List<int> winCount = new List<int>();
        List<int> lossCount = new List<int>();

        private static PlayerStatus instance = null;
        private PlayerStatus()
        {
            
        }

        public static PlayerStatus getInstance()
        {
            if (instance == null)
                return new PlayerStatus();

            return instance;
        }

        public static void loadInstance()
        {
            instance = BinarySerializeProvider.load();
        }

        public void addStatus(string name,int win,int loss)
        {
            for (int i = 0; i < playerName.Count; i++)
            {
                if(playerName[i].Equals(name))
                {
                    winCount[i] += win;
                    lossCount[i] += loss;
                    return;
                }
            }
            
            playerName.Add(name);
            winCount.Add(win);
            lossCount.Add(loss);
        }

        public void remove(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (playerName[i].Equals(name))
                {
                    playerName.RemoveAt(i);
                    winCount.RemoveAt(i);
                    lossCount.RemoveAt(i);
                    return;
                }
            }
        }

        public int getCount()
        {
            return playerName.Count;
        }

        public string getPlayerName(int i)
        {
            return playerName[i];
        }

        public int getPlayerWin(int i)
        {
            return winCount[i];
        }

        public int getPlayerLoss(int i)
        {
            return lossCount[i];
        }
    }
}
