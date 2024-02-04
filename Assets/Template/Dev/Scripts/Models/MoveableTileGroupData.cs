using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MoveableTileGroupData
{
    public string id;
    public string encodedData;

    public MoveableTileGroupData(string id, string encodedData)
    {
        this.id = id;
        this.encodedData = encodedData;
    }
}
