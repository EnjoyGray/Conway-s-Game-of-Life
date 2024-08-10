using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    class Program
    {        
        static void Main(string[] args)
        {           
            WhileRender render = new WhileRender(); // default 20
            render.Run();                                       
        }      
    }
}
