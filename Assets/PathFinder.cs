using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors(startWaypoint.GetGridPos());
    }


    private void LoadBlocks()
    {
        Waypoint[] WaypointList = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in WaypointList)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Duplicate block: " + gridPos);
            }
            else {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.cyan);
        endWaypoint.SetTopColor(Color.magenta);
    }

    private void ExploreNeighbors(Vector2Int vector2Int)
    {
        foreach (Vector2Int direction in directions)
        {
            try
            {
                Vector2Int explorationCoordinates = vector2Int + direction;
                print("Exploring: " + explorationCoordinates);
                grid[explorationCoordinates].SetTopColor(Color.yellow);
            }
            catch
            {
                //do nothing
            }
        }
    }
}
