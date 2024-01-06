using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardCreatorBase;
using static BoardTileBase;

public static class StaticBoardManagerBase
{
    public static BoardDataBase Data;
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
