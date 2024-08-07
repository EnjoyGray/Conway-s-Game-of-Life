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
        public WhileRender(int x = 20, int y = 20)
        {           
            while (true)
            {
                Console.WriteLine(count++);
                FieldXY myRun = new FieldXY(x, y);
                Console.ReadKey();
                
            }
            
        }

    }
}
