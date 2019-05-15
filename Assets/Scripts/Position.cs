﻿using Scripts;

namespace Assets.Scripts
{
    public class Position : IPosition
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}