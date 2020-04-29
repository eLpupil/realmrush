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
        if (enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach (Enemy enemy in enemies)
        {
           closestEnemy = GetClosestEnemy(enemy.transform, closestEnemy);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(gameObject.transform.position, transformA.position);
        float distToB = Vector3.Distance(gameObject.transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
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


