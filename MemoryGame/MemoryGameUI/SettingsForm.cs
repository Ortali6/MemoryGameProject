using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    internal partial class SettingsForm : Form
    {
        private readonly StringBuilder r_BoarderSize;
        private int m_CurrentBoardSize = 0;
        private int m_Row;
        private int m_Col;
        private string m_FirstPlayerName;
        private string m_SecondPlayerName;

        public SettingsForm()
        {
            InitializeComponent();
            r_BoarderSize = new StringBuilder("4 x 54 x 65 x 45 x 66 x 46 x 56 x 64 x 4");
        }

        private int currentBoardSize
        {
            get
            {
                return m_CurrentBoardSize;
            }

            set
            {
                m_CurrentBoardSize = value;
            }
        }

        public int RowsSize
        {
            get
            {
                return m_Row;
            }
        }

        public int ColsSize
        {
            get
            {
                return m_Col;
            }
        }

        public string GetFirstPlayerName
        {
            get
            {
                return m_FirstPlayerName;
            }
        }

        public string GetSecondPlayerName
        {
            get
            {
                return m_SecondPlayerName;
            }
        }

        public bool IsWithPhotos
        {
            get
            {
                return Photos.Checked;
            }
        }

        public bool IsAgainstComputer
        {
            get
            {
                return Against.Text == "Against a Friend";
            }
        }

        private void currentSizeBoard_Click(object sender, EventArgs e)
        {
            if (m_CurrentBoardSize < r_BoarderSize.Length)
            {
                CurrentSizeBoard.Text = r_BoarderSize.ToString(m_CurrentBoardSize, 5);
                m_CurrentBoardSize += 5;
            }
            else
            {
                m_CurrentBoardSize = 0;
                CurrentSizeBoard.Text = r_BoarderSize.ToString(m_CurrentBoardSize, 5);
                m_CurrentBoardSize += 5;
            }
        }

        private void against_Click(object sender, EventArgs e)
        {
            if (Against.Text == "Against a Friend")
            {
                Against.Text = "Against Computer";
                SecondPlayerName.Enabled = true;
                SecondPlayerName.Clear();
            }
            else
            {
                Against.Text = "Against a Friend";
                SecondPlayerName.Enabled = false;
                SecondPlayerName.Clear();
                SecondPlayerName.AppendText("Computer");
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (FirstPlayerName.Text != string.Empty && SecondPlayerName.Text != string.Empty)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("There is no name, please try again", "Name is missing");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (FirstPlayerName.Text != string.Empty && SecondPlayerName.Text != string.Empty)
            {
                string rowAndColumn;
                m_FirstPlayerName = FirstPlayerName.Text;
                m_SecondPlayerName = SecondPlayerName.Text;
                rowAndColumn = CurrentSizeBoard.Text;
                m_Row = (int)char.GetNumericValue(rowAndColumn[0]);
                m_Col = (int)char.GetNumericValue(rowAndColumn[4]);
            }

            base.OnClosed(e);
        }
    }
}