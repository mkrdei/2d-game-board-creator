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

    

    public void Init(BoardTileDataBase boardTileData)
    {
        Data = boardTileData;
        SetPosition();
        SetCollider(StaticBoardManagerBase.Data.boardTileType);
        _spriteRenderer.sprite = Data.InitialSprite;
        _spriteRenderer.color = boardTileData.InitialColor;
    }
    private void SetCollider(EBoardTileType boardTileType)
    {
        _colliderDataList.ForEach(colliderData => { colliderData.collider.enabled = (colliderData.boardTileType == boardTileType); });
    }
    private void SetPosition()
    {
        transform.localPosition = new Vector3(Data.Coordinate.X, -Data.Coordinate.Y * StaticBoardManagerBase.SpaceBetweenTiles.y);
    }

    private void OnMouseOver()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        Data.CurrentColor = Color.red;
        _spriteRenderer.color = Data.CurrentColor;
    }
    private void OnMouseExit()
    {
        if (BoardTileState == EBoardTileState.Selected) return;
        Data.CurrentColor = Data.InitialColor;
        _spriteRenderer.color = Data.CurrentColor;
    }
    private void OnMouseDown()
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
