using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCommunity.UnitySingleton;
public class CameraManager : MonoSingleton<CameraManager>
{
    public Camera camera;
    [SerializeField] private Vector3 offset;

    private Vector3 _position;
    public Vector3 Position { get { return _position; } set { SetPosition(value); } }
    private float _orthographicSize;
    public float OrthographicSize { get { return _orthographicSize; } set { SetOrthographicSize(value); } }
    [HideInInspector] public Camera Camera { get { return camera; } private set { } }

    private void Start()
    {
        
    }
    private void SetPosition(Vector3 position)
    {
        camera.transform.position = position;
    }
    private void SetOrthographicSize(float size)
    {
        Camera.orthographicSize = size;
    }
}
