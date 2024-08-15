using Conway_s_Game_of_Life.Interfaces;

namespace Conway_s_Game_of_Life.Models
{

    internal class MatrixField : IMatrixField
    {
        int x;
        int y;
        Cell[,] Matrix;
        Cell cellDead;
        List<Cell> cells = new List<Cell>();
        Random random = new Random();

        public MatrixField(int X, int Y)
        {
            x = X;
            y = Y;
            Matrix = new Cell[x, y];
                        
            Cell cellLight = new CellLight();
            Cell cellMedium = new CellMedium();
            Cell cellHeavy = new CellHeavy();

            cells.Add(cellLight);
            cells.Add(cellMedium);
            cells.Add(cellHeavy);
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

                    Cell cell = cells[cellVarRandom];                    

                    var CellLifeOrDeadRandom = random.Next(2);

                    //Matrix[j, i] = cell; 

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


        //public void CheckLife()
        //{
        //    for (int i = 0; i < y; i++)
        //    {
        //        for (int j = 0; j < x; j++)
        //        {                           
        //            Cell currentCell = Matrix[j, i];
        //            Cell cellDead = currentCell;
        //            cellDead._hp = 0;
        //
        //            if (currentCell != cellDead)
        //            {
        //                if (currentCell._hp > 1)
        //                {
        //                    --currentCell._hp;
        //                }
        //                else
        //                {
        //                    Matrix[j, i] = cellDead;
        //                }
        //            }
        //        }
        //    }
        //}

        public void DrawMatrix()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    //Console.BackgroundColor = ConsoleColor.Black;                  

                    //if (Matrix[j, i]._hp == 0)
                    //{
                    //    Console.BackgroundColor = ConsoleColor.Black;
                    //    Console.ForegroundColor = ConsoleColor.Black;
                    //    Console.Write(Matrix[j, i]._visual);                        
                    //}
                    //else if (Matrix[j, i]._hp == 1)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Green;
                    //    Console.Write(Matrix[j, i]._visual);                        
                    //}
                    //else if (Matrix[j, i]._hp == 2)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Yellow;
                    //    Console.Write(Matrix[j, i]._visual);
                    //}
                    //else if (Matrix[j, i]._hp == 3)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.Write(Matrix[j, i]._visual);
                    //}


                    //Console.Write(Matrix[j, i].Draw);
                    Matrix[j, i].Draw();
                }
                
                Console.ResetColor();
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
                                        
                    Cell cellDead = updatedMatrix[j, i];
                    cellDead._hp = 0;

                    if (Matrix[j, i] != cellDead)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3) // 1 і 3 правило
                        {
                            updatedMatrix[j, i] = cellDead;
                        }
                        
                        else if (liveNeighbors == 2 || liveNeighbors == 3) // 2 правило
                        {
                            updatedMatrix[j, i] = Matrix[j, i];
                        }
                    }                    

                    else if (Matrix[j, i] == cellDead) // 4 правило
                    {
                        if (liveNeighbors == 3)
                        {
                            updatedMatrix[j, i]._hp = 1;
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


