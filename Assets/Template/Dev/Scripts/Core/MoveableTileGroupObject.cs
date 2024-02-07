using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTileGroupObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private ColorManager.GameColors gameColor;
    [SerializeField] private int index;
    public void Init(ColorManager.GameColors gameColor, int index)
    {
        this.gameColor = gameColor;
        this.index = index;
        transform.DOLocalMoveY(index*0.2f,0);
        _renderer.color = ColorManager.GetGameColor(gameColor);
    }
}
