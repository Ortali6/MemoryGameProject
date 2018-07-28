namespace MemoryGameUI
{
    internal partial class MemoryGameForm
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
            this.CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.Player1Name = new System.Windows.Forms.Label();
            this.CurrentPlayerName = new System.Windows.Forms.Label();
            this.Player1Pairs = new System.Windows.Forms.Label();
            this.Player2Pairs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentPlayerLabel
            // 
            this.CurrentPlayerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentPlayerLabel.AutoSize = true;
            this.CurrentPlayerLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.CurrentPlayerLabel.Location = new System.Drawing.Point(9, 229);
            this.CurrentPlayerLabel.Name = "CurrentPlayerLabel";
            this.CurrentPlayerLabel.Size = new System.Drawing.Size(76, 13);
            this.CurrentPlayerLabel.TabIndex = 0;
            this.CurrentPlayerLabel.Text = "Current Player:";
            // 
            // Player2Name
            // 
            this.Player2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player2Name.AutoSize = true;
            this.Player2Name.BackColor = System.Drawing.Color.MediumOrchid;
            this.Player2Name.Location = new System.Drawing.Point(9, 277);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(42, 13);
            this.Player2Name.TabIndex = 2;
            this.Player2Name.Text = "Player2";
            // 
            // Player1Name
            // 
            this.Player1Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player1Name.AutoSize = true;
            this.Player1Name.BackColor = System.Drawing.Color.LimeGreen;
            this.Player1Name.Location = new System.Drawing.Point(9, 253);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(45, 13);
            this.Player1Name.TabIndex = 3;
            this.Player1Name.Text = "Player1:";
            // 
            // CurrentPlayerName
            // 
            this.CurrentPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentPlayerName.AutoSize = true;
            this.CurrentPlayerName.BackColor = System.Drawing.Color.LimeGreen;
            this.CurrentPlayerName.Location = new System.Drawing.Point(85, 229);
            this.CurrentPlayerName.Name = "CurrentPlayerName";
            this.CurrentPlayerName.Size = new System.Drawing.Size(98, 13);
            this.CurrentPlayerName.TabIndex = 4;
            this.CurrentPlayerName.Text = "CurrentPlayerName";
            // 
            // Player1Pairs
            // 
            this.Player1Pairs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player1Pairs.AutoSize = true;
            this.Player1Pairs.BackColor = System.Drawing.Color.LimeGreen;
            this.Player1Pairs.Location = new System.Drawing.Point(118, 253);
            this.Player1Pairs.Name = "Player1Pairs";
            this.Player1Pairs.Size = new System.Drawing.Size(65, 13);
            this.Player1Pairs.TabIndex = 5;
            this.Player1Pairs.Text = "Player1Pairs";
            // 
            // Player2Pairs
            // 
            this.Player2Pairs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Pairs.AutoSize = true;
            this.Player2Pairs.BackColor = System.Drawing.Color.MediumOrchid;
            this.Player2Pairs.Location = new System.Drawing.Point(118, 277);
            this.Player2Pairs.Name = "Player2Pairs";
            this.Player2Pairs.Size = new System.Drawing.Size(65, 13);
            this.Player2Pairs.TabIndex = 6;
            this.Player2Pairs.Text = "Player2Pairs";
            // 
            // MemoryGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.Player2Pairs);
            this.Controls.Add(this.Player1Pairs);
            this.Controls.Add(this.CurrentPlayerName);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.CurrentPlayerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MemoryGameForm";
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentPlayerLabel;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label CurrentPlayerName;
        private System.Windows.Forms.Label Player1Pairs;
        private System.Windows.Forms.Label Player2Pairs;
    }
}