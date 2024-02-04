using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveableTileGroupManager : MonoBehaviour
{
    [SerializeField] private MoveableTileGroup moveableTileGroupPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private int groupCountLimit;
    private List<MoveableTileGroup> moveableTileGroups;

    private void Start()
    {
        moveableTileGroups = new List<MoveableTileGroup>();
        CreateMoveableTile(new MoveableTileGroupData("0", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("1", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("2", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("3", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("4", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("5", "encoded_data"));
        CreateMoveableTile(new MoveableTileGroupData("6", "encoded_data"));
    }
    private void CreateMoveableTile(MoveableTileGroupData data)
    {
        if (moveableTileGroups.Count < groupCountLimit)
        {
            MoveableTileGroup moveableTileGroup = Instantiate(moveableTileGroupPrefab, gridLayoutGroup.transform);
            moveableTileGroup.Init(data);
            moveableTileGroups.Add(moveableTileGroup);
        }
    }
    private void RemoveMoveableTileGroup(MoveableTileGroup moveableTileGroup)
    {
        moveableTileGroups.Remove(moveableTileGroup);
    }

    private void OnEnable()
    {
        App_EventManager.OnMoveableTileGroupPlaced += OnMoveableTileGroupPlaced;
        App_EventManager.OnMoveableTileGroupMouseUp += OnMoveableTileGroupMouseUp;
    }
    private void OnDisable()
    {
        App_EventManager.OnMoveableTileGroupPlaced -= OnMoveableTileGroupPlaced;
        App_EventManager.OnMoveableTileGroupMouseUp -= OnMoveableTileGroupMouseUp;
    }
    private void OnMoveableTileGroupPlaced(MoveableTileGroup moveableTileGroup)
    {
        RemoveMoveableTileGroup(moveableTileGroup);
    }
    private void OnMoveableTileGroupMouseUp(MoveableTileGroup moveableTileGroup)
    {
        gridLayoutGroup.enabled = false;
        gridLayoutGroup.enabled = true;
    }
}
