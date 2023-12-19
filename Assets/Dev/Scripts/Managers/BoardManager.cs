using Dev.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private BoardTile boardTilePrefab;
    [SerializeField] private BoardTile_SpriteDataCollection spriteDataCollection;
    [SerializeField] private Transform boardTileHolderTransform;
    [Header("Settings")]
    [SerializeField] private Vector2 boardSize;
    [SerializeField] private BoardTile.EBoardTileType BoardTileType;
    [Header("Lists")]
    [SerializeField] private List<BoardTile> boardTiles;
    [field: SerializeField]
    public Vector2 BoardSize 
    { 
        get 
        { 
            return boardSize; 
        } 
        set 
        {
            boardSize = value; 
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
        boardTileHolderTransform.transform.position = new Vector3((float)-BoardSize.x / 2f + 0.5f, (float)BoardSize.y / 2f - 0.5f, 0);
        cameraManager.OrthographicSize = (float)Mathf.Max(BoardSize.x, BoardSize.y) * 1.2f;
    }
    public void SetBoardSize(Vector2 size)
    {
        boardSize = size;
    }
    public void DeactivateOutOfBoardSizeTiles()
    {
        boardTiles.FindAll(x => x.Coordinate.X >= boardSize.x || x.Coordinate.Y >= boardSize.y).ForEach(x => x.Active = false);
    }
    private void CreateTiles()
    {
        DestroyBoardTiles();

        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                Coordinate coordinate = new Coordinate(x, y);
                bool isOutOfRowLimit = false;
                if (BoardTileType == BoardTile.EBoardTileType.Hexagon)
                {
                    float distanceFromMiddle = Mathf.Abs((int)(boardSize.y/2) - y);
                    coordinate.X += distanceFromMiddle * 0.5f;
                    isOutOfRowLimit = boardSize.x - distanceFromMiddle <= x;
                    if (isOutOfRowLimit) continue;
                }
                BoardTile alreadyExistTile = boardTiles.Find(j => j.Coordinate.Equals(coordinate));
                if (alreadyExistTile)
                {
                    alreadyExistTile.Active = true;
                    continue;
                }
                var boardTile = Instantiate(boardTilePrefab, boardTileHolderTransform);
                boardTile.Init(BoardTileType, coordinate, true, true, spriteDataCollection.spriteDataList.Find(j => j.BoardTileType == BoardTileType).Sprite);
                boardTiles.Add(boardTile);
            }
        }
    }
    private void DestroyBoardTiles()
    {
        if (boardTiles.Count == 0)
            return;
        for(int i = boardTiles.Count - 1; i >= 0; i--)
        {
            Destroy(boardTiles[i].gameObject);
        }
        boardTiles.Clear();
    }
    private void ResetScene()
    {
        Init();
    }
}
