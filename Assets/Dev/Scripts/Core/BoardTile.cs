using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardTile;

public class BoardTile : MonoBehaviour
{
    [SerializeField] private Coordinate _coordinate;
    [SerializeField] private bool _active = false;
    [SerializeField] private bool _visible = false;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public Coordinate Coordinate { get { return _coordinate; } set { _coordinate = value; } }
    public bool Active { get { return _active; } set { SetActive(value); } }
    public bool Visible { get { return _visible; } set { SetVisible(value); } }
    public void Init(EBoardTileType boardTileType, Coordinate coordinate, bool active, bool visible, Sprite sprite)
    {
        BoardTileType = boardTileType;
        Coordinate = coordinate;
        Active = active;
        Visible = visible;
        _spriteRenderer.sprite = sprite;
        transform.localPosition = new Vector3(coordinate.X, -coordinate.Y * (BoardTileType == EBoardTileType.Hexagon ? 0.85f : 1));
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

    private void OnMouseOver()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        _spriteRenderer.color = Color.red;
    }
    private void OnMouseExit()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        _spriteRenderer.color = Color.white;
    }
    private void OnMouseDown()
    {
        BoardTileState = EBoardTileState.Selected;
        BoardTileInteractState = EBoardTileInteractState.MouseDown;
        _spriteRenderer.color = Color.green;
    }
    public enum EBoardTileType
    {
        None,
        Square,
        Hexagon
    }
    public EBoardTileType BoardTileType;
    public enum EBoardTileState
    {
        None,
        Selected,
    }
    public EBoardTileState BoardTileState;
    public enum EBoardTileInteractState
    {
        None,
        Dragging,
        MouseDown
    }
    public EBoardTileInteractState BoardTileInteractState;
}
