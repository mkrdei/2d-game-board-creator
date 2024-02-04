using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardData
{
    [Header("Settings")]
    public BoardTile.ShapeType boardTileType;
    public Vector2 boardSize = new Vector2(5, 5);
    public List<BoardTileData> boardTileDataList;
}
