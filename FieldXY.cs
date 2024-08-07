using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{

    internal class FieldXY
    {
        int x;
        int y;

        char[,] myMatrix;
        int[,] myMLifeValue;

        int maxValueLifeRange = 3; //default 1-2

        char life = '#';
        char dead = '.';

        Random random = new Random();


        public FieldXY(int x = 10, int y = 10) //default 10x10
        {
            myMatrix = new char[x, y];
            myMLifeValue = new int[x, y];

            this.x = x;
            this.y = y;

            CreateMatrix();
            //DrawMatrix(myMatrix);
            //DrawMatrix(myMLifeValue);


            CheckLife();
            //CheckNeighbors();
            DrawMatrix(myMatrix);
            //DrawMatrix(myMLifeValue);

        }


        private void CreateMatrix()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    int myRandom = random.Next(2);

                    myMatrix[j, i] = myRandom == 0 ? life : dead;
                    myMLifeValue[j, i] = myRandom == 0 ? random.Next(1, maxValueLifeRange) : 0;                                   
                }
            }
        }

        private void CheckLife()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {                 
                    //myMLifeValue[j, i] = myMLifeValue[j, i] <= 1 ? 0 : --myMLifeValue[j, i];
                    //myMatrix[j, i] = myMLifeValue[j, i] <= 1 ? dead : life; // щось не так !!!

                    if (myMLifeValue[j, i] <= 1)
                    {
                        myMLifeValue[j, i] = 0;
                        myMatrix[j, i] = dead;
                    }
                    else
                    {
                        myMLifeValue[j, i] = --myMLifeValue[j, i];
                        myMatrix[j, i] = life;
                    }
                }
                //Console.WriteLine();

            }
        }

        private void DrawMatrix<T>(T[,] name) // використовую T - як "<T>(T[,] name)" як унвіерсальний метод
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(name[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void CheckNeighbors()
        {


            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                }
            }


        }
    }
}


