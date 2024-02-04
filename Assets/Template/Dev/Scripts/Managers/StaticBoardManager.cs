using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardCreator;
using static BoardTile;

public static class StaticBoardManager
{
    public static BoardData Data;
    public static Vector2 SpaceBetweenTiles
    {
        get
        {
            switch (Data.boardTileType)
            {
                case ShapeType.Square:
                    return new Vector2(1, 1);
                case ShapeType.Hexagon1:
                    return new Vector2(1, 0.85f);
                default:
                    return new Vector2(1, 1);
            }
        }
    }
}
