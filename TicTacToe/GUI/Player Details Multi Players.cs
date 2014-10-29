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
    public partial class Player_Details_Multi_Players : Form
    {
        private bool multiPlayers = false;
        public Player_Details_Multi_Players()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Players players = new Players();
            multiPlayers = true;

            players.setPlayerMode(multiPlayers);
            players.setPlayer1Name(textBox1.Text);
            players.setPlayer2Name(textBox2.Text);
            
            players.ShowDialog();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
