using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GridView gridView;
    private GridModel grid;

    void Start()
    {
        grid = new GridModel();
        InitializeGrid(9, 9, 1);

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                gridView.DrawGrid(grid.gridColors[i, j], grid.gridPositions[i, j]);
            }
        }
    }

    private void InitializeGrid(int width, int height, float increasedPos)
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
