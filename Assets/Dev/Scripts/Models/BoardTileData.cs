using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BoardTileData
{
    public Coordinate Coordinate;
    public bool Active;
    public bool Visible;
    public Sprite InitialSprite;
    public Color InitialColor;
    public Color CurrentColor;

    public BoardTileData() { }
    public BoardTileData(BoardTile.EBoardTileType boardTileType, Coordinate coordinate, bool active, bool visible, Sprite sprite, Color initialColor, Color currentColor) 
    {
        Coordinate = coordinate;
        Active = active;
        Visible = visible;
        InitialSprite = sprite;
        InitialColor = initialColor;
        CurrentColor = currentColor;
    }
}
