﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform parent;

    [SerializeField] Text towerLimitText;

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
        newBaseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(oldTower);
    }

    private void AddAndQueueTower(Waypoint newBaseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, newBaseWaypoint.transform.position, Quaternion.identity, parent);
        newBaseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = newBaseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void Update()
    {
        towerLimitText.text = "Tower Limit: " + towerLimit.ToString();
    }
}
