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
        Transform closestEnemy = enemies[0].transform;

        if (enemies.Length == 0) { return; }

        foreach (Enemy enemy in enemies)
        {
            GetClosestEnemy(enemy.transform, closestEnemy);
        }
        targetEnemy = closestEnemy;
    }

    private void GetClosestEnemy(Transform transform, Transform closestEnemy)
    {
        float enemyToTowerDistance = Vector3.Distance(transform.position, gameObject.transform.position);
        float closestEnemyToTowerDistance = Vector3.Distance(closestEnemy.position, gameObject.transform.position);

        if (enemyToTowerDistance < closestEnemyToTowerDistance)
        {
            closestEnemy = transform;
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


