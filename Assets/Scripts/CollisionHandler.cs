using System.Collections;
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

    PathFinder path;

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

    private void Start()
    {
        path = FindObjectOfType<PathFinder>();
    }

    private void Update()
    {
        Waypoint endPoint = path.GetEndWayPoint();
        Vector2 endPointPosition = endPoint.GetGridPos();
        int gridSize = endPoint.GetGridSize();

        Vector2 enemyVector2 = new Vector2(transform.position.x/gridSize, transform.position.z/gridSize);
        if (enemyVector2 == endPointPosition)
        {
            DestroyEnemy();
        }
    }
}
