using Assets.Enums;
using Scripts;
using System;

namespace Assets.Scripts
{
    public class Move : IMove
    {
        public IPosition Start { get; private set; }
        public IPosition Destination { get; private set; }

        public object Clone()
        {
            var clone = (Move)MemberwiseClone();
            clone.Start = (IPosition)this.Start.Clone();
            clone.Destination = (IPosition)this.Destination.Clone();
            
            return clone;
        }

        public Move(IPosition start, IPosition destination)
        {
            this.Start = start;
            this.Destination = destination;
            if (start.AreTheSame(destination))
                throw new ArgumentException();
            

        }

        private int Sense(int start, int destination)
        {
            return Math.Sign(destination - start);
        }

        private double DirectionalCoefficient(IPosition A, IPosition B)
        {
            if ((A.x - B.x) == 0)
            {
                return double.MaxValue;
            }
            float result = (float)(A.y - B.y) / (A.x - B.x);
            return result;
        }

        private double PoweredDistance(IPosition A, IPosition B)
        {
            return Math.Pow((B.x - A.x), 2) + Math.Pow((B.y - A.y), 2);
        }

        public int SenseVertical()
        {
            
                    return Math.Sign(Destination.y - Start.y);
              
            
        }

        public int SenseHorizontal()
        {
           
                    return Math.Sign(Destination.x - Start.x);

               
        }

        public DistanceEnum Distance()
        {
            double poweredDistance = PoweredDistance(Start,Destination);

            if (poweredDistance == 1 || poweredDistance == 2)
                return DistanceEnum.OneSquare;
            if (poweredDistance == 4)
                return DistanceEnum.TwoSquares;
            if (poweredDistance == 5)
                return DistanceEnum.OneKnightJump;
            else
                return DistanceEnum.Other;
        }

        public MoveDirection Direction()
        {
            double directionalCoefficient = DirectionalCoefficient(Start, Destination);

            if (directionalCoefficient == 0)
                return MoveDirection.Horizontally;
            if (directionalCoefficient == 1 || directionalCoefficient==-1)
                return MoveDirection.Diagonally;
            if (directionalCoefficient == double.MaxValue)
                return MoveDirection.Verticaly;
            else
                return MoveDirection.Orher;
        }

      
    }
}