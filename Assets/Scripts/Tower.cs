﻿using System;
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
    [SerializeField] AudioClip bulletSFX;

    public Waypoint baseWaypoint; 

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

        if (enemies.Length == 0) { return; }
        
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
            PlayBulletSFX();
        }
        else
        {
            bulletsEmission.enabled = false;
        }
    }

    private void PlayBulletSFX()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bulletSFX);
        }
    }

    private bool enemyInRange()
    {
        return Vector3.Distance(targetEnemy.position, objectToPan.position) <= attackRange;
    }
}


