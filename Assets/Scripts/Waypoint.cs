using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;

    const int gridSize = 10;

    public bool isPlaceable = true;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (this.isPlaceable)
            {
                TowerController towerController = new TowerController();
                towerController.AddTower(this);
                isPlaceable = false;
            }
            else
            {
                print("Tower can not be placed here.");
            }
        }
    }
}
