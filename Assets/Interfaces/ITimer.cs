namespace Scripts
{
    public interface ITimer
    {
        int maxTime { get; }

        void Start();
        void Stop();
        int TimeFromStart();
    }
}