using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    [SerializeField] private Coordinate _coordinate;
    [SerializeField] private bool _active = false;
    [SerializeField] private bool _visible = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public Coordinate Coordinate { get { return _coordinate; } set { _coordinate = value; OnSetCoordinate(); } }
    public bool Active { get { return _active; } set { SetActive(value); } }
    public bool Visible { get { return _visible; } set { SetVisible(value); } }
    private void Awake()
    {
        
    }
    private void SetActive(bool active)
    {
        _active = active;
        gameObject.SetActive(active);
    }
    private void SetVisible(bool visible)
    {
        _visible = visible;
        _spriteRenderer.enabled = visible;
    }
    private void OnSetCoordinate()
    {
        transform.localPosition = new Vector3(Coordinate.X, -Coordinate.Y, 0);
    }
}
