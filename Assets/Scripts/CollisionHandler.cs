﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem explosionPrefab;
    [SerializeField] ParticleSystem hitParticlePrefab;

    [Header("Heatlh")]
    [SerializeField] float hitPoints = 20f;
    [SerializeField] Transform garbageCollector;
    

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(); 

        if (hitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        ParticleSystem deathFX = Instantiate(explosionPrefab, transform.position, Quaternion.identity, garbageCollector);
        float delay = deathFX.main.duration;

        deathFX.Play();
        Destroy(deathFX.gameObject, delay);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        if (hitPoints > 0f)
        {
            hitParticlePrefab.Play();
            hitPoints = hitPoints - 1;
        }
    }
}
