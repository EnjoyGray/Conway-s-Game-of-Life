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
            Console.Write(_hp);
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
            Console.Write(_hp);
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
            Console.Write(_hp);
        }
        
    }    
}

