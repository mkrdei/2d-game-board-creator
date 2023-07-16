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

    public Coordinate Coordinate { get { return _coordinate; } private set { _coordinate = value; } }
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
    public void SetCoordinate()
    {
        Coordinate = new Coordinate((int)transform.localPosition.x, -(int)transform.localPosition.y);
    }
}
