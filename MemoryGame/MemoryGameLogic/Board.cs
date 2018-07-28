using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGameLogic
{
    public class Board
    {
        private const int k_Start = 0;
        private const int k_Full = 1;
        private readonly int r_BoardLength;
        private readonly int r_BoardWidth;
        private readonly char[,] r_BoardStart;
        private readonly char[,] r_BoardFull;

        public Board()
        {
        }

        public Board(int i_BoardLength, int i_BoardWidth)
        {
            r_BoardLength = i_BoardLength;
            r_BoardWidth = i_BoardWidth;
            r_BoardStart = new char[r_BoardLength, r_BoardWidth];
            r_BoardFull = new char[r_BoardLength, r_BoardWidth];

            if(r_BoardLength > 0 && r_BoardWidth > 0)
            {
                fillFirstBoard(r_BoardFull);
            }
        }

        public char this[int i_Length, int i_Width, int i_StartOrFull]
        {
            get
            {
                if(i_StartOrFull == k_Start)
                {
                    return r_BoardStart[i_Length, i_Width];
                }
                else
                {
                    if(i_StartOrFull == k_Full)
                    {
                        return r_BoardFull[i_Length, i_Width];
                    }
                }

                return '1';
            }

            set
            {
                r_BoardStart[i_Length, i_Width] = value;
            }
        }

        private void fillFirstBoard(char[,] io_BoardFull)
        {
            char letter = 'A';
            int letterChanger = 0;
            int amountOfCells = r_BoardLength * r_BoardWidth;
            int countIfFull = 0;
            int row;
            int column;
            Random rand = new Random();
            do
            {
                row = rand.Next(0, r_BoardLength);
                column = rand.Next(0, r_BoardWidth);
                if(!char.IsLetter(io_BoardFull[row, column]))
                {
                    io_BoardFull[row, column] = letter;
                    letterChanger++;
                    countIfFull++;
                    if(letterChanger == 2)
                    {
                        letter++;
                        letterChanger = 0;
                    }
                }
            }
            while(countIfFull < amountOfCells);
        }

        public int BoardSize
        {
            get
            {
                return r_BoardLength * r_BoardWidth;
            }
        }

        public int BoardLength
        {
            get
            {
                return r_BoardLength;
            }
        }

        public int BoardWidth
        {
            get
            {
                return r_BoardWidth;
            }
        }

        public StringBuilder PrintStartBoard()
        {
            StringBuilder PrintBoard = new StringBuilder();
            char space = ' ';
            char equal = '=';
            char letter = 'A';
            char number = '1';
            char line = '|';
            int amountOfEquals = (6 * r_BoardWidth) + r_BoardWidth + 1;
            PrintBoard.Append(space, 3);
            for(int i = 0; i < r_BoardWidth; i++)
            {
                PrintBoard.Append(space, 3);
                PrintBoard.Append(letter);
                letter++;
                PrintBoard.Append(space, 3);
            }

            for(int i = 0; i < r_BoardLength; i++)
            {
                PrintBoard.AppendLine();
                PrintBoard.Append(space, 3);
                PrintBoard.Append(equal, amountOfEquals);
                PrintBoard.AppendLine();
                PrintBoard.Append(number);
                number++;
                PrintBoard.Append(space, 2);
                for(int j = 0; j < r_BoardWidth; j++)
                {
                    PrintBoard.Append(line);
                    if(char.IsLetter(this[i, j, 0]))
                    {
                        PrintBoard.Append(space, 2);
                        PrintBoard.Append(this[i, j, 0]);
                        PrintBoard.Append(space, 3);
                    }
                    else
                    {
                        PrintBoard.Append(space, 6);
                    }
                }

                PrintBoard.Append(line);
            }

            PrintBoard.AppendLine();
            PrintBoard.Append(space, 3);
            PrintBoard.Append(equal, amountOfEquals);
            return PrintBoard;
        }

        public bool BorderCheck(int i_Row, int i_Column)
        {
            bool IsBorderLegal = false;
            if(i_Row >= 0 && i_Row < r_BoardLength && i_Column >= 0 && i_Column < r_BoardWidth)
            {
                IsBorderLegal = true;
            }

            return IsBorderLegal;
        }

        public bool IsLocationAvailable(int i_Row, int i_Column)
        {
            bool IsLocationAvailable = true;
            if(char.IsLetter(this[i_Row, i_Column, 0]))
            {
                IsLocationAvailable = false;
            }

            return IsLocationAvailable;
        }

        public void UpdateBoard(int i_Row, int i_Column)
        {
            this[i_Row, i_Column, 0] = this[i_Row, i_Column, 1];
        }

        public char CurrentLetter(int i_Row, int i_Column)
        {
            return this[i_Row, i_Column, 1];
        }

        public void DeleteMoves(int i_Row, int i_Column)
        {
            this[i_Row, i_Column, 0] = '0';
        }
    }
}
