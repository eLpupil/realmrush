using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject hitFX;

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
        //todo add explosionFX 
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        if (hitPoints > 0f)
        {
            //todo add hit animation hitFX
            hitPoints = hitPoints - 1;
        }
    }
}
