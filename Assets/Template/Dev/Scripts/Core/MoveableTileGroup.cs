using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTileGroup : MonoBehaviour, IMoveableTileGroup
{
    [SerializeField] private MoveableTileGroupData data;
    [SerializeField] private MoveableTileGroupObject moveableTileGroupObjectPrefab;
    public void Init(MoveableTileGroupData data)
    {
        this.data = data;
        data.DecodeData(data.encodedData);

        SetObjects(data);
    }
    private void SetObjects(MoveableTileGroupData data)
    {
        for (int i = 0; i < data.objectColors.Count; i++) 
        {
            var groupObject = Instantiate(moveableTileGroupObjectPrefab, transform);
            groupObject.Init(data.objectColors[i], i);
        }
    }
    private void OnMouseDrag()
    {
        Vector3 screenToWorldPosition = CameraManager.Instance.camera.ScreenToWorldPoint(Input.mousePosition);
        screenToWorldPosition.z = 0;
        transform.position = screenToWorldPosition;
    }
    private void OnMouseUp()
    {
        transform.localPosition = Vector3.zero;
        App_EventManager.OnMoveableTileGroupMouseUp.Invoke(this);
    }
}
