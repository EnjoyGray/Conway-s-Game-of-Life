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


        public CreateField(int value = 20)
            : base(value)
        {
            DrawField();
        }

        private void DrawField()
        {
            foreach (int i in Enumerable.Range(0, this.y))
            {            
                foreach (int j in Enumerable.Range(0, this.x))
                {
                    char randomChar = random.Next(2) == 0 ? '#' : '.';

                    Console.Write(randomChar);
                }
                Console.WriteLine();
            }
        }
    }

    
    
}


