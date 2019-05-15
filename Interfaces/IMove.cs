namespace Scripts
{
    public interface IMove
    {
        IPosition From { get; }
        IPosition To { get; }
    }
}