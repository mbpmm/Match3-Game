using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GridView gridView;
    private GridModel grid;
    public int rows;
    public int columns;
    public GameObject[,] jewels;
    private GameObject otherJewel;
    private GameObject firstClicked;
    public int rowChange;
    public int colChange;
    public int targetX;
    public int targetY;
    public Vector2 tempPos;

    public Vector2 firstPos;
    public Vector2 lastPos;
    public float swipeAngle;


    void Start()
    {
        grid = new GridModel();
        InitGrid(rows, columns, 1);
        jewels = new GameObject[rows, columns];
        

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                jewels[i, j] = gridView.DrawTile(grid.gridColors[i, j], grid.gridPositions[i, j],i,j);
                //jewels[i, j].transform.parent = this.transform;
                
            }
        }
    }

    private void InitGrid(int rows, int columns, float increasedPos)
    {
        grid.rows = rows;
        grid.columns = columns;

        grid.gridColors = new GridModel.Colors[grid.rows, grid.columns];
        grid.gridPositions = new Vector2[grid.rows, grid.columns];

        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                grid.gridColors[i, j] = (GridModel.Colors)UnityEngine.Random.Range(1, 6);
                grid.gridPositions[i, j] = new Vector2(increasedPos * j, increasedPos * i);
                Debug.Log(grid.gridPositions[i, j]);
            }
        }

        for (int i = 0; i < grid.rows; i++)
        {
            for (int j = 0; j < grid.columns; j++)
            {
                
                while ((i >= 2 && grid.gridColors[i - 1, j] == grid.gridColors[i , j] && grid.gridColors[i - 2, j] == grid.gridColors[i, j])||
                    (j >= 2 && grid.gridColors[i, j - 1] == grid.gridColors[i, j] && grid.gridColors[i, j - 2] == grid.gridColors[i, j]))
                {
                    grid.gridColors[i, j] = (GridModel.Colors)UnityEngine.Random.Range(1, 6);
                }
            }
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                firstPos=hit.transform.position;
                firstClicked = hit.transform.gameObject;
                targetX = (int)firstClicked.transform.position.x;
                targetY = (int)firstClicked.transform.position.y;
                colChange = targetX;
                rowChange = targetY;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                lastPos = hit.transform.position;
                //otherJewel = hit.transform.gameObject;
                CalculateAngle();
            }

        }
    }


    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(lastPos.y - firstPos.y, lastPos.x - firstPos.x)*180/Mathf.PI;
        MoveJewels();
    }

    void MoveJewels()
    {
        if (swipeAngle==0 && colChange<columns)
        {
            otherJewel = jewels[rowChange, colChange + 1];
            tempPos = otherJewel.transform.position;
            otherJewel.transform.position = firstClicked.transform.position;
            firstClicked.transform.position = tempPos;
            jewels[rowChange, colChange + 1] = firstClicked;
            jewels[rowChange, colChange] = otherJewel;
        }
        if (swipeAngle == 180 && colChange < columns)
        {
            otherJewel = jewels[rowChange, colChange - 1];
            tempPos = otherJewel.transform.position;
            otherJewel.transform.position = firstClicked.transform.position;
            firstClicked.transform.position = tempPos;
            jewels[rowChange, colChange - 1] = firstClicked;
            jewels[rowChange, colChange] = otherJewel;
        }
        if (swipeAngle == 90 && rowChange < rows)
        {
            otherJewel = jewels[rowChange+1, colChange];
            tempPos = otherJewel.transform.position;
            otherJewel.transform.position = firstClicked.transform.position;
            firstClicked.transform.position = tempPos;
            jewels[rowChange+1, colChange ] = firstClicked;
            jewels[rowChange, colChange] = otherJewel;
        }
        if (swipeAngle == -90 && rowChange < rows)
        {
            otherJewel = jewels[rowChange-1, colChange];
            tempPos = otherJewel.transform.position;
            otherJewel.transform.position = firstClicked.transform.position;
            firstClicked.transform.position = tempPos;
            jewels[rowChange-1, colChange] = firstClicked;
            jewels[rowChange, colChange] = otherJewel;
        }
    }
}
