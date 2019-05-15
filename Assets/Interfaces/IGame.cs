namespace Scripts
{
    public interface IGame
    {
        IPlayer winer { get; }
        void GameLoop(string input);
        string GetBoardDescription();
    }
}