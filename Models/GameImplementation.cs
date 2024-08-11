using Conway_s_Game_of_Life.Interfaces;

namespace Conway_s_Game_of_Life.Models
{
    internal class GameImplementation : IGame
    {
        int count = 1;
        int _x;
        int _y;

        public GameImplementation(int x = 20, int y = 20)
        {
            _x = x;
            _y = y;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(count++);
                IMatrixField myRun = new MatrixField(_x, _y);
                myRun.CreateMatrix();
                myRun.CheckNeighbors();                
                myRun.DrawMatrix();

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
