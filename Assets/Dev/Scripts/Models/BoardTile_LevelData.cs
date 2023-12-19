using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile_LevelData : MonoBehaviour
{
    public BoardTile.EBoardTileType BoardTileType;
    public Coordinate Coordinate;
    public bool Active;
    public bool Visible;
    public Sprite InitialSprite;

    public BoardTile_LevelData() { }
    public BoardTile_LevelData(BoardTile.EBoardTileType boardTileType, Coordinate coordinate, bool active, bool visible, Sprite sprite) 
    {
        BoardTileType = boardTileType;
        Coordinate = coordinate;
        Active = active;
        Visible = visible;
        InitialSprite = sprite;
    }
    
}
