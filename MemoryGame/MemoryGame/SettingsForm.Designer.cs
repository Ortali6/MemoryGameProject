namespace MemoryGameUI
{
    internal partial class SettingsForm
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
            this.LableFirstPlayer = new System.Windows.Forms.Label();
            this.LableSecondPlayer = new System.Windows.Forms.Label();
            this.FirstPlayerName = new System.Windows.Forms.TextBox();
            this.SecondPlayerName = new System.Windows.Forms.TextBox();
            this.Against = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.LableBoardSize = new System.Windows.Forms.Label();
            this.CurrentSizeBoard = new System.Windows.Forms.Button();
            this.Photos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LableFirstPlayer
            // 
            this.LableFirstPlayer.AutoSize = true;
            this.LableFirstPlayer.Location = new System.Drawing.Point(28, 16);
            this.LableFirstPlayer.Name = "LableFirstPlayer";
            this.LableFirstPlayer.Size = new System.Drawing.Size(92, 13);
            this.LableFirstPlayer.TabIndex = 0;
            this.LableFirstPlayer.Text = "First Player Name:";
            // 
            // LableSecondPlayer
            // 
            this.LableSecondPlayer.AutoSize = true;
            this.LableSecondPlayer.Location = new System.Drawing.Point(28, 46);
            this.LableSecondPlayer.Name = "LableSecondPlayer";
            this.LableSecondPlayer.Size = new System.Drawing.Size(110, 13);
            this.LableSecondPlayer.TabIndex = 1;
            this.LableSecondPlayer.Text = "Second Player Name:";
            // 
            // FirstPlayerName
            // 
            this.FirstPlayerName.Location = new System.Drawing.Point(149, 13);
            this.FirstPlayerName.Name = "FirstPlayerName";
            this.FirstPlayerName.Size = new System.Drawing.Size(100, 20);
            this.FirstPlayerName.TabIndex = 100;
            // 
            // SecondPlayerName
            // 
            this.SecondPlayerName.Enabled = false;
            this.SecondPlayerName.Location = new System.Drawing.Point(149, 42);
            this.SecondPlayerName.Name = "SecondPlayerName";
            this.SecondPlayerName.Size = new System.Drawing.Size(100, 20);
            this.SecondPlayerName.TabIndex = 320;
            this.SecondPlayerName.Text = "Computer";
            // 
            // Against
            // 
            this.Against.Location = new System.Drawing.Point(270, 41);
            this.Against.Name = "Against";
            this.Against.Size = new System.Drawing.Size(107, 23);
            this.Against.TabIndex = 300;
            this.Against.Text = "Against a Friend";
            this.Against.UseVisualStyleBackColor = true;
            this.Against.Click += new System.EventHandler(this.against_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Start.Location = new System.Drawing.Point(302, 121);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 500;
            this.Start.Text = "Start!";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.start_Click);
            // 
            // LableBoardSize
            // 
            this.LableBoardSize.AutoSize = true;
            this.LableBoardSize.Location = new System.Drawing.Point(28, 81);
            this.LableBoardSize.Name = "LableBoardSize";
            this.LableBoardSize.Size = new System.Drawing.Size(61, 13);
            this.LableBoardSize.TabIndex = 7;
            this.LableBoardSize.Text = "Board Size:";
            // 
            // CurrentSizeBoard
            // 
            this.CurrentSizeBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CurrentSizeBoard.Location = new System.Drawing.Point(31, 97);
            this.CurrentSizeBoard.Name = "CurrentSizeBoard";
            this.CurrentSizeBoard.Size = new System.Drawing.Size(107, 47);
            this.CurrentSizeBoard.TabIndex = 400;
            this.CurrentSizeBoard.Text = "4 x 4";
            this.CurrentSizeBoard.UseVisualStyleBackColor = false;
            this.CurrentSizeBoard.Click += new System.EventHandler(this.currentSizeBoard_Click);
            // 
            // Photos
            // 
            this.Photos.AutoSize = true;
            this.Photos.Location = new System.Drawing.Point(165, 127);
            this.Photos.Name = "Photos";
            this.Photos.Size = new System.Drawing.Size(84, 17);
            this.Photos.TabIndex = 450;
            this.Photos.Text = "With Photos";
            this.Photos.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 155);
            this.Controls.Add(this.Photos);
            this.Controls.Add(this.CurrentSizeBoard);
            this.Controls.Add(this.LableBoardSize);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Against);
            this.Controls.Add(this.SecondPlayerName);
            this.Controls.Add(this.FirstPlayerName);
            this.Controls.Add(this.LableSecondPlayer);
            this.Controls.Add(this.LableFirstPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 194);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 194);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LableFirstPlayer;
        private System.Windows.Forms.Label LableSecondPlayer;
        private System.Windows.Forms.TextBox FirstPlayerName;
        private System.Windows.Forms.TextBox SecondPlayerName;
        private System.Windows.Forms.Button Against;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label LableBoardSize;
        private System.Windows.Forms.Button CurrentSizeBoard;
        private System.Windows.Forms.CheckBox Photos;
    }
}