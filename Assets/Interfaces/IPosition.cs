using System;

namespace Scripts
{
    public interface IPosition : ICloneable
    {
        int x { get; }
        int y { get; }
        bool AreTheSame(IPosition obj);
        string AsString();
    }

    
}