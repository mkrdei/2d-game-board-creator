using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardCreator;
using static BoardTile;

public static class BoardManager
{
    public static BoardData Data;
    public static Vector2 SpaceBetweenTiles
    {
        get
        {
            switch (Data.boardTileType)
            {
                case EBoardTileType.Square:
                    return new Vector2(1, 1);
                case EBoardTileType.Hexagon:
                    return new Vector2(1, 0.85f);
                default:
                    return new Vector2(1, 1);
            }
        }
    }
}
