using System;
using System.Collections.Generic;

namespace BoardGame
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private static Dictionary<int, Dictionary<int, Coordinate>> _coordinatePool;

        private Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Coordinate GetInstance(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new Exception("Invalid coordinates");
            }

            if (_coordinatePool == null)
            {
                _coordinatePool = new Dictionary<int, Dictionary<int, Coordinate>>();
            }

            if (!_coordinatePool.ContainsKey(x))
            {
                _coordinatePool.Add(x, new Dictionary<int, Coordinate>());
            }

            if (!_coordinatePool[x].ContainsKey(y))
            {
                _coordinatePool[x].Add(y, new Coordinate(x, y));
            }

            return _coordinatePool[x][y];
        }
    }
}