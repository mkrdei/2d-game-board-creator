using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BoardTileBase : MonoBehaviour
{
    public BoardTileDataBase Data;
    [SerializeField] private List<BoardTile_ColliderDataBase> _colliderDataList;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public virtual void Init(BoardTileDataBase boardTileData)
    {
        Data = boardTileData;
        SetPosition();
        SetCollider(StaticBoardManagerBase.Data.boardTileType);
        _spriteRenderer.sprite = Data.InitialSprite;
        _spriteRenderer.color = boardTileData.InitialColor;
    }
    internal virtual void SetCollider(EBoardTileType boardTileType)
    {
        _colliderDataList.ForEach(colliderData => { colliderData.collider.enabled = (colliderData.boardTileType == boardTileType); });
    }
    internal virtual void SetPosition()
    {
        transform.localPosition = new Vector3(Data.Coordinate.X, -Data.Coordinate.Y * StaticBoardManagerBase.SpaceBetweenTiles.y);
    }

    internal virtual void OnMouseOver()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        Data.CurrentColor = Color.red;
        _spriteRenderer.color = Data.CurrentColor;
    }
    internal virtual void OnMouseExit()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        Data.CurrentColor = Data.InitialColor;
        _spriteRenderer.color = Data.CurrentColor;
    }
    internal virtual void OnMouseDown()
    {
        BoardTileState = EBoardTileState.Selected;
        BoardTileInteractState = EBoardTileInteractState.MouseDown;
        Data.CurrentColor = Color.green;
        _spriteRenderer.color = Data.CurrentColor;
    }
    public enum EBoardTileType
    {
        Square,
        Hexagon
    }
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
