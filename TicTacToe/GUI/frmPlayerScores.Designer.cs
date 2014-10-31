namespace TicTacToe
{
    partial class frmPlayerScores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayerScores));
            this.listViewScore = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLoss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWinrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewScore
            // 
            this.listViewScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderWin,
            this.columnHeaderLoss,
            this.columnHeaderWinrate});
            this.listViewScore.FullRowSelect = true;
            this.listViewScore.Location = new System.Drawing.Point(12, 12);
            this.listViewScore.MultiSelect = false;
            this.listViewScore.Name = "listViewScore";
            this.listViewScore.Size = new System.Drawing.Size(454, 325);
            this.listViewScore.TabIndex = 0;
            this.listViewScore.UseCompatibleStateImageBehavior = false;
            this.listViewScore.View = System.Windows.Forms.View.Details;
            this.listViewScore.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewScore_KeyUp);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 148;
            // 
            // columnHeaderWin
            // 
            this.columnHeaderWin.Text = "Winnings";
            this.columnHeaderWin.Width = 82;
            // 
            // columnHeaderLoss
            // 
            this.columnHeaderLoss.Text = "Losses";
            this.columnHeaderLoss.Width = 88;
            // 
            // columnHeaderWinrate
            // 
            this.columnHeaderWinrate.Text = "Winning Rate";
            this.columnHeaderWinrate.Width = 129;
            // 
            // frmPlayerScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 349);
            this.Controls.Add(this.listViewScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlayerScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scores";
            this.Load += new System.EventHandler(this.frmPlayerScores_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPlayerScores_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewScore;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderWin;
        private System.Windows.Forms.ColumnHeader columnHeaderLoss;
        private System.Windows.Forms.ColumnHeader columnHeaderWinrate;
    }
}