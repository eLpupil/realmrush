using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    //[Range(1f, 20f)][SerializeField] float gridSize = 10f;
    Waypoint waypoint;


    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0,
            waypoint.GetGridPos().y * gridSize  
        );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelText;

        gameObject.name = "Cube " + labelText;
    }
}
