namespace Scripts
{
    public interface IGame
    {
        IPlayer winer { get; }
        void StartGameLoop();
    }
}