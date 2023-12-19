using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [Space(10)]
    [Header("References")]
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private BoardTile _boardTilePrefab;
    [SerializeField] private Transform _boardTileHolderTransform;

    [Space(10)]
    [Header("Data")]
    [SerializeField] private List<BoardTile_SpriteData> _spriteDataList;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] private Vector2 _boardSize;
    [SerializeField] private BoardTile.EBoardTileType _boardTileType;

    [Space(10)]
    [Header("Instantiated Prefab Lists")]
    [SerializeField] private List<BoardTile> _boardTiles;
    public Vector2 BoardSize 
    { 
        get 
        { 
            return _boardSize; 
        } 
        set 
        {
            _boardSize = value; 
        } 
    }

    void OnEnable()
    {
        Init();
    }
    private void Init()
    {
        CenterBoard();
        CreateTiles();
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
        _boardTileHolderTransform.transform.position = new Vector3((float)-BoardSize.x / 2f + 0.5f, (float)BoardSize.y / 2f - 0.5f, 0);
        _cameraManager.OrthographicSize = (float)Mathf.Max(BoardSize.x, BoardSize.y) * 1.2f;
    }
    public void SetBoardSize(Vector2 size)
    {
        _boardSize = size;
    }
    public void DeactivateOutOfBoardSizeTiles()
    {
        _boardTiles.FindAll(x => x.LevelData.Coordinate.X >= _boardSize.x || x.LevelData.Coordinate.Y >= _boardSize.y).ForEach(x => x.LevelData.Active = false);
    }
    private void CreateTiles()
    {
        DestroyBoardTiles();

        for (int x = 0; x < _boardSize.x; x++)
        {
            for (int y = 0; y < _boardSize.y; y++)
            {
                Coordinate coordinate = new Coordinate(x, y);
                bool isOutOfRowLimit = false;
                if (_boardTileType == BoardTile.EBoardTileType.Hexagon)
                {
                    float distanceFromMiddle = Mathf.Abs((int)(_boardSize.y/2) - y);
                    coordinate.X += distanceFromMiddle * 0.5f;
                    isOutOfRowLimit = _boardSize.x - distanceFromMiddle <= x;
                    if (isOutOfRowLimit) continue;
                }
                var boardTile = Instantiate(_boardTilePrefab, _boardTileHolderTransform);
                BoardTile_LevelData boardTile_Data = new BoardTile_LevelData(_boardTileType, coordinate, true, true, _spriteDataList.Find(j => j.boardTileType == _boardTileType).sprite);
                boardTile.Init(boardTile_Data);
                _boardTiles.Add(boardTile);
            }
        }
    }
    private void DestroyBoardTiles()
    {
        if (_boardTiles.Count == 0)
            return;
        for(int i = _boardTiles.Count - 1; i >= 0; i--)
        {
            Destroy(_boardTiles[i].gameObject);
        }
        _boardTiles.Clear();
    }
    private void ResetScene()
    {
        Init();
    }
}
