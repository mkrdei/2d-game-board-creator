using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardTile;

public class BoardTile : MonoBehaviour
{
    [HideInInspector] public BoardTile_LevelData LevelData;
    [SerializeField] public List<BoardTile_ColliderData> ColliderDataList;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public void Init(BoardTile_LevelData levelData)
    {
        LevelData = levelData;

        ColliderDataList.ForEach(colliderData => { colliderData.collider.enabled = (colliderData.boardTileType == LevelData.BoardTileType); });
        _spriteRenderer.sprite = LevelData.InitialSprite;
        transform.localPosition = new Vector3(LevelData.Coordinate.X, -LevelData.Coordinate.Y * (levelData.BoardTileType == EBoardTileType.Hexagon ? 0.85f : 1));
    }
    private void SetActive(bool active)
    {
        LevelData.Active = active;
        gameObject.SetActive(active);
    }
    private void SetVisible(bool visible)
    {
        LevelData.Visible = visible;
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
