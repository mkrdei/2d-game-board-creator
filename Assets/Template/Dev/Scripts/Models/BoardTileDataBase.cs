using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardTileBase;

[Serializable]
public class BoardTileDataBase
{
    public int BoardTileType;
    public int BoardTileState;
    public Coordinate Coordinate;
    public bool Active;
    public bool Locked;
    public bool Visible;

    public BoardTileDataBase() { }
    public BoardTileDataBase(int boardTileType, int boardTileState, Coordinate coordinate, bool active, bool locked, bool visible) 
    {
        BoardTileType = boardTileType;
        BoardTileState = boardTileState;
        Coordinate = coordinate;
        Active = active;
        Locked = locked;
        Visible = visible;
    }
}
