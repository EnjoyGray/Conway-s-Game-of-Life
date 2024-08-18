using Conway_s_Game_of_Life.Interfaces;

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
                    int cellVarRandom = random.Next(3);

                    Cell cell = CreateCell(cellVarRandom);                    

                    var CellLifeOrDeadRandom = random.Next(2);

                    if (CellLifeOrDeadRandom == 0)
                    {
                        cell._hp = 0;
                        result = cell;
                    }
                    else
                    {
                        cell._hp = 1;
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
                    int liveNeighbors = CountLiveNeighbors(j, i);                                         

                    if (Matrix[j, i]._hp != 0)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3) // 1 і 3 правило
                        {
                            updatedMatrix[j, i]._hp--;
                        }
                        
                        else if (liveNeighbors == 2 || liveNeighbors == 3) // 2 правило
                        {
                            updatedMatrix[j, i] = Matrix[j, i];
                        }
                    }                    

                    else if (Matrix[j, i]._hp == 0) // 4 правило
                    {
                        if (liveNeighbors == 3)
                        {
                            if (liveNeighbors == 3)
                            {                                    
                                if (Matrix[j, i] is CellLight)
                                {
                                    updatedMatrix[j, i] = new CellLight();
                                }
                                else if (Matrix[j, i] is CellMedium)
                                {
                                    updatedMatrix[j, i] = new CellMedium();
                                }
                                else if (Matrix[j, i] is CellHeavy)
                                {
                                    updatedMatrix[j, i] = new CellHeavy();
                                }
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
                        if (Matrix[neighborX, neighborY]._hp != 0)
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


