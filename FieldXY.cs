using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{ 

    class FieldXY
    {

        public int x { get; private set; }
        public int y { get; private set; }


        public FieldXY(int value)
        {
           this.x = value;
           this.y = value;

        }
                
    }

    class CreateField : FieldXY
    {
        private static Random random = new Random();

        char[,] field;


        public CreateField(int value)
            : base(value)
        {
            ToFillField();
            DrawField();
        }

        private void ToFillField()
        {
            field = new char[this.x, this.y];

            foreach (int i in Enumerable.Range(0, this.y))
            {            
                foreach (int j in Enumerable.Range(0, this.x))
                {
                    field[j, i] = random.Next(2) == 0 ? '#' : '.';
                }
                
            }
            Console.WriteLine();
        }

        private void DrawField()
        {
            int x = field.GetLength(0);
            int y = field.GetLength(1);

            foreach (int i in Enumerable.Range(0, y))
            {
                foreach (int j in Enumerable.Range(0, y))
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    
    
}


