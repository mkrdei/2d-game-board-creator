using Dev.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using static BoardCreator;
using static BoardTile;

public class BoardCreator : MonoBehaviour
{
    public static Action<BoardData> OnBoardCreated;

    [Space(10)]
    [Header("References")]
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private BoardTile _boardTilePrefab;
    [SerializeField] private Transform _boardTileHolderTransform;

    [SerializeField] private BoardData _data;

    void OnEnable()
    {
        CreateBoard();
    }
    private void CreateBoard()
    {
        BoardManager.Data = _data;
        CenterBoard();
        SetOrthographicSize();
        CreateTiles();
        OnBoardCreated?.Invoke(_data);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }
    private void CenterBoard()
    {
        _boardTileHolderTransform.transform.position = new Vector3((float)-(_data.boardSize.x - 1) / 2f * BoardManager.SpaceBetweenTiles.x, (float)(_data.boardSize.y - 1) / 2f * BoardManager.SpaceBetweenTiles.y, 0);
    }
    private void SetOrthographicSize()
    {
        _cameraManager.OrthographicSize = (float)Mathf.Max(_data.boardSize.x, _data.boardSize.y) * 1.25f;
    }
    private void CreateTiles()
    {
        DestroyBoardTiles();

        for (int x = 0; x < _data.boardSize.x; x++)
        {
            for (int y = 0; y < _data.boardSize.y; y++)
            {
                Coordinate coordinate = new Coordinate(x, y);
                bool isOutOfRowLimit = false;
                if (_data.boardTileType == BoardTile.EBoardTileType.Hexagon)
                {
                    float distanceFromMiddle = Mathf.Abs((int)(_data.boardSize.y/2) - y);
                    coordinate.X += distanceFromMiddle * 0.5f;
                    isOutOfRowLimit = _data.boardSize.x - distanceFromMiddle <= x;
                    if (isOutOfRowLimit) continue;
                }
                var boardTile = Instantiate(_boardTilePrefab, _boardTileHolderTransform);
                BoardTileData boardTile_Data = new BoardTileData(_data.boardTileType, coordinate, true, true, _data.spriteDataList.Find(j => j.boardTileType == _data.boardTileType).sprite, _data.initialBoardTileColor, _data.initialBoardTileColor);
                boardTile.Init(boardTile_Data);
                _data.boardTiles.Add(boardTile);
            }
        }
    }
    private void DestroyBoardTiles()
    {
        if (_data.boardTiles == null)
            return;
        if (_data.boardTiles.Count == 0)
            return;
        for(int i = _data.boardTiles.Count - 1; i >= 0; i--)
        {
            Destroy(_data.boardTiles[i].gameObject);
        }
        _data.boardTiles.Clear();
    }
    private void ResetScene()
    {
        CreateBoard();
    }

    [Serializable]
    public class BoardData
    {
        [Space(10)]
        public List<BoardTile_SpriteData> spriteDataList;

        [Space(10)]
        [Header("Settings")]
        public BoardTile.EBoardTileType boardTileType;
        public Vector2 boardSize = new Vector2(5,5);
        public UnityEngine.Color initialBoardTileColor;

        [Space(10)]
        [Header("Instantiated Prefab Lists")]
        public List<BoardTile> boardTiles;
    }
}
