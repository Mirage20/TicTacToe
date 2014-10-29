using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Players : Form
    {
        GameController controller;
        Button[,] buttonGrid = new Button[3,3] ;
        
        public Players()
        {
            InitializeComponent();
            initGridButtons();
            controller = new GameController(new HumanPlayer("A", 1), new ComputerPlayer(-1,1));
            controller.WinStatusChanged += controller_WinStatusChanged;
            controller.TileChanged += controller_TileChanged;
            label3.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            
        }

        private void controller_TileChanged(MoveLocation location, string tileValue)
        {
            buttonGrid[location.X, location.Y].Text = tileValue;
            buttonGrid[location.X, location.Y].Enabled = false;
            buttonGrid[location.X, location.Y].BackColor = Color.Yellow;
        }

        private void controller_WinStatusChanged(bool isDraw, Player winner,int winLine)
        {
            if(!isDraw)
            {
                showWinLine(winLine);
                MessageBox.Show("Player " + winner.PlayerName + " wins ");
               
            }
            else
            {
                MessageBox.Show("Draw!");
            }

            disableButtons();
        }
        
        public void setPlayerMode(bool players)
        {
            //multiPlayer = players;
        }
        public void setPlayer1Name(String name)
        {
            //player1 = name;
            //label1.Text = player1 + "'s Turn";
        }
        public void setPlayer2Name(String name)
        {
            //player2 = name;
        }
        public void setDifficulty(String diffi)
        {
            //difficulty = diffi;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            controller.taketurn(getMoveByName(btn.Name));
            
        }

            
        private void disableButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (buttonGrid[i, j].Enabled)
                    {
                        buttonGrid[i, j].Enabled = false;
                        buttonGrid[i, j].BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void enableButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttonGrid[i, j].Enabled = true;
                    buttonGrid[i, j].Text = "";
                    buttonGrid[i, j].BackColor = SystemColors.ControlLightLight;
                }
            }
        }

        private void selectPlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Xturn = true;
            //turn_count = 0;
            //won = false;
            //tied = false;
            //label1.Text = player1 + "'s Turn";

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        buttonGrid[i, j].Enabled = true;
            //        buttonGrid[i, j].Text = "";
            //    }
            //}
        }

        private void setPlayerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newGame = new Form1();
            newGame.ShowDialog();
            
        }

        private void setDifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (multiPlayer)
            //    setDifficultyToolStripMenuItem.Enabled = false;
            //else
            //{
            //    this.Hide();
            //    Player_Details_Single_Player singleDetails = new Player_Details_Single_Player();
            //    singleDetails.ShowDialog();
               

            //}
        }


        //M

        private MoveLocation getMoveByName(string name)
        {
            MoveLocation move = null;
            for (int i = 0; i < 9; i++)
            {
                if(name.Equals("btnGrid" + (i+1)))
                {
                    move = new MoveLocation(i % 3, i / 3);
                }
            }

            return move;
        }
        private Button getByName(string name)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                Control c = Controls[i];
                if (c is Button && ((Button)c).Name.Equals(name))
                {
                    return (Button)c;
                }
            }
            return null;
        }

        private void initGridButtons()
        {
            int btnnum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttonGrid[j, i] = getByName("btnGrid" + (++btnnum));
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            controller.resetGame();
            enableButtons();
        }

        private void showWinLine(int winLine)
        {
            switch (winLine)
            {
                case 1:
                    buttonGrid[0, 0].BackColor = Color.Red;
                    buttonGrid[1, 0].BackColor = Color.Red;
                    buttonGrid[2, 0].BackColor = Color.Red;
                    break;
                case 2:
                    buttonGrid[0, 1].BackColor = Color.Red;
                    buttonGrid[1, 1].BackColor = Color.Red;
                    buttonGrid[2, 1].BackColor = Color.Red;
                    break;
                case 3:
                    buttonGrid[0, 2].BackColor = Color.Red;
                    buttonGrid[1, 2].BackColor = Color.Red;
                    buttonGrid[2, 2].BackColor = Color.Red;
                    break;
                case 4:
                    buttonGrid[0, 0].BackColor = Color.Red;
                    buttonGrid[0, 1].BackColor = Color.Red;
                    buttonGrid[0, 2].BackColor = Color.Red;
                    break;
                case 5:
                    buttonGrid[1, 0].BackColor = Color.Red;
                    buttonGrid[1, 1].BackColor = Color.Red;
                    buttonGrid[1, 2].BackColor = Color.Red;
                    break;
                case 6:
                    buttonGrid[2, 0].BackColor = Color.Red;
                    buttonGrid[2, 1].BackColor = Color.Red;
                    buttonGrid[2, 2].BackColor = Color.Red;
                    break;
                case 7:
                    buttonGrid[0, 0].BackColor = Color.Red;
                    buttonGrid[1, 1].BackColor = Color.Red;
                    buttonGrid[2, 2].BackColor = Color.Red;
                    break;
                case 8:
                    buttonGrid[2, 0].BackColor = Color.Red;
                    buttonGrid[1, 1].BackColor = Color.Red;
                    buttonGrid[0, 2].BackColor = Color.Red;
                    break;
                default:
                    break;
            }
        }

       
    }
}
