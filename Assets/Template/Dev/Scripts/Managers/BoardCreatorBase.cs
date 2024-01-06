using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BoardCreatorBase : MonoBehaviour
{
    public static Action<BoardData> OnBoardCreated;

    [Header("References")]
    [SerializeField] internal CameraManagerBase _cameraManager;
    [SerializeField] internal BoardTileBase _boardTilePrefab;
    [SerializeField] internal Transform _boardTileHolderTransform;

    [SerializeField] internal BoardData _data;

    internal virtual void OnEnable()
    {
        CreateBoard();
    }
    internal virtual void CreateBoard()
    {
        StaticBoardManagerBase.Data = _data;
        SetOrthographicSize();
        CreateTiles();
        OnBoardCreated?.Invoke(_data);
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
        Vector3 cameraCenterPosition = new Vector3(-(float)-(_data.boardSize.x - 1) / 2f * StaticBoardManagerBase.SpaceBetweenTiles.x, -(float)(_data.boardSize.y - 1) / 2f * StaticBoardManagerBase.SpaceBetweenTiles.y, -10);
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
                bool isOutOfRowLimit = false;
                if (_data.boardTileType == BoardTileBase.EBoardTileType.Hexagon)
                {
                    float distanceFromMiddle = Mathf.Abs((int)(_data.boardSize.y / 2) - y);
                    coordinate.X += distanceFromMiddle * 0.5f;
                    isOutOfRowLimit = _data.boardSize.x - distanceFromMiddle <= x;
                    if (isOutOfRowLimit) continue;
                }
                var boardTile = Instantiate(_boardTilePrefab, _boardTileHolderTransform);
                BoardTileDataBase boardTile_Data = new BoardTileDataBase((int)_data.boardTileType, (int)BoardTileBase.EBoardTileState.None, coordinate, true, false, true);
                boardTile.Init(boardTile_Data);
                _data.boardTiles.Add(boardTile);
            }
        }
    }
    internal virtual void DestroyBoardTiles()
    {
        if (_data.boardTiles == null)
            return;
        if (_data.boardTiles.Count == 0)
            return;
        for (int i = _data.boardTiles.Count - 1; i >= 0; i--)
        {
            Destroy(_data.boardTiles[i].gameObject);
        }
        _data.boardTiles.Clear();
    }
    internal virtual void ResetScene()
    {
        CreateBoard();
    }

    [Serializable]
    public class BoardData
    {
        [Header("Settings")]
        public BoardTileBase.EBoardTileType boardTileType;
        public Vector2 boardSize = new Vector2(5, 5);

        [Space(10)]
        [Header("Instantiated Prefab Lists")]
        public List<BoardTileBase> boardTiles;
    }
}
