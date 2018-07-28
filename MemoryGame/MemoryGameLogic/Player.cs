using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGameLogic
{
    public class Player
    {
        private readonly string r_Name;
        private int m_Points = 0;

        public Player()
        {
        }

        public Player(string i_PlayerName)
        {
            r_Name = i_PlayerName;
        }

        public int Points
        {
            get
            {
                return m_Points;
            }

            set
            {
                m_Points = value;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }
    }
}
