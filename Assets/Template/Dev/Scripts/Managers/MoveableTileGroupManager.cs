using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveableTileGroupManager : MonoBehaviour
{
    [SerializeField] private MoveableTileGroup moveableTileGroupPrefab;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private int groupCountLimit;
    private List<IMoveableTileGroup> moveableTileGroups;

    public virtual void Start()
    {
        moveableTileGroups = new List<IMoveableTileGroup>();
        CreateMoveableTile(new MoveableTileGroupData("0", "1234"));
        CreateMoveableTile(new MoveableTileGroupData("1", "3214"));
        CreateMoveableTile(new MoveableTileGroupData("2", "423"));
        CreateMoveableTile(new MoveableTileGroupData("3", "245"));
        CreateMoveableTile(new MoveableTileGroupData("4", "123"));
        CreateMoveableTile(new MoveableTileGroupData("5", "321"));
        CreateMoveableTile(new MoveableTileGroupData("6", "231"));
    }
    internal virtual void CreateMoveableTile(MoveableTileGroupData data)
    {
        if (moveableTileGroups.Count < groupCountLimit)
        {
            gridLayoutGroup.enabled = false;
            GameObject moveableTileGroupParent = new GameObject();
            moveableTileGroupParent.AddComponent<RectTransform>();
            moveableTileGroupParent.name = "MoveableTileGroupParent";
            moveableTileGroupParent.transform.parent = gridLayoutGroup.transform;
            MoveableTileGroup moveableTileGroup = Instantiate(moveableTileGroupPrefab, moveableTileGroupParent.transform);
            moveableTileGroup.Init(data);
            moveableTileGroups.Add(moveableTileGroup);
            gridLayoutGroup.enabled = true;
        }
    }
    private void RemoveMoveableTileGroup(IMoveableTileGroup moveableTileGroup)
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
    private void OnMoveableTileGroupPlaced(IMoveableTileGroup moveableTileGroup)
    {
        RemoveMoveableTileGroup(moveableTileGroup);
    }
    private void OnMoveableTileGroupMouseUp(IMoveableTileGroup moveableTileGroup)
    {
    }
}
