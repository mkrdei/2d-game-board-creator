
using System.Collections.Generic;

namespace Dev.Scripts.Utilities
{

    [System.Serializable]
    public struct Coordinate
    {
        public float X;
        public float Y;
        public Coordinate(float x, float y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Coordinate other)
        {
            if (other.X == X && other.Y == Y)
            {
                return true;
            }
            return false;
        }

        public bool Equals(int x, int y)
        {
            if (x == X && y == Y)
            {
                return true;
            }
            return false;
        }

        public static Coordinate operator +(Coordinate c1 , Coordinate c2)
        {
            return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
        }

        public List<Coordinate> GetNeighbourDirections(CoordinateDirection direction)
        {
            if (direction == CoordinateDirection.FourPoint)
                return new List<Coordinate>()
                {
                    new Coordinate(X + 1, Y + 0),  // →
                    new Coordinate(X - 1, Y + 0),  // ←
                    new Coordinate(X + 0, Y + 1),  // ↑
                    new Coordinate(X + 0, Y - 1),  // ↓
                };
            return new List<Coordinate>()
            {
                new Coordinate(X + 1, Y + 0),  // →
                new Coordinate(X - 1, Y + 0),  // ←
                new Coordinate(X + 0, Y + 1),  // ↑
                new Coordinate(X + 0, Y - 1),  // ↓
                new Coordinate(X + 1, Y + 1),  // ↗
                new Coordinate(X - 1, Y + 1),  // ↖
                new Coordinate(X + 1, Y - 1),  // ↘
                new Coordinate(X - 1, Y - 1)   // ↙
            };
        }
    }

    public enum CoordinateDirection
    {
        FourPoint,
        EightPoint,
    }
}


