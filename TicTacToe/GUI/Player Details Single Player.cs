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
    public partial class Player_Details_Single_Player : Form
    {
        private bool multiPlayers;

        public Player_Details_Single_Player()
        {
            InitializeComponent();
            multiPlayers = false;
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Players players = new Players();

            players.setPlayerMode(multiPlayers);
            players.setPlayer1Name(playerNameTxt.Text);

            if (easyRadioButton.Checked)
                players.setDifficulty("easy");
            else if (mediumRadioButton.Checked)
                players.setDifficulty("medium");
            else if (hardRadioButton.Checked)
                players.setDifficulty("hard");

            players.ShowDialog();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
