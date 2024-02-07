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
    public List<ColorManager.GameColors> objectColors;

    public MoveableTileGroupData(string id, string encodedData)
    {
        this.id = id;
        this.encodedData = encodedData;
    }

    public string EncodeData(List<ColorManager.GameColors> objectColors)
    {
        encodedData = string.Empty;
        objectColors.ForEach(color => { encodedData += color; });
        return encodedData;
    }
    public List<ColorManager.GameColors> DecodeData(string encodedData)
    {
        objectColors = new List<ColorManager.GameColors>();
        var charArray = encodedData.ToCharArray();
        foreach (var encodedColor in charArray)
        {
            objectColors.Add((ColorManager.GameColors)int.Parse(encodedColor.ToString()));
        }
        return objectColors;
    }
}
