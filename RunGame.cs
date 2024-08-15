using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conway_s_Game_of_Life.Interfaces;
using Conway_s_Game_of_Life.Models;

namespace Conway_s_Game_of_Life
{
    class RunGame
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IGame game = new Game(40, 20);
            game.Run();
        }
    }
}
