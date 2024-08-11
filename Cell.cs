using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    internal class Cell
    {
        int[] hp = { 0, 1, 2, 3, 4 };
        string[] visual = { "•", "▫", "▪", "□", "■" };

        int index;

        public int Index
        {
            get { return index; }
            set
            {
                if (value < 0 || value >= hp.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Index is out of range.");
                }
                index = value;
            }
        }


        public int Hp
        {
            get { return hp[index]; }
        }

        public string Visual
        {
            get { return visual[index]; }
        }

        public Cell(int Index)
        {
            index = Index;
        }        
    }
}
