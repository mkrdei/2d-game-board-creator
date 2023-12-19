using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoardTile_SpriteDataCollection : ScriptableObject
{
    public List<SpriteData> spriteDataList;

    [Serializable]
    public class SpriteData
    {
        public BoardTile.EBoardTileType BoardTileType;
        public Sprite Sprite;
    }
}
