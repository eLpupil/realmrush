using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count == towerLimit)
        {
            MoveExistingTower(baseWaypoint);
        }
        else
        {
            AddAndQueueTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towerQueue.Dequeue();
        oldTower.transform.position = newBaseWaypoint.transform.position;
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint = newBaseWaypoint;
        towerQueue.Enqueue(oldTower);
    }

    private void AddAndQueueTower(Waypoint newBaseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, newBaseWaypoint.transform.position, Quaternion.identity, parent);
        newBaseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = newBaseWaypoint;
        towerQueue.Enqueue(newTower);
    }
}
