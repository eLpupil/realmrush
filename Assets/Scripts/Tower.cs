using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Parameters")]
    // Parameters of each tower
    [SerializeField] Transform objectToPan;

    [SerializeField] float towerDamage = 5;
    [SerializeField] float attackRange = 30f;

    [SerializeField] ParticleSystem bullets;

    // State of each tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        TrackAndFire();
    }

    private void SetTargetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float closestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetEnemy = enemy.transform;
            }
        }
    }

    private void TrackAndFire()
    {
        var bulletsEmission = bullets.emission;

        if (targetEnemy != null && enemyInRange())
        {
            objectToPan.LookAt(targetEnemy);
            bulletsEmission.enabled = true;
        }
        else
        {
            bulletsEmission.enabled = false;
        }
    }

    private bool enemyInRange()
    {
        return Vector3.Distance(targetEnemy.position, objectToPan.position) <= attackRange;
    }

    public float GetTowerDamage()
    {
        return towerDamage;
    }

}


