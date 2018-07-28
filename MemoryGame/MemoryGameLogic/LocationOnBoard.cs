using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGameLogic
{
    public struct LocationOnBoard
    {
        private int m_Column;
        private int m_Row;

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }

            set
            {
                m_Column = value;
            }
        }

        public LocationOnBoard(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }
    }
}
