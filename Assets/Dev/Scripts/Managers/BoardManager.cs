using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private List<BoardTile> boardTileList;
    [SerializeField] private Transform boardTileHolderTransform;
    [SerializeField] private Vector2Int startBoardSize;
    [SerializeField] private Vector2Int boardSize;
    public Vector2Int BoardSize { get { return boardSize; } set { SetBoardSize(value); } }
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Init());
    }
    private IEnumerator Init()
    {
        SetTiles();
        BoardSize = new Vector2Int(startBoardSize.x, startBoardSize.y);
        boardTileHolderTransform.transform.position = new Vector3((float)-BoardSize.x / 2f + 0.5f, (float)BoardSize.y / 2f - 0.5f, 0);
        cameraManager.OrthographicSize = (float)Mathf.Max(BoardSize.x, BoardSize.y)*1.2f;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoardSize(Vector2Int size)
    {
        boardSize = size;
        boardTileList.FindAll(x => x.Coordinate.X >= size.y || x.Coordinate.Y >= size.y).ForEach(x => x.Active = false);
    }
    private void SetTiles()
    {
        boardTileList.ForEach(x => x.SetCoordinate());
    }
}
