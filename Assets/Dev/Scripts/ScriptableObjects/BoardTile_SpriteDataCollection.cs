using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoardTile_SpriteDataCollection : ScriptableObject
{
    public List<SpriteData> SpriteDataList;

    [Serializable]
    public class SpriteData
    {
        public BoardTile.EBoardTileType boardTileType;
        public Sprite sprite;
    }
}
