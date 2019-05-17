namespace Scripts
{
    public interface IGame
    {
        IPlayer winer { get; }
        void MakeMove(string input);
        string GetBoardDescription();
    }
}