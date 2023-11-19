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
    [SerializeField] private Transform boardTileHolderTransform;
    [Header("Settings")]
    [SerializeField] private Vector2 boardSize;
    [SerializeField] private bool IsHexagon;
    [Header("Lists")]
    [SerializeField] private List<BoardTile> boardTileList;
    public Vector2 BoardSize { get { return boardSize; } set { SetBoardSize(value); } }
    private Vector2 prevBoardSize;

    void Awake()
    {
        Init();
    }
    private void Init()
    {
        prevBoardSize = boardSize;
        CenterBoard();
        CreateTiles();
    }

    void Update()
    {
        if (!boardSize.Equals(prevBoardSize))
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
        prevBoardSize = boardSize;
        boardSize = size;
    }
    public void DeactivateOutOfBoardSizeTiles()
    {
        boardTileList.FindAll(x => x.Coordinate.X >= boardSize.x || x.Coordinate.Y >= boardSize.y).ForEach(x => x.Active = false);
    }
    private void CreateTiles()
    {
        DeactivateOutOfBoardSizeTiles();
        for (int x = 0; x < prevBoardSize.x; x++)
        {
            for (int y = 0; y < prevBoardSize.y; y++)
            {
                Coordinate coordinate = new Coordinate(x, y);
                BoardTile alreadyExistTile = boardTileList.Find(j => j.Coordinate.Equals(coordinate));
                if (alreadyExistTile)
                {
                    alreadyExistTile.Active = true;
                    continue;
                }
                var boardTile = Instantiate(boardTilePrefab, boardTileHolderTransform);
                boardTile.Coordinate = coordinate;
                boardTileList.Add(boardTile);
            }
        }
    }
    private void ResetScene()
    {
        Init();
    }
}
