using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BoardTileBase : MonoBehaviour
{
    public BoardTileDataBase Data;
    [SerializeField] internal List<BoardTile_SpriteDataBase> spriteDataList;
    [SerializeField] internal List<BoardTile_ColliderDataBase> _colliderDataList;
    [SerializeField] internal SpriteRenderer _spriteRenderer;
    [SerializeField] internal Color defaultColor;
    [SerializeField] internal Color hoverColor;
    [SerializeField] internal Color selectedColor;
    public virtual void Init(BoardTileDataBase boardTileData)
    {
        Data = boardTileData;
        SetPosition();
        SetCollider(StaticBoardManagerBase.Data.boardTileType);
        _spriteRenderer.sprite = spriteDataList.Find(j => (int)j.boardTileType == Data.BoardTileType).sprite;
        _spriteRenderer.color = defaultColor;
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
        BoardTileState = EBoardTileState.Hovered;
        _spriteRenderer.color = hoverColor;
        Data.BoardTileState = (int)BoardTileState;
    }
    internal virtual void OnMouseExit()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        BoardTileState = EBoardTileState.None;
        _spriteRenderer.color = defaultColor;
        Data.BoardTileState = (int)BoardTileState;
    }
    internal virtual void OnMouseDown()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        BoardTileState = EBoardTileState.Selected;
        _spriteRenderer.color = selectedColor;
        Data.BoardTileState = (int) BoardTileState;
    }
    public enum EBoardTileType
    {
        Square,
        Hexagon
    }
    public enum EBoardTileState
    {
        None,
        Hovered,
        Selected,
    }
    public EBoardTileState BoardTileState;


}
