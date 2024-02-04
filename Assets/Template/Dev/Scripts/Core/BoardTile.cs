using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using DG.Tweening;
public class BoardTile : MonoBehaviour, IBoardTile
{
    public BoardTileData Data;
    [SerializeField] internal List<BoardTile_SpriteData> spriteDataList;
    [SerializeField] internal List<BoardTile_ColliderData> _colliderDataList;
    [SerializeField] internal SpriteRenderer _spriteRenderer;
    [SerializeField] internal Color defaultColor;
    [SerializeField] internal Color hoverColor;
    [SerializeField] internal Color selectedColor;
    public virtual void Init(BoardTileData boardTileData)
    {
        Data = boardTileData;
        SetPosition();
        SetCollider(StaticBoardManager.Data.boardTileType);
        _spriteRenderer.sprite = spriteDataList.Find(j => (int)j.boardTileType == Data.BoardTileType).sprite;
        _spriteRenderer.color = defaultColor;
    }
    internal virtual void SetCollider(ShapeType boardTileType)
    {
        _colliderDataList.ForEach(colliderData => { colliderData.collider.enabled = (colliderData.boardTileType == boardTileType); });
    }
    internal virtual void SetPosition()
    {
        transform.localPosition = new Vector3(Data.Coordinate.X, -Data.Coordinate.Y * StaticBoardManager.SpaceBetweenTiles.y);
    }

    internal virtual void OnMouseOver()
    {
        if (SelectionState == ESelectionState.Selected) return;
        SetSelectionState(ESelectionState.Hovered);
        SetColor(hoverColor, 0.5f);
    }
    internal virtual void OnMouseExit()
    {
        if (SelectionState == ESelectionState.Selected) return;
        SetSelectionState(ESelectionState.None);
        SetColor(defaultColor, 0.5f);
    }
    internal virtual void OnMouseDown()
    {
        if (SelectionState == ESelectionState.Selected) return;
        SetSelectionState(ESelectionState.Selected);
        SetColor(selectedColor, 0.5f);
    }
    internal virtual void OnMouseDrag()
    {
        SetMovementState(EMovementState.Dragging);
    }
    internal virtual void SetSelectionState(ESelectionState state)
    {
        SelectionState = state;
        Data.SelectionState = (int)SelectionState;
    }
    internal virtual void SetMovementState(EMovementState state)
    {
        MovementState = state;
    }

    internal virtual void SetColor(Color color, float duration = 0f)
    {
        _spriteRenderer.DOColor(color, duration);
    }
    public enum ShapeType
    {
        Square,
        Hexagon1
    }
    public enum ESelectionState
    {
        None,
        Hovered,
        Selected,
    }
    public ESelectionState SelectionState;
    public enum EMovementState
    {
        None,
        Dragging
    }
    public EMovementState MovementState;

}
