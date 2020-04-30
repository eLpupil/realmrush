using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] Transform parent;

    [Header("Heatlh")]
    [SerializeField] float hitPoints = 20f;
    

    // Start is called before the first frame update
    void Start()
    {
    }


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
        GameObject deathFX = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        deathFX.transform.parent = parent;
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
