using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;

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
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            Waypoint searchCenter = queue.Dequeue();
            print("searching from: " + searchCenter);
            HaltIfEndFound(searchCenter);
            searchCenter.isExplored = true;
            ExploreNeighbors(searchCenter);
        }
        //todo work out path
        print("End of Pathfinding");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("reached the end");
            isRunning = false;
        }
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

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                Waypoint neighbor = grid[neighborCoordinates];
                QueueNewNeighbor(neighbor);
                neighbor.exploredFrom = from;
            }
        }
    }

    private void QueueNewNeighbor(Waypoint neighbor)
    {
        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            // do nothing
        }
        else
        {
            queue.Enqueue(neighbor);
            print("Queueing " + neighbor);
        }
    }
}
