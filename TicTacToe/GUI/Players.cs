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
                updateP1Label(controller.getPlayer1());
                updateP2Label(controller.getPlayer2());
                PlayerStatus.getInstance().addStatus(controller.getPlayer1().PlayerName, controller.getPlayer1().Winnings, controller.getPlayer1().Losses);
                PlayerStatus.getInstance().addStatus(controller.getPlayer2().PlayerName, controller.getPlayer2().Winnings, controller.getPlayer2().Losses);
            }
            else
            {
                MessageBox.Show("Draw!");
            }

            disableButtons();
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

        private void gameSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSingleplayer frmSP=new frmSingleplayer();
            if(frmSP.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                diffToolStripMenuItem.Enabled = true;
                Player human=new HumanPlayer(frmSP.getPlayerName(),frmSP.getPlayerTile());
                Player computer= new ComputerPlayer(-frmSP.getPlayerTile(),frmSP.getDiffLevel());
                controller.changePlayers(human, computer);
                updateP1Label(human);
                updateP2Label(computer);
            }
        }

       
        private void updateP1Label(Player player)
        {
            lblP1.Text = "Name : " + player.PlayerName + "\r\nWinnings : " + player.Winnings;
        }

        private void updateP2Label(Player player)
        {
            lblP2.Text = "Name : " + player.PlayerName + "\r\nWinnings : " + player.Winnings;
        }

        private void gameMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMultiplayer frmMP = new frmMultiplayer();
            if (frmMP.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                diffToolStripMenuItem.Enabled = false;
                Player human1 = new HumanPlayer(frmMP.getP1Name(), frmMP.getP1Tile());
                Player human2 = new HumanPlayer(frmMP.getP2Name(), frmMP.getP2Tile());
                controller.changePlayers(human1, human2);
                updateP1Label(human1);
                updateP2Label(human2);
            }
        }

        private void DiffEasiestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changeComputerDiff(0);
        }

        private void DiffEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changeComputerDiff(1);
        }

        private void DiffMediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changeComputerDiff(2);
        }

        private void DiffHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changeComputerDiff(3);
        }

        private void DiffHardestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.changeComputerDiff(4);
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.resetGame();
            enableButtons();
        }

        private void Players_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinarySerializeProvider.save(PlayerStatus.getInstance());
        }

        private void Players_Load(object sender, EventArgs e)
        {
            BinarySerializeProvider.FilePath = Application.StartupPath + "\\scores.sav";
            PlayerStatus.loadInstance();
        }

        private void playerStaticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlayerScores frmScore = new frmPlayerScores();
            frmScore.ShowDialog();
        }
       
    }
}
