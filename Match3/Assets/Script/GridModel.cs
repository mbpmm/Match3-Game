using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridModel
{
    public enum Colors
    {
        blank,
        red,
        blue,
        green,
        yellow,
        purple,
        allColors
    }

    public Colors[,] gridColors;
    public Vector2[,] gridPositions;
    
    public int cellPos, columns, rows;
}
