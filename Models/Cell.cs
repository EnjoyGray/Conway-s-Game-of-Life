namespace Conway_s_Game_of_Life.Models
{
    internal abstract class Cell
    {
        public int _hp { get; set; }
        public string _visual { get; set; }

        public Cell(int hp, string visual)
        {
            _hp = hp;
            _visual = visual;
        }

        public abstract void Draw();
    }


    internal class CellLight : Cell
    {
        public CellLight() 
            : base(1, "L")
        {
        
        }


        public override void Draw()
        {
            switch (_hp) 
            {   case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(_visual);
                    break;

                case 1:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_visual);
                    break;
            }
            Console.ResetColor();
        }

    }

    internal class CellMedium : Cell
    {
        public CellMedium()
            : base(2, "M")
        {

        }
        public override void Draw()
        {
            switch (_hp)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(_visual);
                    break;

                case 1:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_visual);
                    break;

                case 2:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(_visual);
                    break;
            }
            Console.ResetColor();
        }
    }

    internal class CellHeavy : Cell
    {
        public CellHeavy()
            : base(3, "H")
        {

        }
        public override void Draw()
        {
            switch (_hp)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(_visual);                    
                    break;

                case 1:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_visual);                    
                    break;

                case 2:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(_visual);                    
                    break;

                case 3:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(_visual);
                    break;


                default:
                    if (_hp > 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (_hp < 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }                    
                    Console.Write(_visual);
                    break;

            }
            Console.ResetColor();
        }

    }    
}

