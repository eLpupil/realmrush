using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Waypoint searchCenter;

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] List<Waypoint> path = new List<Waypoint>();

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
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            searchCenter.isExplored = true;
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighborCoordinates))
            {
                Waypoint neighbor = grid[neighborCoordinates];
                QueueNewNeighbor(neighbor);
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
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void CreatePath()
    {
        Waypoint fromWaypoint = endWaypoint;
        AddToPath(fromWaypoint);

        while (fromWaypoint != startWaypoint)
        {
            fromWaypoint = fromWaypoint.exploredFrom;
            AddToPath(fromWaypoint);
        }

        path.Reverse();
    }

    private void AddToPath(Waypoint fromWaypoint)
    {
        path.Add(fromWaypoint);
        fromWaypoint.isPlaceable = false;
    }

    public List<Waypoint> GetPath() //cache invalidation for returning path
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }
}
