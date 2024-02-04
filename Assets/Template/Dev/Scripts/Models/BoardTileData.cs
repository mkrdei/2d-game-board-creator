using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardTile;

[Serializable]
public class BoardTileData
{
    public string Id;
    public int BoardTileType;
    public int SelectionState;
    public Coordinate Coordinate;
    public bool Active;
    public bool Locked;
    public bool Visible;

    public BoardTileData() { }
    public BoardTileData(string id, int boardTileType, int boardTileState, Coordinate coordinate, bool active, bool locked, bool visible) 
    {
        Id = id;
        BoardTileType = boardTileType;
        SelectionState = boardTileState;
        Coordinate = coordinate;
        Active = active;
        Locked = locked;
        Visible = visible;
    }
}
