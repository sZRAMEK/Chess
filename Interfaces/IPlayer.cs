using Scripts.Figures;

namespace Scripts
{
    public interface IPlayer
    {
        Color Color { get; }
        void Move();
        int RemainingTime();
    }
}