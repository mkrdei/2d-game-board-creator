using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class App_EventManager
{
    public static Action<BoardData> OnBoardCreated;
    public static Action<MoveableTileGroup> OnMoveableTileGroupPlaced;
    public static Action<MoveableTileGroup> OnMoveableTileGroupMouseUp;
}
