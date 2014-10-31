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
    public partial class frmPlayerScores : Form
    {
        public frmPlayerScores()
        {
            InitializeComponent();
        }

        private void frmPlayerScores_Load(object sender, EventArgs e)
        {
            PlayerStatus tmp = PlayerStatus.getInstance();

            for (int i = 0; i < tmp.getCount(); i++)
            {
                ListViewItem item = new ListViewItem(tmp.getPlayerName(i));
                item.SubItems.Add(tmp.getPlayerWin(i).ToString());
                item.SubItems.Add(tmp.getPlayerLoss(i).ToString());
                float winRate=((float)tmp.getPlayerWin(i))/(tmp.getPlayerWin(i)+tmp.getPlayerLoss(i))*100;
                item.SubItems.Add(winRate.ToString("0.00")+"%");
                listViewScore.Items.Add(item);
            }
        }

        private void frmPlayerScores_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete && listViewScore.SelectedItems.Count>0 && MessageBox.Show("Do you want to delete player \""+listViewScore.SelectedItems[0]+"\"","WARNING",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==System.Windows.Forms.DialogResult.Yes)
            {
                listViewScore.Items.RemoveAt(listViewScore.SelectedItems[0].Index);
                PlayerStatus.getInstance().remove(listViewScore.SelectedItems[0].Text);
            }
        }

        private void listViewScore_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listViewScore.SelectedItems.Count > 0 && MessageBox.Show("Do you want to delete player \"" + listViewScore.SelectedItems[0].Text + "\"", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                PlayerStatus.getInstance().remove(listViewScore.SelectedItems[0].Text);
                listViewScore.Items.RemoveAt(listViewScore.SelectedItems[0].Index);
                
            }
        }

        
    }
}
