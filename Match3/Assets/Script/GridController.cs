using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GridView gridView;
    private GridModel grid;
    public int width;
    public int height;

    void Start()
    {
        grid = new GridModel();
        InitGrid(width, height, 1);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridView.DrawGrid(grid.gridColors[i, j], grid.gridPositions[i, j]);
            }
        }
    }

    private void InitGrid(int width, int height, float increasedPos)
    {
        grid.cellPos = 0;
        grid.width = width;
        grid.height = height;

        grid.gridColors = new GridModel.Colors[grid.height, grid.width];
        grid.gridPositions = new Vector2[grid.height, grid.width];

        for (int i = 0; i < grid.height; i++)
        {
            for (int j = 0; j < grid.width; j++)
            {
                grid.gridColors[i, j] = (GridModel.Colors)UnityEngine.Random.Range(1, 6);
                grid.gridPositions[i, j] = new Vector2(increasedPos * j, increasedPos * i); 
            }
        }

        for (int i = 0; i < grid.height; i++)
        {
            for (int j = 0; j < grid.width; j++)
            {
                
                while ((i >= 2 && grid.gridColors[i - 1, j] == grid.gridColors[i , j] && grid.gridColors[i - 2, j] == grid.gridColors[i, j])||
                    (j >= 2 && grid.gridColors[i, j - 1] == grid.gridColors[i, j] && grid.gridColors[i, j - 2] == grid.gridColors[i, j]))
                {
                    grid.gridColors[i, j] = (GridModel.Colors)UnityEngine.Random.Range(1, 6);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
