using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [Header("Instantiated Prefab Lists")]
    public List<BoardTile> boardTiles;

    [Header("References")]
    [SerializeField] internal CameraManager _cameraManager;
    [SerializeField] internal BoardTile _boardTilePrefab;
    [SerializeField] internal Transform _boardTileHolderTransform;

    [SerializeField] internal BoardData _data;

    internal virtual void OnEnable()
    {
        CreateBoard();
    }
    internal virtual void CreateBoard()
    {
        StaticBoardManager.Data = _data;
        SetOrthographicSize();
        CreateTiles();
        App_EventManager.OnBoardCreated?.Invoke(_data);
    }

    internal virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }
    internal virtual void SetOrthographicSize()
    {
        _cameraManager.OrthographicSize = (float)Mathf.Max(_data.boardSize.x, _data.boardSize.y) * 1.25f;
        Vector3 cameraCenterPosition = new Vector3(-(float)-(_data.boardSize.x - 1) / 2f * StaticBoardManager.SpaceBetweenTiles.x, -(float)(_data.boardSize.y - 1) / 2f * StaticBoardManager.SpaceBetweenTiles.y, -10);
        _cameraManager.Camera.transform.position = cameraCenterPosition;
    }
    internal virtual void CreateTiles()
    {
        DestroyBoardTiles();

        for (int x = 0; x < _data.boardSize.x; x++)
        {
            for (int y = 0; y < _data.boardSize.y; y++)
            {
                Coordinate coordinate = new Coordinate(x, y);
                if (_data.boardTileType == BoardTile.ShapeType.Hexagon1)
                {
                    float distanceFromMiddle = Mathf.Abs((int)(_data.boardSize.y / 2) - coordinate.Y);
                    if (!IsOutOfRowLimitForHexagon1(coordinate, distanceFromMiddle))
                    {
                        coordinate.X += distanceFromMiddle * 0.5f;
                        CreateTile(coordinate);
                    }
                }
                else
                {
                    CreateTile(coordinate);
                }
            }
        }
    }
    internal virtual IBoardTile CreateTile(Coordinate coordinate)
    {
        var boardTile = Instantiate(_boardTilePrefab, _boardTileHolderTransform);
        BoardTileData boardTile_Data = new BoardTileData($"{coordinate.X}{coordinate.Y}", (int)_data.boardTileType, (int)BoardTile.ESelectionState.None, coordinate, true, false, true);
        boardTile.Init(boardTile_Data);
        boardTiles.Add(boardTile);
        return boardTile;
    }
    private bool IsOutOfRowLimitForHexagon1(Coordinate coordinate, float distanceFromMiddle)
    {
        return _data.boardSize.x - distanceFromMiddle <= coordinate.X;
    }
    internal virtual void DestroyBoardTiles()
    {
        if (boardTiles == null)
            return;
        if (boardTiles.Count == 0)
            return;
        for (int i = boardTiles.Count - 1; i >= 0; i--)
        {
            Destroy(boardTiles[i].gameObject);
        }
        boardTiles.Clear();
    }
    internal virtual void ResetScene()
    {
        CreateBoard();
    }
}
