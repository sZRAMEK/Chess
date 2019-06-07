namespace Scripts
{
    public interface IGame
    {
        void MakeMove(string input);
        string GetBoardDescription();
    }
}