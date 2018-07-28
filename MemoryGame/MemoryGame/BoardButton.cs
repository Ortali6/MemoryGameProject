using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameUI
{
    internal class BoardButton : Button
    {
        private int m_Rows;
        private int m_Cols;

        internal BoardButton()
            : base()
        {
        }

        internal BoardButton(int i_Rows, int i_Cols)
        {
            m_Rows = i_Rows;
            m_Cols = i_Cols;
        }

        public int Rows
        {
            get
            {
                return m_Rows;
            }
        }

        public int Cols
        {
            get
            {
                return m_Cols;
            }
        }
    }
}
