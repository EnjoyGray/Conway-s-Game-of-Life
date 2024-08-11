using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    class RunGame
    {        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            IGame game = new IGame();
            game.Run();
        }
        
    }
}
