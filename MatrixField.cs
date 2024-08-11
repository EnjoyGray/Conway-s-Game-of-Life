using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{

    internal class MatrixField  
    {
        int x;
        int y;

        Cell[,] Matrix;

        Cell cellDead = new Cell(0);

        Random random = new Random();

        public MatrixField(int X, int Y)
        {
            x = X;
            y = Y;

            Matrix = new Cell[x, y];            

            CreateMatrix();
            CheckNeighbors();
            DrawMatrix(Matrix);
        }      


        private void CreateMatrix()
        {
            Matrix = new Cell[x, y];

            for (int i = 0; i < y; i++)                
            {
                for (int j = 0; j < x; j++)
                {
                    int cellVarRandom = random.Next(0, 5);
                    Cell cell = new Cell(cellVarRandom);                   

                    var lifeOrDeadRandom = random.Next(2);

                    Matrix[j, i] = lifeOrDeadRandom == 0 ? cellDead : cell;
                }
            }
        }

        private void CheckLife()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {                  
                    Cell currentCell = Matrix[j, i];

                    if (currentCell != cellDead)
                    {                        
                        if (currentCell.Hp > 1)
                        {
                            currentCell.Index--;
                        }
                        else
                        {                        
                            Matrix[j, i] = cellDead;
                        }
                    }
                }
            }
        }

        private void DrawMatrix(Cell[,] positionXY)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(positionXY[j, i].Visual);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void CheckNeighbors()
        {           
            Cell[,] updatedMatrix = (Cell[,])Matrix.Clone();
                        
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {                    
                    int liveNeighbors = CountLiveNeighbors(j, i);

                    if (Matrix[j, i] != cellDead)
                    {                        
                        if (liveNeighbors <= 1 || liveNeighbors >= 4)
                        {
                            //updatedMatrix[j, i].Index = --Matrix[j, i].Index;
                            updatedMatrix[j, i] = cellDead;
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
                        if (Matrix[neighborX, neighborY] != cellDead)
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


