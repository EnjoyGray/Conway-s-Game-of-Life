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
    }



    internal class CellLight : Cell
    {
        CellLight() 
            : base(2, "@")
        {
        
        }
    }

    internal class CellMidle : Cell
    {
    }

    internal class CellHeavy : Cell
    {
    }
}

