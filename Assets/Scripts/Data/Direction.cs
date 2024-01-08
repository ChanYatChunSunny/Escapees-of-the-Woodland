using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum Direction : int
{
    up = 0,
    right = 1,
    down = 2,
    left = 3,
}
public class DirectionOperation
{
    public static Vector2Int DirectionToVector2Int(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return Vector2Int.up;
            case Direction.right:
                return Vector2Int.right;
            case Direction.down:
                return Vector2Int.down;
            case Direction.left:
                return Vector2Int.left;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

