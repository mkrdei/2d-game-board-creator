using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorManager
{
    private static Dictionary<GameColors, string> gameColorDictionary = new Dictionary<GameColors, string>()
    {
        {GameColors.Black, "#190d14" },
        {GameColors.Red, "#e9362b"},
        {GameColors.Green, "#3f9c2c"},
        {GameColors.Blue, "#2b59b7"},
        {GameColors.Purple, "#7f3687"},
        {GameColors.Pink, "#bd5596"},
        {GameColors.Yellow, "#fdc11a"},
        {GameColors.Orange, "#ff7524"},
        {GameColors.White, "#f4e9e9"}
    };

    public static Color GetGameColor(GameColors colorType)
    {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(gameColorDictionary[colorType], out color))
        {
            return color;
        }
        return color;
    }
    public enum GameColors
    {
        None,
        Red,
        Green,
        Blue,
        Orange,
        Purple,
        Pink,
        Yellow,
        White,
        Black
    }
}
