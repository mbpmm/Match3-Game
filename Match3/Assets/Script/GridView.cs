using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    public GameObject template;
    public Transform newParent;
    private Color purple=new Color(128,0,128);

    public void DrawGrid(GridModel.Colors tileColor, Vector2 tilePosition)
    {
        GameObject newTile = Instantiate(template, new Vector3(tilePosition.x, tilePosition.y), Quaternion.identity);
        newTile.SetActive(true);

        switch (tileColor)
        {
            case GridModel.Colors.blank:
                newTile.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case GridModel.Colors.red:
                newTile.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case GridModel.Colors.blue:
                newTile.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case GridModel.Colors.green:
                newTile.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case GridModel.Colors.yellow:
                newTile.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case GridModel.Colors.purple:
                newTile.GetComponent<SpriteRenderer>().color = purple;
                break;
            default:
                break;
        }
    }
}
