using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardDataBase
{
    [Header("Settings")]
    public BoardTileBase.EBoardTileType boardTileType;
    public Vector2 boardSize = new Vector2(5, 5);
    public List<BoardTileDataBase> boardTileDataList;
}
