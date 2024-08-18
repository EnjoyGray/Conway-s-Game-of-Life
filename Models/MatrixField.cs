using Conway_s_Game_of_Life.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace Conway_s_Game_of_Life.Models
{

    internal class MatrixField : IMatrixField
    {
        int x;
        int y;
        Cell[,] Matrix;              
        Random random = new Random();       

        public MatrixField(int X, int Y)
        {
            x = X;
            y = Y;

            Matrix = new Cell[x, y];
        }

        private Cell CreateCell(int number)
        {
            switch (number)
            {
                case 0:
                    return new CellLight();

                case 1:
                    return new CellMedium();

                case 2:
                    return new CellHeavy();

                default:
                    throw new ArgumentOutOfRangeException(nameof(number), "Invalid cell type");
            }
        }

        public void CreateMatrix()
        {
            Matrix = new Cell[x, y];            

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Cell result;                    

                    Cell cell = CreateCell(random.Next(3));                    

                    var CellLifeOrDeadRandom = random.Next(2);

                    if (CellLifeOrDeadRandom == 0)
                    {
                        cell._hp = 0;
                        result = cell;
                    }
                    else
                    {                        
                        result = cell;                        
                    }

                    Matrix[j, i] = result;
                }
            }
        }       

        public void DrawMatrix()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {                    
                    Matrix[j, i].Draw();
                }                
                Console.WriteLine();
            }
        }

        public void CheckNeighbors()
        {
            Cell[,] updatedMatrix = (Cell[,])Matrix.Clone();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    // 1) Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                    // 2) Any live cell with two or three live neighbours lives on to the next generation.
                    // 3) Any live cell with more than three live neighbours dies, as if by overpopulation.
                    // 4) Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

                    int liveNeighbors = CountLiveNeighbors(j, i);                                         

                    if (Matrix[j, i]._hp != 0)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            updatedMatrix[j, i]._hp--;
                        }
                        
                        else if (liveNeighbors == 2 || liveNeighbors == 3)
                        {
                            updatedMatrix[j, i] = Matrix[j, i];                            
                        }
                    }                    

                    else if (Matrix[j, i]._hp == 0)
                    {
                        if (liveNeighbors == 3)
                        {
                            if (liveNeighbors == 3)
                            {
                                updatedMatrix[j, i] = CreateCell(random.Next(3));
                            }
                        }
                    }
                }
            }
            Matrix = updatedMatrix;
        }
        private int CountLiveNeighbors(int rowX, int columntY)
        {
            int liveCount = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int neighborX = rowX + i;
                    int neighborY = columntY + j;

                    if (neighborX >= 0 && neighborX < x && neighborY >= 0 && neighborY < y)
                    {
                        if (Matrix[neighborX, neighborY]._hp > 0)
                        {
                            liveCount++;
                        }
                    }
                }
            }
            return liveCount;
        }
    }
}


