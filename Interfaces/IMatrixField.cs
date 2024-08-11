namespace Conway_s_Game_of_Life.Interfaces
{
    internal interface IMatrixField
    {
        void CreateMatrix();        
        void CheckNeighbors();
        void DrawMatrix();
        
    }
}
