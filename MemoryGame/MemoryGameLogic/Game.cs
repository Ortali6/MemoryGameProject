using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGameLogic
{
    public delegate void DrawValueDelegate(int i_Row, int i_Col);

    public delegate void EndGameDelegate();

    public delegate void UpdatePointsDelegate();

    public delegate void UpdateNextPlayerDelegate();

    public delegate void ClearTwoButtonsDelegate(int i_Row1, int i_Col1, int i_Row2, int i_Col2);

    public delegate void EnableButtonsDelegate(int i_Row1, int i_Col1, int i_Row2, int i_Col2);

    public class Game
    {
        public event DrawValueDelegate m_DrawValueDelegate;

        public event EndGameDelegate m_EndGameDelegate;

        public event UpdatePointsDelegate m_UpdatePointsDelegate;

        public event UpdateNextPlayerDelegate m_UpdateNextPlayerDelegate;

        public event ClearTwoButtonsDelegate m_ClearTwoButtonsDelegate;

        public event EnableButtonsDelegate m_EnableButtonsDelegate;

        private Player m_Player1, m_Player2, m_Player3;
        private Board m_Board;
        private char[,] m_ComputerBoard;
        private LocationOnBoard m_CurrentLocation, m_FirstLocation, m_ComputerLocation;
        private bool m_IsComputer;
        private int m_NumberOfMoves;
        private int m_CurrentPlayer;

        public Game()
        {
            m_NumberOfMoves = 0;
            m_CurrentPlayer = 1;
        }

        private bool gameOver
        {
            get
            {
                int sumOfPoints;
                int maxAmountOfMaxPoints = m_Board.BoardSize / 2;
                bool IsMaxPoints = false;
                if (m_IsComputer)
                {
                    sumOfPoints = m_Player1.Points + m_Player3.Points;
                }
                else
                {
                    sumOfPoints = m_Player1.Points + m_Player2.Points;
                }

                if (maxAmountOfMaxPoints == sumOfPoints)
                {
                    IsMaxPoints = true;
                }

                return IsMaxPoints;
            }
        }

        private void updateFirstLocation()
        {
            m_FirstLocation.Row = m_CurrentLocation.Row;
            m_FirstLocation.Column = m_CurrentLocation.Column;
        }

        private void updateBoard()
        {
            m_Board.UpdateBoard(m_CurrentLocation.Row, m_CurrentLocation.Column);
        }

        private bool isDouble()
        {
            int row1 = m_FirstLocation.Row;
            int row2 = m_CurrentLocation.Row;
            int column1 = m_FirstLocation.Column;
            int column2 = m_CurrentLocation.Column;
            bool IsDouble = false;
            if (m_Board[row1, column1, 0] == m_Board[row2, column2, 0])
            {
                IsDouble = true;
            }

            return IsDouble;
        }

        private void deleteMoves()
        {
            m_Board.DeleteMoves(m_FirstLocation.Row, m_FirstLocation.Column);
            m_Board.DeleteMoves(m_CurrentLocation.Row, m_CurrentLocation.Column);
        }

        private void computerChooseLocation()
        {
            bool IsAvailable;
            Random rand = new Random();
            do
            {
                m_ComputerLocation.Row = rand.Next(0, m_Board.BoardLength);
                m_ComputerLocation.Column = rand.Next(0, m_Board.BoardWidth);
                IsAvailable = m_Board.IsLocationAvailable(m_ComputerLocation.Row, m_ComputerLocation.Column);
            }
            while (!IsAvailable);
        }

        public char CurrentLetter(int i_Row, int i_Column)
        {
            return m_Board.CurrentLetter(i_Row, i_Column);
        }

        private void updateNextPlayer()
        {
            if (m_CurrentPlayer == 1)
            {
                m_CurrentPlayer = 2;
            }
            else
            {
                m_CurrentPlayer = 1;
            }
        }

        private void updateBoardAndScreen(int i_Row, int i_Column)
        {
            NumberOfMoves += 1;
            if (NumberOfMoves == 3)
            {
                m_ClearTwoButtonsDelegate.Invoke(m_CurrentLocation.Row, m_CurrentLocation.Column, m_FirstLocation.Row, m_FirstLocation.Column);
                NumberOfMoves = 1;
            }

            updateCurrentLocation(i_Row, i_Column);
            updateBoard();
            m_DrawValueDelegate.Invoke(i_Row, i_Column);
        }

        public void PlayerMove(int i_Row, int i_Col)
        {
            updateBoardAndScreen(i_Row, i_Col);
            moves();
        }

        private void moves()
        {
            if (NumberOfMoves == 1)
            {
                updateFirstLocation();
            }
            else
            {
                if (NumberOfMoves == 2)
                {
                    if (isDouble())
                    {
                        if (m_CurrentPlayer == 1)
                        {
                            updatePointsFirstPlayer();
                        }
                        else
                        {
                            updatePointsSecondPlayer();
                        }

                        NumberOfMoves = 0;
                        m_UpdatePointsDelegate.Invoke();
                        if (gameOver)
                        {
                            m_EndGameDelegate.Invoke();
                        }
                    }
                    else
                    {
                        notDouble();
                    }
                }
            }
        }

        private void notDouble()
        {
            deleteMoves();
            updateNextPlayer();
            m_UpdateNextPlayerDelegate.Invoke();
            m_EnableButtonsDelegate.Invoke(m_CurrentLocation.Row, m_CurrentLocation.Column, m_FirstLocation.Row, m_FirstLocation.Column);
        }

        public void ComputerPlays()
        {
            computerFirstMove();
            computerSecondMove();
            System.Threading.Thread.Sleep(500);
        }

        private void computerOneMove()
        {
            computerChooseLocation();
            updateBoardAndScreen(m_ComputerLocation.Row, m_ComputerLocation.Column);
        }

        private void computerFirstMove()
        {
            System.Threading.Thread.Sleep(500);
            computerOneMove();
            updateFirstLocation();
        }

        private void computerSecondMove()
        {
            System.Threading.Thread.Sleep(500);
            computerOneMove();

            if (isDouble())
            {
                updatePointsComputer();
                NumberOfMoves = 0;
                m_UpdatePointsDelegate.Invoke();

                if (!gameOver)
                {
                    computerFirstMove();
                    computerSecondMove();
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    m_EndGameDelegate.Invoke();
                }
            }
            else
            {
                notDouble();
            }
        }

        public string TheWinnerIssss()
        {
            if (!m_IsComputer)
            {
                if (m_Player1.Points > m_Player2.Points)
                {
                    return string.Format(
    @"{0}! with {1} points!
while {2} has {3} points",
    m_Player1.Name,
    m_Player1.Points,
    m_Player2.Name,
    m_Player2.Points);
                }
                else
                {
                    if (m_Player1.Points < m_Player2.Points)
                    {
                        return string.Format(
    @"{0}! with {1} points!
while {2} has {3} points",
    m_Player2.Name,
    m_Player2.Points,
    m_Player1.Name,
    m_Player1.Points);
                    }
                    else
                    {
                        return "No one! it's a tie";
                    }
                }
            }
            else
            {
                if (m_Player1.Points > m_Player3.Points)
                {
                    return string.Format(
    @"{0}! with {1} points!
while the computer has {2} points",
    m_Player1.Name,
    m_Player1.Points,
    m_Player3.Points);
                }
                else
                {
                    if (m_Player1.Points < m_Player3.Points)
                    {
                        return string.Format(
    @"Computer! with {0} points!
while you have {1} points",
    m_Player3.Points,
    m_Player1.Points);
                    }
                    else
                    {
                        return "No one! it's a tie";
                    }
                }
            }
        }

        private void updateCurrentLocation(int i_Row, int i_Column)
        {
            m_CurrentLocation.Row = i_Row;
            m_CurrentLocation.Column = i_Column;
        }

        public void FirstPlayer(string io_Name)
        {
            m_Player1 = new Player(io_Name);
        }

        public void SecondPlayer(string io_Name)
        {
            m_Player2 = new Player(io_Name);
            m_IsComputer = false;
        }

        public void ComputerPlayer()
        {
            m_Player3 = new Player();
            m_IsComputer = true;
        }

        private void updatePointsFirstPlayer()
        {
            m_Player1.Points++;
        }

        private void updatePointsSecondPlayer()
        {
            m_Player2.Points++;
        }

        private void updatePointsComputer()
        {
            m_Player3.Points++;
        }

        public int GetFirstPlayerPoints
        {
            get
            {
                return m_Player1.Points;
            }
        }

        private void resetPoints()
        {
            m_Player1.Points = 0;
            if (!m_IsComputer)
            {
                m_Player2.Points = 0;
            }
            else
            {
                m_Player3.Points = 0;
            }
        }

        public int GetSecondPlayerPoints
        {
            get
            {
                return m_Player2.Points;
            }
        }

        public int GetComputerPoints
        {
            get
            {
                return m_Player3.Points;
            }
        }

        public string GetFirstPlayerName
        {
            get
            {
                return m_Player1.Name;
            }
        }

        public string GetSecondPlayerName
        {
            get
            {
                return m_Player2.Name;
            }
        }

        public int GetCurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_Board.BoardSize;
            }
        }

        public int BoardLength
        {
            get
            {
                return m_Board.BoardLength;
            }
        }

        public int BoardWidth
        {
            get
            {
                return m_Board.BoardWidth;
            }
        }

        public bool BorderCheck(int i_Row, int i_Column)
        {
            return m_Board.BorderCheck(i_Row, i_Column);
        }

        public bool IsLocationAvailable(int i_Row, int i_Column)
        {
            return m_Board.IsLocationAvailable(i_Row, i_Column);
        }

        public int CurrentLocationRow
        {
            get
            {
                return m_CurrentLocation.Row;
            }
        }

        public int CurrentLocationColumn
        {
            get
            {
                return m_CurrentLocation.Column;
            }
        }

        public int NumberOfMoves
        {
            get
            {
                return m_NumberOfMoves;
            }

            set
            {
                m_NumberOfMoves = value;
            }
        }

        public StringBuilder PrintBoard()
        {
            return m_Board.PrintStartBoard();
        }

        public void BuildBoard(int i_Length, int i_Width)
        {
            m_Board = new Board(i_Length, i_Width);
            if (m_IsComputer)
            {
                m_ComputerBoard = new char[i_Length, i_Width];
            }
        }

        public bool CheckIfEven(int io_Number1, int io_Number2)
        {
            bool IsNumEven = true;
            if ((io_Number1 * io_Number2) % 2 == 1)
            {
                IsNumEven = false;
            }

            return IsNumEven;
        }

        public bool CheckIfBetween4To6(int io_Number)
        {
            bool IsBetween4To6 = true;
            if (io_Number < 4 || io_Number > 6)
            {
                IsBetween4To6 = false;
            }

            return IsBetween4To6;
        }

        public void ConvertToIntAndUpdateLocation(string i_CurrentLocation)
        {
            char[] locationArray = new char[2];
            locationArray = i_CurrentLocation.ToCharArray();
            m_CurrentLocation.Column = locationArray[0] - 'A';
            m_CurrentLocation.Row = (int)char.GetNumericValue(locationArray[1]) - 1;
        }

        public void NewGame()
        {
            BuildBoard(BoardLength, BoardWidth);
            m_CurrentPlayer = 1;
            resetPoints();
            m_UpdatePointsDelegate.Invoke();
            m_UpdateNextPlayerDelegate.Invoke();
        }
    }
}