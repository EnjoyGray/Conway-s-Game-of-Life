using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    internal class WhileRender
    {
        int count = 1;
        int _x;
        int _y;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>

        public WhileRender(int x = 20, int y = 20)
        {           
            _x = x;
            _y = y;            
        }

        public void Run() 
        {          

            while (true)
            {
                Console.WriteLine(count++);
                FieldXY myRun = new FieldXY(_x, _y);
                Console.ReadKey();
            }
        }

    }
}
