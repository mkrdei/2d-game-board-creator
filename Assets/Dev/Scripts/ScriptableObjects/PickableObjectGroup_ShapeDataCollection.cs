using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PickableObjectGroup_ShapeDataCollection: ScriptableObject
{
    public List<ShapeData> ShapeDataList;
    [Serializable]
    public class ShapeData
    {
        public List<Vector2> shapeData;
    }
}
