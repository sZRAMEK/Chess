using Assets.Enums;

namespace Scripts
{
    public interface IMove : System.ICloneable
    {
        IPosition Start { get; }
        IPosition Destination { get; }
        MoveDirection Direction();
        DistanceEnum Distance();
        int SenseHorizontal();
        int SenseVertical();
        
    }
}