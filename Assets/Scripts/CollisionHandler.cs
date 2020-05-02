using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem explosionPrefab;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] AudioClip deathSFX;

    [Header("Heatlh")]
    [SerializeField] float hitPoints = 20f;
    [SerializeField] Transform garbageCollector;


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(); 

        if (hitPoints < 1)
        {
            DestroyEnemy();
            FindObjectOfType<EnemySpawner>().numberDestroyed++;
        }
    }

    private void DestroyEnemy()
    {
        ParticleSystem deathFX = Instantiate(explosionPrefab, transform.position, Quaternion.identity, garbageCollector);
        float delay = deathFX.main.duration;
        deathFX.Play();
        Destroy(deathFX.gameObject, delay);

        AudioSource.PlayClipAtPoint(deathSFX, FindObjectOfType<Camera>().transform.position);

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
