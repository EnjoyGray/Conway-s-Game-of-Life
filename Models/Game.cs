using Conway_s_Game_of_Life.Interfaces;

namespace Conway_s_Game_of_Life.Models
{
    internal class Game : IGame
    {
        int count = 1;
        int _x;
        int _y;
        MatrixField matrixField;

        public Game(int x = 20, int y = 20)
        {
            _x = x;
            _y = y;
            matrixField = new MatrixField(_x, _y);
        }

        public void Run()
        {
            matrixField.CreateMatrix();

            while (true)
            {
                Console.WriteLine(count++);
                matrixField.CheckNeighbors();
                matrixField.DrawMatrix();
                Console.ResetColor();

                //Console.ReadKey();
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}
