using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] int towerLimit;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count == towerLimit)
        {
            DestroyAndDequeueTower();
            AddAndQueueTower(baseWaypoint);
        }
        else
        {
            AddAndQueueTower(baseWaypoint);
        }
    }

    private void DestroyAndDequeueTower()
    {
        Tower towerRemoved = towers.Dequeue();
        Destroy(towerRemoved);
    }

    private void AddAndQueueTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, parent);
        towers.Enqueue(newTower);
    }
}
