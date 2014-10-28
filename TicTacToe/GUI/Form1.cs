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
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        private void players_Click(object sender, EventArgs e)
        {
            this.Hide();

            Player_Details_Multi_Players multiDetails = new Player_Details_Multi_Players();
            multiDetails.ShowDialog();
           
        }


        private void computer_Click(object sender, EventArgs e)
        {
            this.Hide();

            Player_Details_Single_Player singleDetails = new Player_Details_Single_Player();
            singleDetails.ShowDialog();

        }
    }
}
