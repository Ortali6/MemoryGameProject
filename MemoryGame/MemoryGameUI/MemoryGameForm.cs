using System;
using System.Drawing;
using System.Windows.Forms;
using MemoryGameLogic;

namespace MemoryGameUI
{
    internal partial class MemoryGameForm : Form
    {
        private const int k_SpeaceBetweenButtons = 11;
        private const int k_Player1 = 1;
        private readonly int r_RowsSize;
        private readonly int r_ColsSize;
        private readonly string r_FirstPlayerName;
        private readonly string r_SecondPlayerName;
        private readonly BoardButton[,] r_BulidBoardButtons;
        private readonly Image[] r_ImageList;
        private bool m_WithPhotos = false;
        private bool m_IsAgainstComputer = false;
        private Game m_Game;
        private SettingsForm m_SettingsForm;
        private int m_NumOfClicks = 0;
        private int m_CurrentPlayer = 1;
        private PictureBox m_PicBox;

        internal MemoryGameForm()
        {
            InitializeComponent();
            m_SettingsForm = new SettingsForm();
            DialogResult DR = m_SettingsForm.ShowDialog();
            r_FirstPlayerName = m_SettingsForm.GetFirstPlayerName;
            r_SecondPlayerName = m_SettingsForm.GetSecondPlayerName;
            m_WithPhotos = m_SettingsForm.IsWithPhotos;
            if (DR == DialogResult.Cancel && (r_FirstPlayerName == null || r_SecondPlayerName == null))
            {
                Close();
            }
            else
            {
                r_RowsSize = m_SettingsForm.RowsSize;
                r_ColsSize = m_SettingsForm.ColsSize;
                m_IsAgainstComputer = m_SettingsForm.IsAgainstComputer;
                r_BulidBoardButtons = new BoardButton[r_RowsSize, r_ColsSize];
                m_Game = new Game();
                start();
                drawBoard();

                if (m_WithPhotos)
                {
                    r_ImageList = new Image[r_RowsSize * r_ColsSize / 2];
                    m_PicBox = new PictureBox();
                    try
                    {
                        makeListOfPhotos();
                    }
                    catch (Exception ex)
                    {
                        m_WithPhotos = false;
                        MessageBox.Show(string.Format(
                            @" {0}
{1}",
ex.Message,
"The game will be with letters"));
                    }
                }

                ShowDialog();
            }
        }

        private void start()
        {
            m_Game.BuildBoard(r_RowsSize, r_ColsSize);
            m_Game.FirstPlayer(r_FirstPlayerName);
            CurrentPlayerName.Text = r_FirstPlayerName;

            if (!m_IsAgainstComputer)
            {
                m_Game.SecondPlayer(r_SecondPlayerName);
            }
            else
            {
                m_Game.ComputerPlayer();
            }

            m_Game.m_EndGameDelegate += roundFinished;
            m_Game.m_DrawValueDelegate += onClickUpdateScreen;
            m_Game.m_UpdatePointsDelegate += updateScoreLabel;
            m_Game.m_ClearTwoButtonsDelegate += clearTwoButtons;
            m_Game.m_EnableButtonsDelegate += enableTwoButtons;
            m_Game.m_UpdateNextPlayerDelegate += changeNameAndColor;
        }

        private void clearTwoButtons(int i_Row1, int i_Col1, int i_Row2, int i_Col2)
        {
            if (m_WithPhotos)
            {
                r_BulidBoardButtons[i_Row1, i_Col1].BackgroundImage = null;
                r_BulidBoardButtons[i_Row2, i_Col2].BackgroundImage = null;
            }

            r_BulidBoardButtons[i_Row1, i_Col1].BackColor = BoardButton.DefaultBackColor;
            r_BulidBoardButtons[i_Row1, i_Col1].UseVisualStyleBackColor = true;
            r_BulidBoardButtons[i_Row2, i_Col2].BackColor = BoardButton.DefaultBackColor;
            r_BulidBoardButtons[i_Row2, i_Col2].UseVisualStyleBackColor = true;
            r_BulidBoardButtons[i_Row1, i_Col1].Text = string.Empty;
            r_BulidBoardButtons[i_Row2, i_Col2].Text = string.Empty;
            r_BulidBoardButtons[i_Row1, i_Col1].Refresh();
            r_BulidBoardButtons[i_Row2, i_Col2].Refresh();
        }

        private void enableTwoButtons(int i_Row1, int i_Col1, int i_Row2, int i_Col2)
        {
            r_BulidBoardButtons[i_Row1, i_Col1].Enabled = true;
            r_BulidBoardButtons[i_Row2, i_Col2].Enabled = true;
        }

        private void changeNameAndColor()
        {
            if (m_Game.GetCurrentPlayer == k_Player1)
            {
                CurrentPlayerName.Text = r_FirstPlayerName;
                CurrentPlayerName.BackColor = Player1Name.BackColor;
                CurrentPlayerLabel.BackColor = Player1Name.BackColor;
            }
            else
            {
                CurrentPlayerName.Text = r_SecondPlayerName;
                CurrentPlayerName.BackColor = Player2Name.BackColor;
                CurrentPlayerLabel.BackColor = Player2Name.BackColor;
            }

            CurrentPlayerName.Refresh();
            CurrentPlayerLabel.Refresh();
        }

        private void drawBoard()
        {
            int x = k_SpeaceBetweenButtons;
            int y = k_SpeaceBetweenButtons;
            int width = 93;
            int hight = 93;

            for (int i = 0; i < r_RowsSize; i++)
            {
                for (int j = 0; j < r_ColsSize; j++)
                {
                    BoardButton buildButton = new BoardButton(i, j);
                    r_BulidBoardButtons[i, j] = buildButton;
                    buildButton.Size = new Size(width, hight);
                    buildButton.Location = new Point(x, y);
                    buildButton.Click += new EventHandler(boardButton_click);
                    Controls.Add(buildButton);
                    x += width + k_SpeaceBetweenButtons;
                }

                y += hight + k_SpeaceBetweenButtons;
                x = k_SpeaceBetweenButtons;
            }

            Size = new Size((width * r_ColsSize) + ((r_ColsSize + 2) * k_SpeaceBetweenButtons), (hight * (r_RowsSize + 1)) + ((r_RowsSize + 3) * k_SpeaceBetweenButtons));
            Player1Name.Text = string.Format("{0}: ", r_FirstPlayerName);
            Player2Name.Text = string.Format("{0}: ", r_SecondPlayerName);
            Player1Pairs.Text = "0 Pairs";
            Player2Pairs.Text = "0 Pairs";
            Player1Name.AutoSize = true;
            Player2Name.AutoSize = true;
            CurrentPlayerName.AutoSize = true;
        }

        private void updateScoreLabel()
        {
            Player1Pairs.Text = string.Format("{0} Pairs", m_Game.GetFirstPlayerPoints.ToString());

            if (!m_IsAgainstComputer)
            {
                Player2Pairs.Text = string.Format("{0} Pairs", m_Game.GetSecondPlayerPoints.ToString());
            }
            else
            {
                Player2Pairs.Text = string.Format("{0} Pairs", m_Game.GetComputerPoints.ToString());
            }

            Player1Pairs.Refresh();
            Player2Pairs.Refresh();
        }

        private Image loadImage(string i_Url)
        {
            m_PicBox.Load(i_Url);
            return (Bitmap)m_PicBox.Image;
        }

        private void makeListOfPhotos()
        {
            for (int i = 0; i < r_ImageList.Length; i++)
            {
                r_ImageList[i] = loadImage("https://picsum.photos/80/80/?random");
            }
        }

        private void onClickUpdateScreen(int i_Row, int i_Col)
        {
            r_BulidBoardButtons[i_Row, i_Col].Enabled = false;

            if (!m_WithPhotos)
            {
                r_BulidBoardButtons[i_Row, i_Col].Text = m_Game.CurrentLetter(i_Row, i_Col).ToString();
            }
            else
            {
                r_BulidBoardButtons[i_Row, i_Col].BackgroundImage = r_ImageList[m_Game.CurrentLetter(i_Row, i_Col) - 'A'];
                r_BulidBoardButtons[i_Row, i_Col].BackgroundImageLayout = ImageLayout.Center;
                r_BulidBoardButtons[i_Row, i_Col].BackColor = CurrentPlayerName.BackColor;
            }

            if (m_Game.GetCurrentPlayer == k_Player1)
            {
                r_BulidBoardButtons[i_Row, i_Col].BackColor = Player1Name.BackColor;
            }
            else
            {
                r_BulidBoardButtons[i_Row, i_Col].BackColor = Player2Name.BackColor;
            }

            r_BulidBoardButtons[i_Row, i_Col].Refresh();
        }

        private void boardButton_click(object sender, EventArgs e)
        {
            BoardButton currentButton = sender as BoardButton;
            m_Game.PlayerMove(currentButton.Rows, currentButton.Cols);

            if (m_IsAgainstComputer)
            {
                computerPlay();
            }
        }

        private void computerPlay()
        {
            m_NumOfClicks++;
            m_CurrentPlayer = m_Game.GetCurrentPlayer;

            if (m_NumOfClicks % 2 == 0 && m_CurrentPlayer == 2)
            {
                m_Game.ComputerPlays();
                m_NumOfClicks = 0;
            }
        }

        private void roundFinished()
        {
            string result = m_Game.TheWinnerIssss();
            DialogResult playAnotherGame = MessageBox.Show(
                string.Format(
                    @"The winner isssssssssss:   {0} 
Would you like to play another round?",
    result),
    "Game Over!",
    MessageBoxButtons.YesNo);
            if (playAnotherGame == DialogResult.Yes)
            {
                newGame();
            }
            else
            {
                MessageBox.Show("Thank you for playing!", "Good Bye");
                Close();
            }
        }

        private void newGame()
        {
            if (m_WithPhotos)
            {
                foreach (BoardButton currentButton in r_BulidBoardButtons)
                {
                    currentButton.BackgroundImage = null;
                    clearAndEnableButton(currentButton);
                }
            }
            else
            {
                foreach (BoardButton currentButton in r_BulidBoardButtons)
                {
                    currentButton.Text = string.Empty;
                    clearAndEnableButton(currentButton);
                }
            }

            m_Game.NewGame();
        }

        private void clearAndEnableButton(BoardButton i_CurrentButton)
        {
            i_CurrentButton.Enabled = true;
            i_CurrentButton.BackColor = BoardButton.DefaultBackColor;
            i_CurrentButton.UseVisualStyleBackColor = true;
            i_CurrentButton.Refresh();
        }
    }
}