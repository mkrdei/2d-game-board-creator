using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class App_EventManager
{
    public static Action<BoardData> OnBoardCreated;
    public static Action<IMoveableTileGroup> OnMoveableTileGroupPlaced;
    public static Action<IMoveableTileGroup> OnMoveableTileGroupMouseUp;
}
