using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTileGroup : MonoBehaviour
{
    [SerializeField] private MoveableTileGroupData data;

    public void Init(MoveableTileGroupData data)
    {
        this.data = data;
    }
    private void OnMouseDrag()
    {
        Vector3 screenToWorldPosition = CameraManager.Instance.camera.ScreenToWorldPoint(Input.mousePosition);
        screenToWorldPosition.z = 0;
        transform.position = screenToWorldPosition;
    }
    private void OnMouseUp()
    {
        App_EventManager.OnMoveableTileGroupMouseUp.Invoke(this);
    }
}
